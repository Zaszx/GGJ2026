using UnityEngine;

public class ExampleBasicAttack : ISkill
{
    public static CooldownType CooldownType => CooldownType.Fast;

    public void Use(Player user)
    {
        Debug.Log("Player " + user.PlayerName + " used ExampleBasicAttack");
    }
}
