using UnityEngine;

public class FireBasicAttack : ISkill
{
    public CooldownType CooldownType => CooldownType.Fast;

    GameObject fireballPrefab;

    public FireBasicAttack(GameObject prefab)
    {
        fireballPrefab = prefab;
    }
    public void Use(Player user)
    {
        /*
        Vector2 dir = user.AimDirection;
        GameObject.Instantiate(
            fireballPrefab,
            user.CastPoint.position,
            Quaternion.LookRotation(Vector3.forward, dir)
        ); 
        */
    }

}
