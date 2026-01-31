using UnityEngine;
using UnityEngine.UI;

public class MaskPartSelector : MonoBehaviour
{
	public Image maskImage;

	Sprite[] maskPartSprites;
	int selectedIndex = 0;
	MaskPiece _maskPiece;
	public void Init(MaskPiece maskPiece)
	{
		maskPartSprites = SpriteLoader.instance.GetMaskSpritesByType(maskPiece.type);
		selectedIndex = 0;
        UpdateSprite();
	}

	public void NextButtonClicked()
	{
		selectedIndex++;
		if (selectedIndex >= maskPartSprites.Length)
			selectedIndex = 0;
		UpdateSprite();
	}

	public void PreviousButtonClicked()
	{
		selectedIndex--;
		if (selectedIndex < 0)
			selectedIndex = maskPartSprites.Length - 1;
		UpdateSprite();
	}

	void UpdateSprite()
	{
		maskImage.sprite = maskPartSprites[selectedIndex];
	}

	public int GetSelectedIndex()
	{
		return selectedIndex;
	}
	public MaskPiece GetMaskPiece()
	{
		_maskPiece.type = (MaskPieceType)selectedIndex;
		return _maskPiece;
	}
}
