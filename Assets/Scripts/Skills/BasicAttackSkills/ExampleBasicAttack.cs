using UnityEngine;

public class ExampleBasicAttack : ISkill
{
    public CooldownType CooldownType => CooldownType.Fast;

    public void Use(Player user)
    {
        Debug.Log("Player " + user.PlayerName + " used ExampleBasicAttack");
    }
}
