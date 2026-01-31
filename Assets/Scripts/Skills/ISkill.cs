public interface ISkill
{
    static CooldownType CooldownType { get; }
    void Use(Player user);
}
