using Skills.BasicAttackSkills.BasicAttackBehaviours;
using UnityEngine;

namespace Skills.BasicAttackSkills
{
    public class AirBasicAttack : ISkill
    {
        public CooldownType CooldownType => CooldownType.Fast;
        public void Use(Player user)
        {
            ShootAt(user ,user.transform);
        }
        private float projectileSpeed = 30f;

        private void ShootAt(Player player, Transform firePoint)
        {
            GameObject projectilePrefab = Prefabs.AirBasic;
            Vector2 direction = GameManager.Instance.GetFiringDirectionForPlayer(player);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            GameObject projectile =
                Object.Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            AirBasicBehaviour behaviour = projectile.GetComponent<AirBasicBehaviour>();
            behaviour.SourceTag = player.gameObject.tag;
            rb.linearVelocity = direction * projectileSpeed;
            Debug.Log(rb.linearVelocity);
        }
    }
}