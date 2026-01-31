using UnityEngine;

public class ExampleBadSkillEffect : ISkillEffect
{
    public void AfterUse(Player user)
    {
        Debug.Log("Player " + user.PlayerName + " used a skill and now AfterUse has triggered with a BAD/TRADEOFF skill effect");
    }

    public void BeforeUse(Player user)
    {
        Debug.Log("Player " + user.PlayerName + " tried to use a skill and now BeforeUse has triggered with a BAD/TRADEOF skill effect");
    }
}
