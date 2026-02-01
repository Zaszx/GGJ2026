using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public struct PlayerMaskSprites
{
    public Sprite crown;
    public Sprite face;
    public Sprite teeth;
    public void Construct(Sprite c, Sprite f, Sprite t)
    {
        crown = c;
        face = f;
        teeth = t;
    }
}

public class MaskSelector : MonoBehaviour
{
	public bool isTest=false;
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

		titleText.text = "Player 1's turn\nPlayer 2, look away!";
	}

	public void ReadyClicked()
	{
		if (playerOneTurn)
		{
			titleText.text = "Player 2's turn\nPlayer 1, look away!";
			playerOneTurn = false;

			//Skill Mask
			ShamanMask p1Mask = new(topSelector.GetMaskPiece(), midSelector.GetMaskPiece(), bottomSelector.GetMaskPiece());

			PlayerMaskSelections.Player1Mask = p1Mask;

			//Sprites
			PlayerMaskSprites _p1Sprites = new();
			_p1Sprites.Construct(topSelector.GetSelectedSprite(), midSelector.GetSelectedSprite(), bottomSelector.GetSelectedSprite());
            PlayerMaskSelections.p1Sprites = _p1Sprites;

            topSelector.Init(topPiece);
			midSelector.Init(midPiece);
			bottomSelector.Init(bottomPiece);
		}
		else
		{
            //Skill Mask
            ShamanMask p2Mask = new(topSelector.GetMaskPiece(), midSelector.GetMaskPiece(), bottomSelector.GetMaskPiece());

            PlayerMaskSelections.Player2Mask = p2Mask;

            //Sprites
            PlayerMaskSprites _p2Sprites = new();
            _p2Sprites.Construct(topSelector.GetSelectedSprite(), midSelector.GetSelectedSprite(), bottomSelector.GetSelectedSprite());
			PlayerMaskSelections.p2Sprites = _p2Sprites;

            if (!isTest)
				SceneManager.LoadScene("Arena");
			else SceneManager.LoadScene("AgahTest");
		}
	}
}
