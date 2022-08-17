using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchPhaseDisplay : MonoBehaviour
{
    public TMP_Text DirectionText;
    private Touch _theTouch;
    private string _direction;
    private Vector2 _touchStartPosition, _touchEndPosition;
    public Vector2 _postion;
    private Camera _camera;
    private RaycastHit2D _hitInfo;

    private void Start()
    {
        _camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            _theTouch = Input.GetTouch(0);
            if (_theTouch.phase == TouchPhase.Began)
            {
                _touchStartPosition = _theTouch.position;
                _postion = _camera.ScreenToWorldPoint(_touchStartPosition);
                _hitInfo = Physics2D.Raycast(_postion, _camera.transform.forward, Mathf.Infinity);
                if (!_hitInfo.collider)
                {
                    Debug.Log("WAAAAAAAAAAH COLLIDER NOT DETECTED!!!!!!");
                    return;
                }
                
            }
            
            else if (_theTouch.phase == TouchPhase.Moved || _theTouch.phase == TouchPhase.Ended)
            {
                _touchEndPosition = _theTouch.position;

                float x = _touchEndPosition.x - _touchStartPosition.x;
                float y = _touchEndPosition.y - _touchStartPosition.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    _direction = "Tapped";
                }

                else if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    _direction = x > 0 ? "Right" : "Left";
                }

                else
                {
                    _direction = y > 0 ? "Up" : "Down";
                }
            }


        }

        DirectionText.text = _direction;

    }
}
