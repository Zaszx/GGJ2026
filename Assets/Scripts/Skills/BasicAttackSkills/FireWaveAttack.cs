using UnityEngine;

public class FireWaveAttack : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float damage = 25f;
    [SerializeField] private float waveKnockback = 25f;

    [SerializeField] private float growthSpeed = 5f; 
    [SerializeField] private Vector3 targetScale = new Vector3(3f, 4f, 1f); 

    [Header("Visuals")]
    [SerializeField] private ParticleSystem startEffect;

    [Header("Components")]
    [SerializeField] private Rigidbody2D RB;

    Player _owner;

    public void Cast(Player user, Vector2 dir, Vector3 castPos)
    {
        _owner = user;

        transform.position = castPos;


        IgnoreOwnerCollision();
        startEffect.Play();
    }
    private void FixedUpdate()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, growthSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player p))
        {
            p.ReceiveDamage(damage);
            var dir = p.transform.right;
            p.GetComponent<PlayerController>().AddExternalVelocity(dir * waveKnockback);
        }
    }
    private void IgnoreOwnerCollision()
    {
        if (_owner == null) return;

        var ownerCol = _owner.GetComponent<Collider2D>();
        var myCol = GetComponent<Collider2D>();

        if (ownerCol != null && myCol != null)
            Physics2D.IgnoreCollision(myCol, ownerCol, true);
    }

}
