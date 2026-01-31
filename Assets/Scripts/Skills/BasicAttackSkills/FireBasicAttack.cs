using UnityEngine;

public class FireBasicAttackSkill : ISkill
{
    public CooldownType CooldownType => CooldownType.Fast;

    GameObject fireballPrefab;

    public FireBasicAttackSkill(GameObject prefab)
    {
        fireballPrefab = prefab;
    }
    public void Use(Player user)
    {       
        Vector2 dir = Vector2.right;
        GameObject.Instantiate(
            fireballPrefab,
            new(0f,0f,0f),
            Quaternion.identity
        ).GetComponent<FireBasicAttackBehaviour>().Shoot(Vector3.zero,dir);
        Debug.Log("Player " + user.PlayerName + " used FireBasicAttackSkill");

    }

}
