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
            var airUltiBehaviour = go.GetComponent<AirUltiBehaviour>();
            airUltiBehaviour.Target = GameObject.FindGameObjectWithTag(user.CompareTag("Player1") ? "Player2" : "Player1");
            airUltiBehaviour.Origin = user.transform.position;
            
        }
    }
}