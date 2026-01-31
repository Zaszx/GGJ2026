using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class FireBasicAttackBehaviour : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float damage = 25f;
    [SerializeField] private float range = 10f;
    [SerializeField] private float explosionRadius = 4f;
    [SerializeField] private float speed = 15f;

    private float distTravelled;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (true)
        {
            PlayExplodeEffect();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
           
        }
    }

    private void PlayExplodeEffect()
    {
        explosionEffect.transform.parent = null;
        explosionEffect.Play();

        GameObject.Destroy(explosionEffect, 3f);
    }
}