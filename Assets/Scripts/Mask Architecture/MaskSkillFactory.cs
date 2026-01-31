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
        ApplySynergy(ulti, mask.face.element, mask.teeth.element); //buradaki efekt kombinasyonlarını şimdilik boşverin knk, böyle example olarak kalsın beraber doldururuz.
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
            skill.AddEffect(new ExampleGoodSkillEffect()); //burada efektif bir kombo yapıldığını varsayılıyor, bonus efekt eklenmeli
        }
        else
        {
            skill.AddEffect(new ExampleBadSkillEffect()); //burada ise dezavantajlı bir kombo yapıldığı varsayılmaktadır, negatif efekt eklenmeli
        }
    }
    static SkillInstance CreateUltiSkill(Element element)
    {
        return new SkillInstance(new ExampleUlti());
    }
    static SkillInstance CreateBasicSkill(Element element)
    {
        // mesela
        //if(element is Element.Fire)
        //return new SkillInstance(new FireBasicAttack());
        //else ...
        return new SkillInstance(new ExampleBasicAttack());
    }
    static SkillInstance CreateDefensiveSkill(Element element)
    {
        return new SkillInstance(new ExampleDefensive());
    }
}
