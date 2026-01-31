using System;

[Serializable]
public class MaskPiece
{
    public MaskPieceType type;
    public Element element;
}
public enum MaskPieceType { Face, Teeth, Crown }
public enum Element { Fire, Water, Air, Earth }
public enum CooldownType { Fast, Medium, Slow }
