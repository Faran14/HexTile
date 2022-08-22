using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallibrationInputState : InputState
{
    //private Tray _trayFunctions;
    public CallibrationInputState(IInputState listener, IInput input) : base(listener,input)
    {
        
    }

    public override void Begin()
    {
        //throw new System.NotImplementedException();
    }

    public override void End()
    {
        //base.End();
        //tap
        //Debug.Log("Callibrate End");
        Input.Tap();
        Listner.ChangeState(new IdleInputState(this.Listner, this.Input));
        
    }

    public override void Move()
    {
        //base.Move();
        //Debug.Log("Begun Moving");
        
        Listner.ChangeState(new MovingInputState(this.Listner, this.Input));
    }
}
