using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour, IInputState
{
    InputState _state;
    public Vector2 ScreenPos;
    public Vector2 WorldPos;
    private Touch _touch;
    private IInput _input;


    public void Initialize(Tray input)
    {
        _input = input;
        ChangeState(new IdleInputState(this, input));
    }

    public void ChangeState(InputState state)
    {
        _state = state;
    }

   
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase==TouchPhase.Began)
            {
                //Debug.Log("Touch Begin");
                _state.Begin();
            }
            else if (_touch.phase== TouchPhase.Moved)
            {
                //Debug.Log("Touch Move");
                _state.Move();
            }
            else if (_touch.phase == TouchPhase.Ended)
            {
                //Debug.Log("Touch End");
                _state.End();
            }


        }

    }
}
