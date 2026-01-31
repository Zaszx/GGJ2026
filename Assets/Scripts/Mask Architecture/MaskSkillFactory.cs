using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.UI;

public static class MaskSkillFactory
{
    
    public static List<SkillInstance> CreateSkills(ShamanMask mask)
    {
        var skills = new List<SkillInstance>();

        // FACE → ulti
        var ulti = CreateUltiSkill(mask.face.element);
        ApplySynergy(ulti, mask.face.element, mask.teeth.element);
        ApplySynergy(ulti, mask.face.element, mask.crown.element);
        skills.Add(ulti);

        // TEETH → basic
        var basic = CreateBasicSkill(mask.teeth.element);
        ApplySynergy(basic, mask.face.element, mask.teeth.element);
        skills.Add(basic);

        // CROWN → defensive
        var def = CreateDefensiveSkill(mask.crown.element);
        ApplySynergy(def, mask.face.element, mask.crown.element);
        skills.Add(def);

        return skills;
    }
    static void ApplySynergy(SkillInstance skill, Element baseElement, Element partElement)
    {
        if (baseElement == partElement)
        {
            skill.AddEffect(new DummySkillEffect());
        }
        else
        {
            skill.AddEffect(new DummySkillEffect());
        }
    }
    static SkillInstance CreateUltiSkill(Element element)
    {
        return new SkillInstance(new DummySkill());
    }
    static SkillInstance CreateBasicSkill(Element element)
    {
        return new SkillInstance(new DummySkill());
    }
    static SkillInstance CreateDefensiveSkill(Element element)
    {
        return new SkillInstance(new DummySkill());
    }
}

public class DummySkillEffect : ISkillEffect
{
    public void AfterUse(Player user)
    {
    }

    public void BeforeUse(Player user)
    {
    }
}

public class DummySkill : ISkill
{
    public CooldownType CooldownType => CooldownType.None;

    public void Use(Player user)
    {
    }
}