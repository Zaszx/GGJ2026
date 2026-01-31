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

public class FireBasicAttackBehaviour : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float range = 10f;
    [SerializeField] private float explosionRadius = 4f;

    [Header("Visuals")]
    [SerializeField] private ParticleSystem flyEffect;
    [SerializeField] private ParticleSystem explosionEffect;
}