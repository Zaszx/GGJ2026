using UnityEngine;

public static class Prefabs
{
    public static GameObject Projectile;
    public static GameObject Fireball;
	public static GameObject FirePit;
    public static GameObject FireWave;
	public static GameObject FireInferno;
    public static GameObject WaterSweepAttack;
	public static GameObject WaterLanceAttack;
	public static GameObject WaterBarrier;
	public static GameObject WaterUlti;
	public static GameObject AirBasic;

	static Prefabs()
	{
		Projectile =		Resources.Load<GameObject>("Prefabs/Projectile");
		WaterSweepAttack =	Resources.Load<GameObject>("Prefabs/WaterSweepAttack");
		WaterLanceAttack =	Resources.Load<GameObject>("Prefabs/WaterLanceAttack");
		WaterBarrier =		Resources.Load<GameObject>("Prefabs/WaterBarrier");
		WaterUlti =			Resources.Load<GameObject>("Prefabs/WaterUlti");

        Fireball =			Resources.Load<GameObject>("Prefabs/FireBall");
        FireWave =			Resources.Load<GameObject>("Prefabs/FireWave");
        FirePit =			Resources.Load<GameObject>("Prefabs/FirePit");
		FireInferno =		Resources.Load<GameObject>("Prefabs/FireInferno");

        AirBasic =			Resources.Load<GameObject>("Prefabs/AirBasic");
	}
	
}
