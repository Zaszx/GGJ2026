using UnityEngine;

public class WaterUltiSkill : ISkill
{
	public CooldownType CooldownType => CooldownType.Slow; // change if you want

	private readonly GameObject ultimateProjectilePrefab;

	public WaterUltiSkill(GameObject prefab)
	{
		ultimateProjectilePrefab = prefab;
	}

	public void Use(Player user)
	{
		if (user == null) return;

		Vector2 dir = GetFiringDirectionForPlayer(user);
		if (dir.sqrMagnitude < 0.0001f)
			dir = Vector2.right;

		float spawnOffset = 0.7f;
		Vector2 spawnPos = (Vector2)user.transform.position + dir.normalized * spawnOffset;

		GameObject go = Object.Instantiate(ultimateProjectilePrefab, spawnPos, Quaternion.identity);

		WaterUlti proj = go.GetComponent<WaterUlti>();
		if (proj == null)
		{
			Debug.LogError("Ultimate projectile prefab is missing WaterUltimateProjectile component.");
			Object.Destroy(go);
			return;
		}

		proj.Init(user, dir);
	}

	// Placeholder to keep this snippet self-contained.
	// Remove this if you already have it elsewhere.
	private Vector2 GetFiringDirectionForPlayer(Player firingPlayer)
	{
		return Vector2.right;
	}
}
