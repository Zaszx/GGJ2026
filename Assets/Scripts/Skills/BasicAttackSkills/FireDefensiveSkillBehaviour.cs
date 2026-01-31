using UnityEngine;

public class FireDefensiveSkillBehaviour : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float damageOverTime = 25f;
    [SerializeField] private float fireLifeTime = 5f;
    [SerializeField] private float fireRadius = 4f;

    [SerializeField] private float dashForce = 10f;

    [Header("Visuals")]
    [SerializeField] private ParticleSystem dashEffect;

    [Header("Components")]
    [SerializeField] private Collider2D firePitPrefab;


    public void Cast(Player user)
    {
        var rb = user.GetComponent<Rigidbody2D>();

        var dashDir = -user.GetComponent<PlayerController>().LastMoveDir.normalized;

        rb.AddForce(dashDir * dashForce, ForceMode2D.Impulse);

        Debug.Log("Cast dash, add fire now lol");
        //SummonFirePit();
    }

    private void SummonFirePit()
    {
    }    

    
}