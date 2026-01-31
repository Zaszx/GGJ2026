using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WaterBarrier : MonoBehaviour
{
	[SerializeField] private float durationSeconds = 3f;

	private Player owner;
	private bool hasBlocked;

	private void Awake()
	{
		var col = GetComponent<Collider2D>();
		col.isTrigger = true;
	}

	public void Init(Player ownerPlayer)
	{
		owner = ownerPlayer;

		Destroy(gameObject, durationSeconds);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (hasBlocked) return;

		if (owner != null && other.transform.IsChildOf(owner.transform))
			return;

		BlockAttack(other.gameObject);
	}

	private void BlockAttack(GameObject attackObject)
	{
		hasBlocked = true;

		Destroy(attackObject);
		Destroy(gameObject);
	}
}
