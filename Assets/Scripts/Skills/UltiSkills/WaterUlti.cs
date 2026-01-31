using UnityEngine;

public class WaterUlti : MonoBehaviour
{
	[SerializeField] private float speed = 12f;
	[SerializeField] private float lifeTime = 4f;

	private Rigidbody2D rb;
	private Player owner;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0f;

		// For fast bullets:
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

		Destroy(gameObject, lifeTime);
	}

	public void Init(Player ownerPlayer, Vector2 direction)
	{
		owner = ownerPlayer;

		Vector2 dir = direction.sqrMagnitude > 0.0001f ? direction.normalized : Vector2.right;

		// Move once, no homing
		rb.linearVelocity = dir * speed;

		// Optional: orient sprite
		transform.right = dir;

		// Optional: ignore hitting the shooter if you use collision (not trigger)
		// If you're using triggers, you can still ignore using Physics2D.IgnoreCollision.
		IgnoreOwnerCollision();
	}

	private void IgnoreOwnerCollision()
	{
		if (owner == null) return;

		var ownerCol = owner.GetComponent<Collider2D>();
		var myCol = GetComponent<Collider2D>();

		if (ownerCol != null && myCol != null)
			Physics2D.IgnoreCollision(myCol, ownerCol, true);
	}

	// Hit logic optional — if you already implemented it earlier, you can reuse it here too.
	// Otherwise, this is a minimal example:
	private void OnTriggerEnter2D(Collider2D other)
	{
		// Example: if you want “projectile vs player/projectile/wall” like before,
		// keep that logic here (layer-based) and call Destroy(gameObject).

		Player player = other.GetComponent<Player>();
		if (player != null)
		{
			player.ReceiveDamage(25);
		}

		Destroy(gameObject);
	}
}
