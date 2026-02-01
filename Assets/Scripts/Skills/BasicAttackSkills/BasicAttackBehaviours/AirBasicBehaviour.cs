using System;
using UnityEngine;

namespace Skills.BasicAttackSkills.BasicAttackBehaviours
{
    public class AirBasicBehaviour : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Collider2D _col;
        private const float KnockbackForce = 10f;
        private const float Damage = 2.5f;
        public string SourceTag { get; set; }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _col = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                PlayerController hitPlayer = other.GetComponent<PlayerController>();
                if (hitPlayer != null && !other.gameObject.CompareTag(SourceTag))
                {
                    hitPlayer.ApplyKnockback(_rb.linearVelocity.normalized, KnockbackForce, SourceTag);
                    hitPlayer.PlayerScript.ReceiveDamage(Damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
