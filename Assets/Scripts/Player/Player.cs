using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] SkillController playerSkillController;
	[SerializeField] private int health = 100;

	public string PlayerName => stats.PlayerName;


    private void Start()
    {
        Foo();

        ShamanMask playerMask = PlayerMaskSelections.Player1Mask;
        if (playerMask is null) //Hata varsa diye, oyunu bozmamak adına, normalde silinebilir
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

        // playerSkillController.UseSkill(SkillSlot.BasicAttack);
        // playerSkillController.UseSkill(SkillSlot.Defensive);
        // playerSkillController.UseSkill(SkillSlot.Ulti);
    }

    private void Foo()
    {
        Debug.Log("Bar " + PlayerName);
        Debug.Log(PlayerName + " is using a skill now");
    }
	public void ReceiveDamage(int damage)
	{
		health = health - damage;
		if (health <= 0)
		{
			GameManager.Instance.OnPlayerDeath(this);
		}
	}

}
