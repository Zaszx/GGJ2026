using UnityEngine;

public class FireDefensiveSkill : ISkill
{
    public CooldownType CooldownType => CooldownType.Medium;

    private readonly GameObject firepitPrefab;

    public FireDefensiveSkill(GameObject prefab)
    {
        firepitPrefab = prefab;
    }

    public void Use(Player user)
    {
        if (user == null) return;

        // Spawn centered on the player.
        GameObject prefab = Object.Instantiate(firepitPrefab, user.transform.position, Quaternion.identity);

		FirepitDash firepitDash = prefab.GetComponent<FirepitDash>();

        if (firepitDash == null)
        {
            Debug.LogError(prefab + " is missing FireDefensiveSkillBehaviour component.");
            Object.Destroy(prefab);
            return;
        }

		firepitDash.Cast(user);

    }
}
