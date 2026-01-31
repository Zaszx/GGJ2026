using NUnit.Framework;
using UnityEngine;


public enum PlayerSelect
{
    Player1,
    Player2
}
public class Player : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] SkillController playerSkillController;

    public string PlayerName => stats.PlayerName;


    private void Start()
    {
        Foo();

        ShamanMask player1Mask;
        ShamanMask player2Mask;
        if (stats.PlayerSelection == PlayerSelect.Player1)
        {
            player1Mask = PlayerMaskSelections.Player1Mask;

            var skills = MaskSkillFactory.CreateSkills(player1Mask);
            playerSkillController.SetSkills(skills);
        }
        else if (stats.PlayerSelection == PlayerSelect.Player2)
        {
            player2Mask = PlayerMaskSelections.Player2Mask;

            var skills = MaskSkillFactory.CreateSkills(player2Mask);
            playerSkillController.SetSkills(skills);
        }
        else
        {

            var crown = new MaskPiece();
            crown.type = MaskPieceType.Crown;
            crown.element = Element.Air;
            var face = new MaskPiece();
            face.type = MaskPieceType.Face;
            face.element = Element.Air;
            var teeth = new MaskPiece();
            teeth.type = MaskPieceType.Teeth;
            teeth.element = Element.Air;

            player1Mask = new ShamanMask(crown, face, teeth);

            var skills = MaskSkillFactory.CreateSkills(player1Mask);
            playerSkillController.SetSkills(skills);
        }
        Debug.Log(PlayerMaskSelections.Player1Mask.face.GetHashCode());
        Debug.Log(PlayerMaskSelections.Player2Mask.face.GetHashCode());

        // playerSkillController.UseSkill(SkillSlot.BasicAttack);
        // playerSkillController.UseSkill(SkillSlot.Defensive);
        // playerSkillController.UseSkill(SkillSlot.Ulti);
    }

    private void Foo()
    {
        Debug.Log("Bar " + PlayerName);
        Debug.Log(PlayerName + " is using a skill now");
    }

}
