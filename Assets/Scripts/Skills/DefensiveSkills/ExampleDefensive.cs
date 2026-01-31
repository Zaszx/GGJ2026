using UnityEngine;

public class ExampleDefensive : ISkill
{
    public CooldownType CooldownType => CooldownType.Medium;

    public void Use(Player user)
    {
        Debug.Log("Player " + user.PlayerName + " used ExampleDefensiveSkill");
    }
}
