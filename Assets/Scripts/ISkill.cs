public interface ISkill
{
    CooldownType CooldownType { get; }
    void Use(Player user);
}
public interface ISkillEffect
{
    void BeforeUse(Player user);
    void AfterUse(Player user);
}
