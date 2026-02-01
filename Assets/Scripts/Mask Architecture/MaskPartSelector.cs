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
		_maskPiece = maskPiece;
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

	public Sprite GetSelectedSprite()
	{
		return maskImage.sprite;
    }

	public int GetSelectedIndex()
	{
		return selectedIndex;
	}
	public MaskPiece GetMaskPiece()
	{
		if(_maskPiece.type ==  MaskPieceType.Face)
		{
			_maskPiece.element = (Element)selectedIndex;
		}
		else
		{
            _maskPiece.element = selectedIndex switch
            {
                0 or 1 or 2 => Element.Air,
                3 or 4 or 5 => Element.Water,
                6 or 7 or 8 => Element.Fire,
                9 or 10 or 11 => Element.Earth,
                _ => Element.Air,
            };
        }
		return _maskPiece;
	}
}
