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
        GameObject.Instantiate(fireWavePrefab, user.transform.position, Quaternion.identity);
    }
}
