using UnityEngine;

public static class Prefabs
{
    public static GameObject Projectile;
    public static GameObject Fireball;

    static Prefabs()
	{
		Projectile = Resources.Load<GameObject>("Prefabs/Projectile");
        Fireball = Resources.Load<GameObject>("Prefabs/FireBall");
    }
}
