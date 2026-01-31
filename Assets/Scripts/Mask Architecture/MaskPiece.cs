using System;
using UnityEngine;

[Serializable]
public class MaskPiece
{
    public MaskPieceType type;
    [HideInInspector] public Element element;
}
public enum MaskPieceType { Face, Teeth, Crown }
public enum Element { Air, Water, Fire, Earth }
public enum CooldownType { None,Fast, Medium, Slow }
