using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
	public static SpriteLoader instance;

	[SerializeField] Sprite[] MASKS;

	[SerializeField] Sprite[] maskCROWNSprites;
    [SerializeField] Sprite[] maskFACESprites;
    [SerializeField] Sprite[] maskTEETHSprites;


    void Awake()
    {
        if (instance == null)
            instance = this;

        maskCROWNSprites = new Sprite[12];
        maskFACESprites = new Sprite[4];
        maskTEETHSprites = new Sprite[12];

        PopulateArrays();
    }


    void PopulateArrays()
    {
        MASKS = Resources.LoadAll<Sprite>("Sprites/masks");

        foreach (var s in MASKS)
        {
            var parts = s.name.Split('_');

            Element element = (Element)System.Enum.Parse(typeof(Element), parts[1],ignoreCase: true);
            MaskPieceType type = (MaskPieceType)System.Enum.Parse(typeof(MaskPieceType), parts[2],ignoreCase: true);

            int elementIndex = (int)element;

            if (type == MaskPieceType.Face)
            {
                maskFACESprites[elementIndex] = s;
            }
            else
            {
                int variant = int.Parse(parts[3]);
                int index = elementIndex * 3 + variant;

                if (type == MaskPieceType.Crown)
                    maskCROWNSprites[index] = s;
                else if (type == MaskPieceType.Teeth)
                    maskTEETHSprites[index] = s;
            }
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

            default:
                return null;
        }
    }



    public Sprite GetFace(Element e)
    {
        return maskFACESprites[(int)e];
    }

    public Sprite GetCrown(Element e, int variant = 0)
    {
        return maskCROWNSprites[(int)e * 3 + variant];
    }

    public Sprite GetTeeth(Element e, int variant = 0)
    {
        return maskTEETHSprites[(int)e * 3 + variant];
    }


}