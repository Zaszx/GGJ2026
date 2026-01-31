using UnityEngine;

public class WaterHeavyAttack : ISkill
{
	public CooldownType CooldownType => CooldownType.Fast;

	GameObject waterAttackPrefab;

	public WaterHeavyAttack(GameObject prefab)
	{
		waterAttackPrefab = prefab;
	}
	public void Use(Player user)
	{
		Vector2 dir = GameManager.Instance.GetFiringDirectionForPlayer(user);

		if (dir.sqrMagnitude < 0.0001f)
			dir = Vector2.right; // fallback: avoid NaNs if players overlap

		// Spawn at player position (you can add an offset inside the prefab controller)
		GameObject go = Object.Instantiate(waterAttackPrefab, user.transform.position, Quaternion.identity);

		// Initialize sweep behavior
		WaterLanceAttack lance = go.GetComponent<WaterLanceAttack>();
		if (lance == null)
		{
			Debug.LogError("WaterHeavyAttack prefab is missing WaterLanceAttack component.");
			Object.Destroy(go);
			return;
		}

		lance.Init(user, dir);
	}

}
