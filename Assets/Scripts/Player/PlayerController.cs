using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

public enum FacingDirection
{
	Up,
	UpRight,
	Right,
	DownRight,
	Down,
	DownLeft,
	Left,
	UpLeft
}

public class PlayerController : MonoBehaviour 
{
	[Header("Player")]
	[SerializeField] private bool isPlayer1 = true;
	[SerializeField] private PlayerStats stats;
	
	private Rigidbody2D _rb;
	private SkillController _skillController;

	[Header("Movement")]
	[SerializeField] private float moveSpeed = 5f;
	//[SerializeField] private bool normalizeDiagonal = true;

	public FacingDirection Facing { get; private set; } = FacingDirection.Down;

	// Optional: last non-zero move direction as a vector (handy for aiming, etc.)
	public Vector2 LastMoveDir { get; private set; } = Vector2.down;
	
	[Header("Controls")]
	private PlayerInput _playerInput;
	private InputActionAsset _inputActionAsset;
	private Vector2 _moveDir;
	public static string PlayerPrefix;
	private HeavyAttackLoading _heavyAttackLoadingBar;
	private Dictionary<SkillSlot, bool> _skillCooldowns = new()
	{
		{ SkillSlot.BasicAttack, false },
		{ SkillSlot.HeavyAttack, false },
		{ SkillSlot.Defensive, false },
		{ SkillSlot.Ulti, false }
	};

	private void Awake()
	{
		PlayerPrefix = isPlayer1 ? "1" : "2";
		_skillController = GetComponent<SkillController>();
		_rb = GetComponent<Rigidbody2D>();
		_playerInput = GetComponent<PlayerInput>();
		_heavyAttackLoadingBar = GetComponentInChildren<HeavyAttackLoading>();
		
		_inputActionAsset = _playerInput.actions;
	}

	private void OnEnable()
	{
		_inputActionAsset[PlayerPrefix + "Move"].performed += OnMove;
		_inputActionAsset[PlayerPrefix + "Move"].canceled += OnMove;
		_inputActionAsset[PlayerPrefix + "Fire"].performed += OnFire;
		_inputActionAsset[PlayerPrefix + "Fire"].canceled += OnFire;
		_inputActionAsset[PlayerPrefix + "Defence"].performed += OnDefence;
		_inputActionAsset[PlayerPrefix + "Defence"].canceled += OnDefence;
		_inputActionAsset[PlayerPrefix + "Ult"].performed += OnUlt;
		_inputActionAsset[PlayerPrefix + "Ult"].canceled += OnUlt;
	}

	private void OnDisable()
	{
		_inputActionAsset[PlayerPrefix + "Move"].performed -= OnMove;
		_inputActionAsset[PlayerPrefix + "Move"].canceled -= OnMove;
		_inputActionAsset[PlayerPrefix + "Fire"].performed -= OnFire;
		_inputActionAsset[PlayerPrefix + "Fire"].canceled -= OnFire;
		_inputActionAsset[PlayerPrefix + "Defence"].performed -= OnDefence;
		_inputActionAsset[PlayerPrefix + "Defence"].canceled -= OnDefence;
		_inputActionAsset[PlayerPrefix + "Ult"].performed -= OnUlt;
		_inputActionAsset[PlayerPrefix + "Ult"].canceled -= OnUlt;
	}


	private float _heavyAttackProgress;
	private bool _isHoldingFire;
	private bool _attackLock = true;
	[SerializeField] private float heavyAttackLoadDuration = 2f;
	private void Update()
	{
		CheckAttack();
		return;

		void CheckAttack()
		{
			if (_isHoldingFire)
			{
				_attackLock = false;
				_heavyAttackProgress += Time.deltaTime / heavyAttackLoadDuration;
				_heavyAttackLoadingBar.SetProgress(_heavyAttackProgress);
			}
			else
			{
				if (!_attackLock && !_skillCooldowns[SkillSlot.BasicAttack] && _heavyAttackProgress >= 1f)
				{
					// Heavy Attack
					Debug.Log("Heavy Attack");
					_skillController.UseSkill(SkillSlot.HeavyAttack);
					_attackLock = true;
					_heavyAttackProgress = 0f;
					_heavyAttackLoadingBar.ResetBar();
				}
				else if (!_attackLock && !_skillCooldowns[SkillSlot.BasicAttack])
				{
					Debug.Log("Normal Attack");
					StartCoroutine(SkillCooldown(_skillController.UseSkill(SkillSlot.BasicAttack), SkillSlot.BasicAttack));
					_attackLock = true;
				}

				_heavyAttackProgress = 0f;
				_heavyAttackLoadingBar.ResetBar();
			}
		}
	}
	
	//İki knockback yöntemini de tutuyorum isteyen istediğini kullansın -T
	private void FixedUpdate()
	{
		switch (_isKnockedBack)
		{
			case false:
				UpdateMovement(_moveDir);
				break;
			case true:
				if (_rb.linearVelocity.magnitude < 0.1f)
				{
					_isKnockedBack = false;
					_rb.linearVelocity = Vector2.zero;
				}
				break;
		}
	}

	
    private Vector2 externalVelocity;

    private void UpdateMovement(Vector2 dir)
    {
        Vector2 inputVelocity = dir * moveSpeed;

        _rb.linearVelocity = inputVelocity + externalVelocity;

        externalVelocity = Vector2.Lerp(externalVelocity,Vector2.zero,12f * Time.fixedDeltaTime);

        Facing = GetFacingFromInput(dir);
        LastMoveDir = dir;
    }

    public void AddExternalVelocity(Vector2 force)
    {
        externalVelocity += force;
    }

	private static FacingDirection GetFacingFromInput(Vector2 input)
	{
		// Assumes input components are in {-1,0,1} from keyboard.
		int x = (int)Mathf.Sign(input.x);
		int y = (int)Mathf.Sign(input.y);

		if (x == 0 && y > 0) return FacingDirection.Up;
		if (x > 0 && y > 0) return FacingDirection.UpRight;
		if (x > 0 && y == 0) return FacingDirection.Right;
		if (x > 0 && y < 0) return FacingDirection.DownRight;
		if (x == 0 && y < 0) return FacingDirection.Down;
		if (x < 0 && y < 0) return FacingDirection.DownLeft;
		if (x < 0 && y == 0) return FacingDirection.Left;
		// x < 0 && y > 0
		return FacingDirection.UpLeft;
	}

	public void OnMove(InputAction.CallbackContext ctx)
	{
		Debug.Log("OnMove");
		_moveDir = ctx.ReadValue<Vector2>();
	}

	public void OnFire(InputAction.CallbackContext ctx)
	{
		if (ctx.canceled)
		{
			_isHoldingFire = false;
			return;
		}
		_isHoldingFire = true;
		
	}
	private IEnumerator SkillCooldown(CooldownType cooldown, SkillSlot skillType)
	{
		_skillCooldowns[skillType] = true;
		switch (cooldown)
		{
			case CooldownType.Fast: yield return new WaitForSeconds(stats.FastSkillCD);
				break;
			case CooldownType.Medium: yield return new WaitForSeconds(stats.MediumSkillCD);
				break;
			case CooldownType.Slow: yield return new WaitForSeconds(stats.SlowSkillCD);
				break;
			case CooldownType.Ulti: yield return new WaitForSeconds(stats.SlowSkillCD);
				break;
		}
		Debug.Log("Cooldown End");
		_skillCooldowns[skillType] = false;
		yield return null;
	}
	
	private void OnUlt(InputAction.CallbackContext ctx)
	{
		if (ctx.canceled || _skillCooldowns[SkillSlot.Ulti])
		{
			return;
		}
		StartCoroutine(SkillCooldown(_skillController.UseSkill(SkillSlot.Ulti), SkillSlot.Ulti));
	}

	private void OnDefence(InputAction.CallbackContext ctx)
	{
		if (ctx.canceled || _skillCooldowns[SkillSlot.Defensive])
		{
			return;
		}
		StartCoroutine(SkillCooldown(_skillController.UseSkill(SkillSlot.Defensive), SkillSlot.Defensive));
	}
	private bool _isKnockedBack;
	public void ApplyKnockback(Vector2 direction, float force, string sourceTag)
	{
		if (CompareTag(sourceTag)) return;
		_isKnockedBack = true;
		_rb.AddForce(direction * force, ForceMode2D.Impulse);
		StartCoroutine(KnockbackCooldown(0.3f));
		
	}

	private IEnumerator KnockbackCooldown(float duration)
	{
		yield return new WaitForSeconds(duration);
		_isKnockedBack = false;
	}
}
