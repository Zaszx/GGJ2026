using System.Collections;
using UnityEngine;

public class FirepitDash : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float damageOverTime = 25f;
    [SerializeField] private float fireLifeTime = 5f;

    [SerializeField] private float dashForce = 25f;

    [Header("Visuals")]
    [SerializeField] private ParticleSystem firepitEffect;

    private Player _owner;

    public void Cast(Player user)
    {
        _owner = user;
        IgnoreOwnerCollision();

        firepitEffect.Play();

        var rb = user.GetComponent<Rigidbody2D>();
        var pc = user.GetComponent<PlayerController>();

        var dashDir = -pc.LastMoveDir.normalized;
        if (dashDir == Vector2.zero)
            dashDir = Vector2.left;

        pc.AddExternalVelocity(dashDir * dashForce);

        Destroy(gameObject,fireLifeTime);
    }
    private void IgnoreOwnerCollision()
    {
        if (_owner == null) return;

        var ownerCol = _owner.GetComponent<Collider2D>();
        var myCol = GetComponent<Collider2D>();

        if (ownerCol != null && myCol != null)
            Physics2D.IgnoreCollision(myCol, ownerCol, true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player p))
        {
            p.ReceiveDamage(damageOverTime * Time.deltaTime);
        }
    }
}