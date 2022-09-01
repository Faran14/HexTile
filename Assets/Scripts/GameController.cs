using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Inputs _IS;
    [SerializeField] private Tray _TS;
    [SerializeField] private BoardBuider _BB;
    [SerializeField] private GridController _GC;

    private void Start()
    {
        _IS.Initialize(_TS);
        _TS.Initialize(_BB,_GC);
        _GC.Initialize(_BB);
    }
}
