using UnityEngine;

public static class Prefabs
{
    public static GameObject Projectile;
	public static GameObject WaterSweepAttack;

	static Prefabs()
	{
		Projectile = Resources.Load<GameObject>("Prefabs/Projectile");
		WaterSweepAttack = Resources.Load<GameObject>("Prefabs/WaterSweepAttack");
	}
}
