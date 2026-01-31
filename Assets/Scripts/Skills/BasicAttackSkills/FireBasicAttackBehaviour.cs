using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class FireBasicAttackBehaviour : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float damage = 25f;
    [SerializeField] private float explosionRadius = 4f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 1f;

    [Header("Visuals")]
    [SerializeField] private ParticleSystem flyEffect;
    [SerializeField] private ParticleSystem explosionEffect;
    [Header("Components")]
    [SerializeField] private Rigidbody2D RB;


    public void Shoot(Vector3 castPos, Vector2 dir, bool enemyBullet = false)
    {
        transform.position = castPos;
        RB.linearVelocity = dir * speed;
    }

    private void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0f)
        {
            Explode();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("adsfdg")) //ts should not explode if it hits a fly or smth.
        Explode();
    }

    private void Explode()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        for(int i=0; i<hits.Length; i++)
        {
            Debug.Log(hits[i].name);
            if (hits[i].TryGetComponent<Player>(out Player p))
            {
                Debug.Log("player " + p.PlayerName + " was hit by Explosion");
                //p.TakeDamage(damage);
                p.GetComponent<Rigidbody2D>().AddForce((p.transform.position - transform.position).normalized * 5f, ForceMode2D.Impulse);
            }
        }

        explosionEffect.transform.parent = null;
        explosionEffect.Play();

        GameObject.Destroy(explosionEffect.gameObject, 3f);
        Destroy(this.gameObject);
    }
}
