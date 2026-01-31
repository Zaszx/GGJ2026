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
        private float projectileSpeed = 10f;

        private void ShootAt(Player player, Transform firePoint)
        {
            GameObject projectilePrefab = Prefabs.AirBasic;
            Vector2 direction = GameManager.Instance.GetFiringDirectionForPlayer(player);
            
            GameObject projectile =
                Object.Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            AirBasicBehaviour behaviour = projectile.GetComponent<AirBasicBehaviour>();
            behaviour.SourceTag = player.gameObject.tag;
            rb.linearVelocity = direction * projectileSpeed;
            Debug.Log(rb.linearVelocity);
        }
    }
}