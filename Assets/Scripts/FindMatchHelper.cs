using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMatchHelper : MonoBehaviour
{
    public const int Left= -5;
    //public const int TopLeft = 1;
    //public const int TopRight = 6;
    public const int Right = 5;
    //public const int BottomRight = 4;
    //public const int BottomLeft = -1;
    private int n = 0;


    public int TopLeft(int index)
    {
        n = index / 5;

        n = index - (n * 5);
        return n % 2 == 1 ? 1 : -4;
    }
    public int TopRight(int index)
    {
        n = index / 5;

        n = index - (n * 5);
        return n % 2 == 1 ? 6 : 1;
    }
    public int BottomLeft(int index)
    {
        n = index / 5;

        n = index - (n * 5);
        return n % 2 == 1 ? -1 : -6;
    }
    public int BottomRight(int index)
    {
        n = index / 5;

        n = index - (n * 5);
        return n % 2 == 1 ? 4 : -1;
    }

}
