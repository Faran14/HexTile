using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//public interface ITray 
//{
//    public void Tap();
//    public void DragStart();
//    public void DragEnd();
//    public void Snap();
//}


public interface IInput
{
    public void Tap();
    public void DragStart();
    public void DragEnd();
    public void Snap();
}
