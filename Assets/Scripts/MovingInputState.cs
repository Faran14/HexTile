using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInputState : InputState
{
    public MovingInputState(IInputState listener, IInput input) : base(listener,input)
    {

    }
    public override void Begin()
    {
        //throw new System.NotImplementedException();
    }
    public override void Move()
    {
        //base.Move();
        //Drag Move
        //throw new System.NotImplementedException();
    }
    public override void End()
    {
        //base.End();
        //Drag End
        Listner.ChangeState(new IdleInputState(this.Listner, this.Input));
    }
}
