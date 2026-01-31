using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	[SerializeField] private int damage = 50;

	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void Init(Vector2 direction)
	{
		direction = direction.normalized;

		rb.linearVelocity = direction * speed;

		transform.right = direction;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Player hitPlayer = other.GetComponent<Player>();
		Projectile hitProjectile = other.GetComponent<Projectile>();

		if (hitPlayer != null)
		{
			hitPlayer.ReceiveDamage(damage);
		}
		else if (hitProjectile != null)
		{

		}
		else
		{

		}

		GameObject.Destroy(this.gameObject);
	}

}
