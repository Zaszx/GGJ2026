using UnityEngine;

public class FireUltimateSkill : ISkill
{
    public CooldownType CooldownType => CooldownType.Ulti;

    GameObject infernoPrefab;

    public FireUltimateSkill(GameObject prefab)
    {
        infernoPrefab = prefab;
    }

    public void Use(Player user)
    {
        Vector2 dir = GameManager.Instance.GetFiringDirectionForPlayer(user);

        GameObject.Instantiate(infernoPrefab, user.transform.position, Quaternion.identity)
            .GetComponent<FireInferno>().Cast(user.transform.position, dir, user);
        Debug.Log("Player " + user.PlayerName + " used FireUltimate");
    }
}
