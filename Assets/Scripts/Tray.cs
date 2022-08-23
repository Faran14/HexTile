using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, IInput
{
    public GameObject HexTray;
    private float _distance;
    private Vector2 _startLocation;
    private Vector2 _endLocation;
    public Camera _cam;
    private Vector2 _returnLocation;
    private BoardBuider _board;
    private Vector3 _snapLocation;
    private Vector2 _offSetPosition;

    private void Start()
    {
        _cam = Camera.main;
        _returnLocation =new Vector2 (2f, -4f);
    }
    public void Initialize(BoardBuider board)
    {
        _board = board;
    }

    public void Tap()
    {
        HexTray.transform.Rotate(0f, 0f, 60f);
        var _child = HexTray.transform.GetChild(0);
        _child.transform.Rotate(0f, 0f, -60f);
    }
    public void DragStart(Touch _touch)
    {
        _endLocation = _cam.ScreenToWorldPoint(_touch.position);
        _endLocation.y = _endLocation.y + 1f;
        _startLocation = HexTray.transform.localPosition;
        _distance = Vector2.Distance(_startLocation, _endLocation);
        HexTray.transform.localPosition = Vector3.Lerp(_startLocation,_endLocation, Time.deltaTime * 2 + _distance);
    }
    public void DragEnd(Touch _touch)
    {
        _startLocation = HexTray.transform.localPosition;
        _distance = Vector2.Distance(_startLocation, _returnLocation);
        HexTray.transform.localPosition= Vector3.Lerp(_startLocation, _returnLocation, Time.deltaTime * 2 + _distance);
    }
    public void Snap(Touch _touch)
    {
        _offSetPosition = _cam.ScreenToWorldPoint(_touch.position);
        _offSetPosition.y = _offSetPosition.y + 1f;
        _snapLocation = (Vector3)_board.GetNearest(_offSetPosition);
        if (_snapLocation != new Vector3(2f,-4f,0f))
        {
            HexTray.transform.position = _snapLocation;
        }
        else { DragEnd(_touch); }
        // make self child child of grid
    }
    //public void MoveAboveTouch()
    //{ }
    public void Raise(Touch _touch)
    {
        _endLocation = _cam.ScreenToWorldPoint(_touch.position);
        _endLocation.y = _endLocation.y + 1f;
        _startLocation = HexTray.transform.localPosition;
        _distance = Vector2.Distance(_startLocation, _endLocation);
        HexTray.transform.localPosition = Vector3.Lerp(_startLocation, _endLocation, Time.deltaTime * 2 + _distance);
    }


}
