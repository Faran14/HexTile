using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleInputState : InputState
{
    public IdleInputState (IInputState listener,IInput input) : base(listener, input)
    {
        
    }

    override public void Begin()
    {
        //Debug.Log("Idle");
        Listner.ChangeState(new CallibrationInputState(this.Listner,this.Input));
    }

    public override void End()
    {
        //throw new System.NotImplementedException();
    }

    public override void Move()
    {
        //throw new System.NotImplementedException();
    }
}
