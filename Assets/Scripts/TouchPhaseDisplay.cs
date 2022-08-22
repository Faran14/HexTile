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
    private Vector2 _originalPosition;
    private Vector2 _newPostion;
    private float _distance;
    public Node SingleHex;
    //public GameObject DoubleHex;

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

                float x = _camera.ScreenToWorldPoint(_touchEndPosition).x - _camera.ScreenToWorldPoint(_touchStartPosition).x;
                float y = _camera.ScreenToWorldPoint(_touchEndPosition).y - _camera.ScreenToWorldPoint(_touchStartPosition).y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    _direction = "Tapped";
                    if (_hitInfo.collider && _hitInfo.collider.CompareTag("Tile"))
                    {
                        Debug.Log("Found Tile");
                    }


                }

                else
                {
                    //_direction = x > 0 ? "Right" : "Left";
                    if (_hitInfo.collider && _hitInfo.collider.CompareTag("Tile"))
                    {

                        //if (x > 0)
                        //{
                        //    //move right
                        //    Debug.Log("Tile Right");
                        //}
                        //else
                        //{ //move left
                        //    Debug.Log("Tile Left");
                        //}
                        Debug.Log("Tile Move");
                        _originalPosition = _hitInfo.collider.transform.localPosition;
                        Debug.Log(_originalPosition);
                        _newPostion.x = _originalPosition.x + (x);
                        _newPostion.y = _originalPosition.y + (y);
                        
                        Debug.Log(_newPostion);
                        _distance = Vector2.Distance(_originalPosition, _newPostion);
                        if (_newPostion.x<4.5 && _newPostion.x>-0.5 && _newPostion.y>-4.5 && _newPostion.y<4.4 )
                        {

                            //_hitInfo.collider.transform.position = Vector3.Lerp(_originalPosition, _postion, Time.deltaTime*2+_distance);
                            SingleHex.Move(_originalPosition,_newPostion,_distance);
                        }
                    }
                }

                //else
                //{
                //    //_direction = y > 0 ? "Up" : "Down";
                //    if (_hitInfo.collider && _hitInfo.collider.CompareTag("Tile"))
                //    {

                //        if (y > 0)
                //        {
                //            //move up
                //            Debug.Log("Tile Up");
                //        }
                //        else
                //        { //move down
                //            Debug.Log("Tile Down");
                //        }
                //    }
                //}
            }


        }

        DirectionText.text = _direction;

    }


    //private void Move()
    //{

    //}
}
