using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AdTimer", menuName = "ScriptableObjects/AdTimer", order =1)]
public class AdTimer : ScriptableObject
{
    [SerializeField] private float Timer;

    public void SetTimer(long timer)
    {
        Debug.LogError(timer + "Time value");
        Timer = timer;
    }
    public float GetTimer()
    {
        Debug.LogError(Timer+ "Getter value");
        return Timer;
    }
}
