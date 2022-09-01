using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleInputState : InputState
{
    public IdleInputState (IInputState listener,IInput input) : base(listener, input)
    {
        
    }

    override public void Begin(Vector2 pos)
    {
        //Debug.Log("Idle");
        if (Vector2.Distance(new Vector2(2f, -4f), pos) <= 1)
        {
            Listner.ChangeState(new CallibrationInputState(this.Listner, this.Input));
        }
    }

    public override void End(Touch _touch)
    {
        //throw new System.NotImplementedException();
    }

    public override void Move(Touch _touch)
    {
        //throw new System.NotImplementedException();
    }
}
