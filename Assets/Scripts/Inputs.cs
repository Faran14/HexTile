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
    private Vector2 _touchArea;
    private Camera _cam;
    [SerializeField] private InputFlag _inputFlag; 

    public void Initialize(Tray input)
    {
        _input = input;
        _cam = input._cam;
        ChangeState(new IdleInputState(this, input));
    }

    public void ChangeState(InputState state)
    {
        _state = state;
    }

   
    public void Update()
    {
        if (_inputFlag.GetFlag() == true)
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                _touchArea = _cam.ScreenToWorldPoint(_touch.position);
                if (_touch.phase == TouchPhase.Began)
                {
                    //Debug.Log("Touch Begin");
                    _state.Begin(_touchArea);
                }
                else if (_touch.phase == TouchPhase.Moved)
                {
                    //Debug.Log("Touch Move");
                    _state.Move(_touch);
                }
                else if (_touch.phase == TouchPhase.Ended)
                {
                    //Debug.Log("Touch End");
                    _state.End(_touch);
                }


            }
        }

    }
}
