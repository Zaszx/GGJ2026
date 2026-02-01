using System;
using UnityEngine;

namespace Skills.UltiSkills.Behaviour
{
    public class AirUltiBehaviour : MonoBehaviour
    {
        public GameObject Target { get; set; }
        public Vector2 Origin { get; set; }
        private const float Speed = 5f;
        private const float PullForce = 0.8f;
        private const float PullRadius = 5f;
        private Rigidbody2D _rb;
        private Vector2 _direction;

        private void Start()
        {
            transform.position = Origin;
            _direction = (Target.transform.position - transform.position).normalized;
            Debug.Log(Target.name);
        }

        private void Update()
        {
            if (!Target) return;
            _rb = GetComponent<Rigidbody2D>();
            _rb.linearVelocity = _direction * Speed;
            
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, PullRadius);
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag(Target.tag))
                {
                    hit.gameObject.GetComponent<PlayerController>().AddExternalVelocity((transform.position - hit.transform.position).normalized * PullForce);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, PullRadius);
        }
    }
}