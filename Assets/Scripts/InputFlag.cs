using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputFlag", menuName = "ScriptableObjects/InputFlag", order = 1)]
public class InputFlag : ScriptableObject
{
    public bool IFlag = true;

    public void SetFlag(bool flag)
    {
        IFlag = flag;
    }
    public bool GetFlag()
    {
        return IFlag;
    }
}
