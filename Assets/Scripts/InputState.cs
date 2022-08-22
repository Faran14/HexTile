using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputState
{
    public IInputState Listner;
    public IInput Input;

    public InputState(IInputState listener, IInput input)
    {
        Listner = listener;
        Input = input;
    }

    public abstract void Begin();
    public abstract void Move();
    public abstract void End();
 
}
