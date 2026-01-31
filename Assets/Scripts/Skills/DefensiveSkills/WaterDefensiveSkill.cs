using UnityEngine;

public class WaterDefensiveSkill : ISkill
{
	public CooldownType CooldownType => CooldownType.Fast;

	private readonly GameObject barrierPrefab;

	public WaterDefensiveSkill(GameObject prefab)
	{
		barrierPrefab = prefab;
	}

	public void Use(Player user)
	{
		if (user == null) return;

		// Spawn centered on the player.
		GameObject go = Object.Instantiate(barrierPrefab, user.transform.position, Quaternion.identity);

		// Barrier should follow player: parent it.
		go.transform.SetParent(user.transform, worldPositionStays: true);

		WaterBarrier barrier = go.GetComponent<WaterBarrier>();
		if (barrier == null)
		{
			Debug.LogError("Barrier prefab is missing WaterBarrier component.");
			Object.Destroy(go);
			return;
		}

		barrier.Init(user);
	}
}
