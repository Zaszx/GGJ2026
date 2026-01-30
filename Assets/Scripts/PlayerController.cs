using System.Collections.Generic;
using UnityEngine;

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

	[Header("Movement")]
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private bool normalizeDiagonal = true;

	public FacingDirection Facing { get; private set; } = FacingDirection.Down;

	// Optional: last non-zero move direction as a vector (handy for aiming, etc.)
	public Vector2 LastMoveDir { get; private set; } = Vector2.down;

	private void Update()
	{
		Dictionary<Key, KeyCode> map = isPlayer1 ? Keys.Player1Keys : Keys.Player2Keys;

		UpdateMovement();

		if(Input.GetKeyDown(map[Key.Fire]))
		{
			GameManager.Instance.Fire(this);
		}
	}

	private void UpdateMovement()
	{
		Dictionary<Key, KeyCode> map = isPlayer1 ? Keys.Player1Keys : Keys.Player2Keys;

		int x = 0;
		int y = 0;

		if (Input.GetKey(map[Key.Left])) x -= 1;
		if (Input.GetKey(map[Key.Right])) x += 1;
		if (Input.GetKey(map[Key.Down])) y -= 1;
		if (Input.GetKey(map[Key.Up])) y += 1;

		Vector2 input = new Vector2(x, y);

		Vector2 move = input;
		if (normalizeDiagonal && move.sqrMagnitude > 1f)
			move = move.normalized;

		if (move != Vector2.zero)
		{
			transform.position += (Vector3)(move * moveSpeed * Time.deltaTime);

			Facing = GetFacingFromInput(input);

			LastMoveDir = move.normalized;
		}
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
}
