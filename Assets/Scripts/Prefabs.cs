using UnityEngine;

public static class Prefabs
{
    public static GameObject Projectile;
    public static GameObject Fireball;
	public static GameObject WaterSweepAttack;
	public static GameObject WaterLanceAttack;
	public static GameObject WaterBarrier;

	static Prefabs()
	{
		Projectile = Resources.Load<GameObject>("Prefabs/Projectile");
        Fireball = Resources.Load<GameObject>("Prefabs/FireBall");

        WaterSweepAttack = Resources.Load<GameObject>("Prefabs/WaterSweepAttack");
        WaterLanceAttack = Resources.Load<GameObject>("Prefabs/WaterLanceAttack");
        WaterBarrier = Resources.Load<GameObject>("Prefabs/WaterBarrier");
    }
	
}
