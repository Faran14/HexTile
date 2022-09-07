using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AdTimer", menuName = "ScriptableObjects/AdTimer", order =1)]
public class AdTimer : ScriptableObject
{
    public long _timer=0;

    public void SetTimer(long Timer)
    {
        _timer = Timer;
    }
    public long GetTimer()
    {
        return _timer;
    }
}
