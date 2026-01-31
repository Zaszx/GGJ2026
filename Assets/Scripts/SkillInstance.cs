using System.Collections.Generic;

public class SkillInstance
{
    ISkill skill;
    List<ISkillEffect> effects;

    public SkillInstance(ISkill skill)
    {
        this.skill = skill;
        effects = new();
    }

    public void AddEffect(ISkillEffect effect)
    {
        effects.Add(effect);
    }

    public void Use(Player user)
    {
        foreach (var e in effects)
            e.BeforeUse(user);

        skill.Use(user);

        foreach (var e in effects)
            e.AfterUse(user);
    }
}
