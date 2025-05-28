using System;
using UnityEngine;

public class TextHelper
{
    public enum Color
    {
        Red,
        Green,
        Grey
    }

    public static string Coloring(char c, Color color)
    {
        var res = "<color=";
        switch (color)
        {
            case Color.Green:
                res+= "#00ff00>" + c;
                break;
            case Color.Red:
                res+= "#ff0000>" + c;
                break;
            case Color.Grey:
                res+= "#808080>" + c;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(color), color, null);
        }

        res += "</color>";
        return res;
    }
}
