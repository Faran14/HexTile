using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : FindMatchHelper
{
    public Node[] _hexArray = new Node[25]; 

    public void Start()
    {
        for (int i=0; i<25; i++)
        {
            _hexArray[i] = null;
        }

    }

    public void SetHex(Node Hex, int index)
    {
        _hexArray[index] = Hex;
    }
    public void MatchThree()
    {
    }

}
