using UnityEngine;

public class WaterBasicAttack : ISkill
{
    public CooldownType CooldownType => CooldownType.Fast;

    GameObject waterAttackPrefab;

    public WaterBasicAttack(GameObject prefab)
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

		// Typically you want the swing to move with the player, so parent it.
		// If you want it to stay in world space, remove this line.
		go.transform.SetParent(user.transform, worldPositionStays: true);

		// Initialize sweep behavior
		WaterSweepAttack sweep = go.GetComponent<WaterSweepAttack>();
		if (sweep == null)
		{
			Debug.LogError("WaterBasicAttack prefab is missing WaterSweepAttack component.");
			Object.Destroy(go);
			return;
		}

		sweep.Init(user, dir);
	}

}
