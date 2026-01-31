using UnityEngine;

public class ExampleGoodSkillEffect : ISkillEffect
{
    public void AfterUse(Player user)
    {
        Debug.Log("Player " + user.PlayerName + " used a skill and now AfterUser has triggered from a BENEFICIAL skill effect");
    }

    public void BeforeUse(Player user)
    {
        Debug.Log("Player " + user.PlayerName + " tried to use a skill and now BeforeUse has triggered from a BENEFICIAL skill effect");
    }
}
