using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
	public static SpriteLoader instance;

	Sprite[] maskCROWNSprites;
	Sprite[] maskFACESprites;
	Sprite[] maskTEETHSprites;


	private void Awake()
	{
		if (instance == null)
			instance = this;
        //DontDestroyOnLoad(this);
		maskCROWNSprites = Resources.LoadAll<Sprite>("Sprites/maskCROWNSpriteAtlas");
        maskFACESprites = Resources.LoadAll<Sprite>("Sprites/maskFACESpriteAtlas");
        maskTEETHSprites = Resources.LoadAll<Sprite>("Sprites/maskTEETHSpriteAtlas");

        Debug.Log(maskTEETHSprites.Length);
		Debug.Log(maskFACESprites.Length);
		Debug.Log(maskCROWNSprites.Length);
    }

	public Sprite GetMaskSpriteByElementAndType(Element element, MaskPieceType type)
	{
		switch (type)
		{
			case MaskPieceType.Crown:
				{
					switch (element)
					{
						case Element.Air:
							return maskCROWNSprites[0];
						case Element.Water:
							return maskCROWNSprites[1];
						case Element.Fire:
							return maskCROWNSprites[2];
						case Element.Earth:
							return maskCROWNSprites[3];
						default:
							return null;
					}
				}
			case MaskPieceType.Face:
				{
					switch (element)
					{
						case Element.Air:
							return maskFACESprites[0];
						case Element.Water:
							return maskFACESprites[1];
						case Element.Fire:
							return maskFACESprites[2];
						case Element.Earth:
							return maskFACESprites[3];
						default:
							return null;
					}
				}
			case MaskPieceType.Teeth:
				{
					switch (element)
					{
						case Element.Air:
							return maskTEETHSprites[0];
						case Element.Water:
							return maskTEETHSprites[1];
						case Element.Fire:
							return maskTEETHSprites[2];
						case Element.Earth:
							return maskTEETHSprites[3];
						default:
							return null;
					}
				}
			default: return null;
		}
	}

	public Sprite[] GetMaskSpritesByType(MaskPieceType type)
	{
		switch (type)
		{
			case MaskPieceType.Crown:
				return maskCROWNSprites;
			case MaskPieceType.Face:
				return maskFACESprites;
			case MaskPieceType.Teeth:
				return maskTEETHSprites;
			default: return null;
		}
	}
}