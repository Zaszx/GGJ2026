using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] SkillController playerSkillController;

    public string PlayerName => stats.PlayerName;

    private void OnEnable()
    {
        ShamanMask playerMask = PlayerMaskSelections.Player1Mask;
        if (playerMask is null)
        {
            Debug.LogWarning("YOU LOADED FROM SOMEWHERE ELSE, LOAD FROM MASK SELECTION.");

            var crown = new MaskPiece();
            crown.type = MaskPieceType.Crown;
            crown.element = Element.Air;
            var face = new MaskPiece();
            face.type = MaskPieceType.Face;
            face.element = Element.Air;
            var teeth = new MaskPiece();
            teeth.type = MaskPieceType.Teeth;
            teeth.element = Element.Air;

            playerMask = new ShamanMask(crown, face, teeth);
        }
        var skills = MaskSkillFactory.CreateSkills(playerMask);
        playerSkillController.SetSkills(skills);
    }

    private void Start()
    {
        foo();
        playerSkillController.UseSkill(SkillSlot.BasicAttack);
        playerSkillController.UseSkill(SkillSlot.Defensive);
        playerSkillController.UseSkill(SkillSlot.Ulti);
    }

    public void foo()
    {
        Debug.Log("Bar " + PlayerName);
        Debug.Log(PlayerName + " is using a skill now");
    }

}
