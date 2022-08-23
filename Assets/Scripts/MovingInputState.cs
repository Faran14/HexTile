using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInputState : InputState
{
    public MovingInputState(IInputState listener, IInput input) : base(listener,input)
    {

    }
    public override void Begin(Vector2 pos)
    {
        //throw new System.NotImplementedException();
    }
    public override void Move(Touch _touch)
    {
        //base.Move();
        //Drag Move
        //throw new System.NotImplementedException();
        Input.DragStart(_touch);
    }
    public override void End(Touch _touch)
    {
        //base.End();
        //Drag End
        //Input.DragEnd(_touch);
        Input.Snap(_touch);
        Listner.ChangeState(new IdleInputState(this.Listner, this.Input));
    }
}
