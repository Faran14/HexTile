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
    public void DragStart(Touch _touch);
    public void DragEnd(Touch _touch);
    public void Snap(Touch _touch);
    public void Raise(Touch _touch);
    public void SnapTwo(Touch _touch);
    public void Spawn();

}
