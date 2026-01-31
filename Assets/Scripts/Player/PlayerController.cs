using System;
using System.Collections;
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
	[SerializeField] private int health = 100;
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
	private string PlayerPrefix => isPlayer1 ? "1" : "2";
	private HeavyAttackLoading _heavyAttackLoadingBar;
	private bool _isOnCooldown;

	private void Awake()
	{
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
	}

	private void OnDisable()
	{
		_inputActionAsset[PlayerPrefix + "Move"].performed -= OnMove;
		_inputActionAsset[PlayerPrefix + "Move"].canceled -= OnMove;
		_inputActionAsset[PlayerPrefix + "Fire"].performed -= OnFire;
		_inputActionAsset[PlayerPrefix + "Fire"].canceled -= OnFire;
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
				if (!_attackLock && !_isOnCooldown && _heavyAttackProgress >= 1f)
				{
					// Heavy Attack
					Debug.Log("Heavy Attack");
					_skillController.UseSkill(SkillSlot.HeavyAttack);
					_attackLock = true;
					_heavyAttackProgress = 0f;
					_heavyAttackLoadingBar.ResetBar();
				}
				else if (!_attackLock && !_isOnCooldown)
				{
					Debug.Log("Normal Attack");
					StartCoroutine(AttackCooldown(_skillController.UseSkill(SkillSlot.BasicAttack)));
					_attackLock = true;
				}

				_heavyAttackProgress = 0f;
				_heavyAttackLoadingBar.ResetBar();
			}
		}
	}
	
	private void FixedUpdate()
	{
		UpdateMovement(_moveDir);
	}

	private void UpdateMovement(Vector2 dir)
	{
		_rb.linearVelocity = (dir * moveSpeed);

		Facing = GetFacingFromInput(dir);

		LastMoveDir = dir;
	}

	public void ReceiveDamage(int damage)
	{
		health = health - damage;
		if (health <= 0)
		{
			GameManager.Instance.OnPlayerDeath(this);
		}
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
	private IEnumerator AttackCooldown(CooldownType cooldown)
	{
		_isOnCooldown = true;
		switch (cooldown)
		{
			case CooldownType.Fast: yield return new WaitForSeconds(stats.FastSkillCD);
				break;
			case CooldownType.Medium: yield return new WaitForSeconds(stats.MediumSkillCD);
				break;
		}
		Debug.Log("Cooldown End");
		_isOnCooldown = false;
		yield return null;
	}
}
