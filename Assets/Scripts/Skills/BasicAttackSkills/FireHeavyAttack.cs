using UnityEngine;

public class FireHeavyAttack : ISkill
{
    public CooldownType CooldownType => CooldownType.Slow;

    GameObject fireWavePrefab;

    public FireHeavyAttack(GameObject prefab)
    {
        fireWavePrefab = prefab;
    }

    public void Use(Player user)
    {
        Vector2 dir = GameManager.Instance.GetFiringDirectionForPlayer(user);

        GameObject.Instantiate(fireWavePrefab, user.transform.position, Quaternion.identity)
            .GetComponent<FireWaveAttack>().Cast(user,dir,user.transform.position);
        Debug.Log("Player " + user.PlayerName + " used FireHeavySkill");

    }
}
