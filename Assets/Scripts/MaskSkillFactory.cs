using UnityEngine.UI;

public static class MaskSkillFactory
{
    /*
    public static List<SkillInstance> CreateSkills(Mask mask)
    {
        var skills = new List<SkillInstance>();

        // FACE → ulti
        var ulti = CreateUlti(mask.face.element);
        ApplySynergy(ulti, mask.face.element, mask.teeth.element);
        ApplySynergy(ulti, mask.face.element, mask.crown.element);
        skills.Add(ulti);

        // TEETH → basic
        var basic = CreateBasic(mask.teeth.element);
        ApplySynergy(basic, mask.face.element, mask.teeth.element);
        skills.Add(basic);

        // CROWN → defensive
        var def = CreateDefensive(mask.crown.element);
        ApplySynergy(def, mask.face.element, mask.crown.element);
        skills.Add(def);

        return skills;
    }
    static void ApplySynergy(SkillInstance skill, Element baseElement, Element partElement)
    {
        if (baseElement == partElement)
        {
            skill.AddEffect(new EmpoweredEffect());
        }
        else
        {
            skill.AddEffect(new UnstableEffect());
        }
    }
*/
}
