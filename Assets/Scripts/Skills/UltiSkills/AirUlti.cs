using Skills.UltiSkills.Behaviour;
using UnityEngine;

namespace Skills.UltiSkills
{
    public class AirUlti : ISkill
    {
        public CooldownType CooldownType => CooldownType.Ulti;
        public void Use(Player user)
        {
            //Sence bende bunu yapacak kafa kaldı mı?
            GameObject go = Object.Instantiate(Prefabs.AirUlt);
            go.GetComponent<AirUltiBehaviour>().Target = GameObject.FindGameObjectWithTag(user.CompareTag("Player1") ? "Player2" : "Player1");
        }
    }
}