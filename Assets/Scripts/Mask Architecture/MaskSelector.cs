using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MaskSelector : MonoBehaviour
{
	public TMP_Text titleText;

    public MaskPartSelector topSelector;
    public MaskPartSelector midSelector;
	public MaskPartSelector bottomSelector;

	bool playerOneTurn = true;

	public Sprite[] topSprites;
	public Sprite[] midSprites;
	public Sprite[] bottomSprites;

	private void Start()
	{
		topSelector.Init(topSprites);
		midSelector.Init(midSprites);
		bottomSelector.Init(bottomSprites);

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

			topSelector.Init(topSprites);
			midSelector.Init(midSprites);
			bottomSelector.Init(bottomSprites);
		}
		else
		{
			PlayerMaskSelections.Player2Top = topSelector.GetSelectedIndex();
			PlayerMaskSelections.Player2Mid = midSelector.GetSelectedIndex();
			PlayerMaskSelections.Player2Bottom = bottomSelector.GetSelectedIndex();

			SceneManager.LoadScene("Arena");
		}
	}
}
