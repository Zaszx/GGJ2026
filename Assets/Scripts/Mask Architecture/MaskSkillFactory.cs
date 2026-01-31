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
        // -> heavy
        var heavy = CreateBasicSkill(mask.teeth.element);
        ApplySynergy(basic, mask.face.element, mask.teeth.element);
        skills.Add(heavy);

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
        ISkill skill = element switch
        {
            Element.Fire =>  new ExampleUlti(),
            Element.Water => new ExampleUlti(),
            Element.Air =>   new ExampleUlti(),
            Element.Earth => new ExampleUlti(),
            _ => new ExampleUlti()
        };

        return new SkillInstance(skill);
    }

    static SkillInstance CreateBasicSkill(Element element)
    {
        ISkill skill = element switch
        {
            Element.Air =>      new ExampleBasicAttack(),
            Element.Water =>    new WaterBasicAttack(Prefabs.WaterSweepAttack),
            Element.Fire =>     new FireBasicAttackSkill(Prefabs.Projectile),
            Element.Earth =>    new ExampleBasicAttack(),
            _ => new ExampleBasicAttack(),
        };
        return new SkillInstance(skill);
    }

    static SkillInstance CreateDefensiveSkill(Element element)
    {
        ISkill skill = element switch
        {
            Element.Fire =>     new ExampleDefensive(),
            Element.Water =>    new ExampleDefensive(),
            Element.Air =>      new ExampleDefensive(),
            Element.Earth =>    new ExampleDefensive(),
            _ => new ExampleDefensive()
        };

        return new SkillInstance(skill);
    }

}
