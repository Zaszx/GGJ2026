using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    Dictionary<SkillSlot, SkillInstance> skills;

    public void SetSkills(List<SkillInstance> newSkills)
    {
        // slotlara dağıt
    }

    public void UseSkill(SkillSlot slot)
    {
        skills[slot].Use(GetComponent<Player>());
    }
    
}

public enum SkillSlot
{
    None,
    Attack,
    Defensive,
    Ulti
}