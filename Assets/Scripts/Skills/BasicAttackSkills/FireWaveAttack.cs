using UnityEngine;

public class FireWaveAttack : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float damage = 25f;
    [SerializeField] private float waveMaxWidth = 4f;
    [SerializeField] private float waveKnockback = 25f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 1f;

    [Header("Visuals")]
    [SerializeField] private ParticleSystem flyEffect;
    [SerializeField] private ParticleSystem explosionEffect;
    [Header("Components")]
    [SerializeField] private Rigidbody2D RB;

}
