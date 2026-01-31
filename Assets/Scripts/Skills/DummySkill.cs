public class DummySkill : ISkill
{
    public CooldownType CooldownType => CooldownType.None;

    public void Use(Player user)
    {
    }
}