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
        Vector2 dir = GameManager.Instance.GetFiringDirectionForPlayer(user);

        GameObject.Instantiate(fireballPrefab, user.transform.position, Quaternion.identity)
            .GetComponent<FireBasicAttackBehaviour>().Shoot(user.transform.position, dir,user);
        Debug.Log("Player " + user.PlayerName + " used FireBasicAttackSkill");
    }

}
