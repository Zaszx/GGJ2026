using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MaskSelector : MonoBehaviour
{
	public TMP_Text titleText;

    public MaskPartSelector topSelector;	//Crown
    public MaskPartSelector midSelector;	//Face
	public MaskPartSelector bottomSelector;	//Teeth

	bool playerOneTurn = true;

	public MaskPiece topPiece;
	public MaskPiece midPiece;
	public MaskPiece bottomPiece;

	private void Start()
	{
		topSelector.Init(topPiece);
		midSelector.Init(midPiece);
		bottomSelector.Init(bottomPiece);

		titleText.text = "Player 1's turn\nPlayer 2, look the fuck away!";
	}

	public void ReadyClicked()
	{
		if (playerOneTurn)
		{
			titleText.text = "Player 2's turn\nPlayer 1, look the fuck away!";
			playerOneTurn = false;

			PlayerMaskSelections.Player1Top = topSelector.GetSelectedIndex();
			PlayerMaskSelections.Player1Mid = midSelector.GetSelectedIndex();
			PlayerMaskSelections.Player1Bottom = bottomSelector.GetSelectedIndex();

			ShamanMask p1Mask = new(topSelector.GetMaskPiece(), midSelector.GetMaskPiece(), bottomSelector.GetMaskPiece());

			PlayerMaskSelections.Player1Mask = p1Mask;

			topSelector.Init(topPiece);
			midSelector.Init(midPiece);
			bottomSelector.Init(bottomPiece);
		}
		else
		{
			PlayerMaskSelections.Player2Top = topSelector.GetSelectedIndex();
			PlayerMaskSelections.Player2Mid = midSelector.GetSelectedIndex();
			PlayerMaskSelections.Player2Bottom = bottomSelector.GetSelectedIndex();

            ShamanMask p2Mask = new(topSelector.GetMaskPiece(), midSelector.GetMaskPiece(), bottomSelector.GetMaskPiece());

            PlayerMaskSelections.Player1Mask = p2Mask;

            SceneManager.LoadScene("Arena");
		}
	}
}
