using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public string PlayerName;
    public PlayerSelect PlayerSelection;
    
    [Header("Basic Stats")]
    public float MaxHp;
    public float MoveSpeed;

    [Header("CoolDowns")]
    public float FastSkillCD;
    public float MediumSkillCD;
    public float SlowSkillCD;

    [Header("Ultimate Skill Points")]
    public int LowCostUltSP;
    public int MediumCostUltSP;
    public int HighCostUltSP;


    //public ShamanMask Mask;

}