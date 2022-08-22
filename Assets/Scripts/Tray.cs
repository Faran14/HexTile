using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, IInput
{
    public GameObject HexTray;

    public void Tap()
    {
        HexTray.transform.Rotate(0f, 0f, 60f);
    }
    public void DragStart()
    {
        //
    }
    public void DragEnd()
    { }
    public void Snap()
    {
        // make self child child of grid
    }

}
