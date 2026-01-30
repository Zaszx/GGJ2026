using UnityEngine;

public static class Prefabs
{
    public static GameObject Projectile;

    static Prefabs()
	{
		Projectile = Resources.Load<GameObject>("Prefabs/Projectile");
	}
}
