using UnityEngine;

public class WaterSweepAttack : MonoBehaviour
{
	[Header("Sweep")]
	[SerializeField] private float sweepDegrees = 25f;     // +/- degrees
	[SerializeField] private float duration = 3f;       // how fast the swing is
	[SerializeField] private float radius = 2f;          // how far from player the hitbox sits

	[Header("Lifetime")]
	[SerializeField] private bool destroyAfter = true;

	private Player owner;
	private float elapsed;
	private float startAngle;
	private float endAngle;

	// If your hitbox sprite/collider isn't centered, you can put it under a child transform
	// and rotate this object (root) while offsetting the child on X by radius.
	private Transform pivot;

	bool alreadyHit = false;

	private void Awake()
	{
		pivot = transform;
	}

	public void Init(Player ownerPlayer, Vector2 aimDirection)
	{
		owner = ownerPlayer;

		float baseAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

		startAngle = baseAngle - sweepDegrees;
		endAngle = baseAngle + sweepDegrees;

		// Start at the beginning of the arc
		ApplyAngle(startAngle);

		// If your prefab root has the collider, you can simply offset the whole object:
		// (This assumes the sprite/collider is centered on the object.)
		UpdatePositionForAngle(startAngle);
	}

	private void Update()
	{
		if (duration <= 0f)
		{
			ApplyAngle(endAngle);
			if (destroyAfter) Destroy(gameObject);
			return;
		}

		elapsed += Time.deltaTime;
		float t = Mathf.Clamp01(elapsed / duration);

		// Linear sweep (you can ease this if you want)
		float angle = Mathf.Lerp(startAngle, endAngle, t);

		ApplyAngle(angle);
		UpdatePositionForAngle(angle);

		if (t >= 1f && destroyAfter)
			Destroy(gameObject);
	}

	private void ApplyAngle(float angleDeg)
	{
		pivot.rotation = Quaternion.Euler(0f, 0f, angleDeg);
	}

	private void UpdatePositionForAngle(float angleDeg)
	{
		if (owner == null) return;

		// Place the hitbox at a radius in front of the player along the current sweep angle
		Vector2 offset = AngleToVector(angleDeg) * radius;
		transform.position = (Vector2)owner.transform.position + offset;
	}

	private static Vector2 AngleToVector(float angleDeg)
	{
		float rad = angleDeg * Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Player player = other.GetComponent<Player>();
		if (!alreadyHit && player != null && player != owner)
		{
			player.ReceiveDamage(15f);
			alreadyHit = true;
		}
	}
}
