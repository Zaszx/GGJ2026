using UnityEngine;

public class ExampleUlti : ISkill
{
    //Her skill'in ISkill olması gerekiyor, ve MonoBehaviour olmamalı. Direkt oluşturulduğu için böyle.
    //Eğer monobehaviour logic'i gerekirse Player monobehaviour zaten, oradan çekilebilir.
    //Yada prefab yapılıp, direkt new SkillInstance(new ExampleUlti()) yerine GameObject.Instantiate(prefab).GetComponent<zartzurt>() belki
    public CooldownType CooldownType => CooldownType.Ulti;

    public void Use(Player user)
    {
        Debug.Log("Player " + user.PlayerName + " used exampleUlti");
    }
}

