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
        skills.Add(SkillSlot.Defensive, newSkills[2]);
    }

    public void UseSkill(SkillSlot slot)
    {
        skills[slot].Use(GetComponent<Player>());
    }
    
}

public enum SkillSlot
{
    None,
    BasicAttack,
    Defensive,
    Ulti
}