using UnityEngine;

namespace Skills.DefensiveSkills
{
    public class AirDefence : ISkill
    {
        private float dashForce = 50f;
        public CooldownType CooldownType => CooldownType.Medium;
        public void Use(Player user)
        {
            Debug.Log(user.Controller.LastMoveDir);
            user.Controller.AddExternalVelocity(user.Controller.LastMoveDir * dashForce);
        }
    }
}