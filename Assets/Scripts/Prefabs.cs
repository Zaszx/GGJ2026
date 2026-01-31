using UnityEngine;

public static class Prefabs
{
    public static GameObject Projectile;
	public static GameObject WaterSweepAttack;
	public static GameObject WaterLanceAttack;
	public static GameObject WaterBarrier;

	static Prefabs()
	{
		Projectile = Resources.Load<GameObject>("Prefabs/Projectile");
		WaterSweepAttack = Resources.Load<GameObject>("Prefabs/WaterSweepAttack");
		WaterLanceAttack = Resources.Load<GameObject>("Prefabs/WaterLanceAttack");
		WaterBarrier = Resources.Load<GameObject>("Prefabs/WaterBarrier");
	}
}
