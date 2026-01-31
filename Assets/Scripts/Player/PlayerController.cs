using System;
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
	private Rigidbody2D _rb;

	[Header("Movement")]
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private bool normalizeDiagonal = true;

	public FacingDirection Facing { get; private set; } = FacingDirection.Down;

	// Optional: last non-zero move direction as a vector (handy for aiming, etc.)
	public Vector2 LastMoveDir { get; private set; } = Vector2.down;
	
	[Header("Controls")]
	private PlayerInput _playerInput;
	private InputActionAsset _inputActionAsset;
	private Vector2 _moveDir;
	private string PlayerPrefix => isPlayer1 ? "1" : "2";
	private HeavyAttackLoading _heavyAttackLoadingBar;

	private void Awake()
	{
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
	private bool _attackLock;
	[SerializeField] private float heavyAttackLoadDuration = 2f;
	private void Update()
	{
		if (_isHoldingFire)
		{
			_attackLock = false;
			_heavyAttackProgress += Time.deltaTime / heavyAttackLoadDuration;
			_heavyAttackLoadingBar.SetProgress(_heavyAttackProgress);
			if (_heavyAttackProgress >= 1f)
			{
				//Heavy Attack
				Debug.Log("Heavy Attack");
				_heavyAttackProgress = 0f;
				_heavyAttackLoadingBar.ResetBar();
			}
		}
		else
		{
			if (!_attackLock)
			{
				Debug.Log("Normal Attack");
				_attackLock = true;
			}

			_heavyAttackProgress = 0f;
			_heavyAttackLoadingBar.ResetBar();
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
		
		GameManager.Instance.Fire(this);
	}

}
