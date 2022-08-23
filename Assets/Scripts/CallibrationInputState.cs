using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallibrationInputState : InputState
{
    //private Tray _trayFunctions;
    public CallibrationInputState(IInputState listener, IInput input) : base(listener,input)
    {
        
    }

    public override void Begin(Vector2 pos)
    {
        //throw new System.NotImplementedException();
    }

    public override void End(Touch _touch)
    {
        //base.End();
        //tap
        //Debug.Log("Callibrate End");
        Input.Tap();
        Listner.ChangeState(new IdleInputState(this.Listner, this.Input));
        
    }

    public override void Move(Touch _touch)
    {
        //base.Move();
        //Debug.Log("Begun Moving");
        //Input.DragStart(_touch);
        Input.Raise(_touch);
        Listner.ChangeState(new MovingInputState(this.Listner, this.Input));
    }
}
