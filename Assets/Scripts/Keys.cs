using System;
using UnityEngine;
using System.Collections.Generic;

[Obsolete]
public enum Key
{
    Up,
    Down,
    Left,
    Right,
    Fire,
    Dash
}
[Obsolete]
public static class Keys
{
    public static Dictionary<Key, KeyCode> Player1Keys = new Dictionary<Key, KeyCode>()
    {
        { Key.Up, KeyCode.W },
        { Key.Down, KeyCode.S },
        { Key.Left, KeyCode.A },
		{ Key.Right, KeyCode.D },
		{ Key.Dash, KeyCode.Q },
		{ Key.Fire, KeyCode.E },
	};

	public static Dictionary<Key, KeyCode> Player2Keys = new Dictionary<Key, KeyCode>()
	{
		{ Key.Up, KeyCode.UpArrow },
		{ Key.Down, KeyCode.DownArrow },
		{ Key.Left, KeyCode.LeftArrow },
		{ Key.Right, KeyCode.RightArrow },
		{ Key.Dash, KeyCode.RightShift },
		{ Key.Fire, KeyCode.Return },
	};
}
