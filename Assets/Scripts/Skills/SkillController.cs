using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    Dictionary<SkillSlot, SkillInstance> skills;

    private void OnEnable()
    {
        skills = new();
    }

    public void SetSkills(List<SkillInstance> newSkills)
    {
        skills.Add(SkillSlot.Ulti, newSkills[0]);
        skills.Add(SkillSlot.BasicAttack, newSkills[1]);
        skills.Add(SkillSlot.HeavyAttack, newSkills[2]);
        skills.Add(SkillSlot.Defensive, newSkills[3]);
    }

    public CooldownType UseSkill(SkillSlot slot)
    {
        skills[slot].Use(GetComponent<Player>());
        return skills[slot].GetCooldown();
    }
    
}

public enum SkillSlot
{
    None,
    BasicAttack,
    HeavyAttack,
    Defensive,
    Ulti
}