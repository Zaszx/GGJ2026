public interface ISkill
{
    CooldownType CooldownType { get; }
    void Use(Player user);
}
