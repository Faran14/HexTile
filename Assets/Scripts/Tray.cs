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
    private Vector3 _snapLocationNeighbour;
    private Vector2 _offSetPosition;
    private GameObject _child;
    public GameObject _hexHolder;// this is temp, only for testing
    [SerializeField] private GameObject HexPrefab;//testing
    private Vector2 _child1Pos;
    private Vector2 _child2Pos;
    private Vector2 _delta;
    private Node _node;

    private void Start()
    {
        _cam = Camera.main;
        _returnLocation =new Vector2 (2f, -4f);
        Spawn();

    }
    public void Initialize(BoardBuider board)
    {
        _board = board;
    }

    public void Tap()
    {
        HexTray.transform.Rotate(0f, 0f, -60f);
        _child = HexTray.transform.GetChild(0).gameObject;
        _child.transform.Rotate(0f, 0f, 60f);
        _child = HexTray.transform.GetChild(1).gameObject;
        _child.transform.Rotate(0f, 0f, 60f);
    }

    public void DragStart(Touch _touch)
    {
        //
        _offSetPosition = _cam.ScreenToWorldPoint(_touch.position);
        _offSetPosition.y = _offSetPosition.y + 1f;
        if (HexTray.transform.childCount > 1)
        {
            HexTray.transform.GetChild(0).GetComponent<Node>().IncreaseSortingOrder();
            HexTray.transform.GetChild(1).GetComponent<Node>().IncreaseSortingOrder();
            //Debug.Log("high");
            _board.HighLightTwin(HexTray.transform.GetChild(0).position, HexTray.transform.GetChild(1).position - HexTray.transform.GetChild(0).position);
            //_board.HighLight(HexTray.transform.GetChild(0).localPosition);
            //_board.HighLight(HexTray.transform.GetChild(1).localPosition);
        }
        else {
            //Debug.Log("low");
            HexTray.transform.GetChild(0).GetComponent<Node>().IncreaseSortingOrder();
            _board.HighLight(_offSetPosition); }


        _endLocation = _cam.ScreenToWorldPoint(_touch.position);
        _endLocation.y = _endLocation.y + 1f;
        _startLocation = HexTray.transform.localPosition;
        _distance = Vector2.Distance(_startLocation, _endLocation);
        HexTray.transform.localPosition = Vector3.Lerp(_startLocation,_endLocation, Time.deltaTime * 1 + _distance);
    }
    public void DragEnd(Touch _touch)
    {
        _startLocation = HexTray.transform.localPosition;
        _distance = Vector2.Distance(_startLocation, _returnLocation);
        HexTray.transform.localPosition= Vector3.Lerp(_startLocation, _returnLocation, Time.deltaTime * 2 + _distance);// remove lerp
    }
    public void SnapTwo(Touch _touch)
    {
        _child1Pos = HexTray.transform.GetChild(0).position;
        _child2Pos = HexTray.transform.GetChild(1).position;
        _delta = _child2Pos - _child1Pos;
    
        _snapLocation = (Vector3)_board.GetNearest(_child1Pos);
        _snapLocationNeighbour = _snapLocation + (Vector3)_delta;
        
        foreach(var pair2 in _board.HexDictionary)
        {
            if (((pair2.Value.Position - (Vector2)_snapLocation).magnitude < 0.45f) && pair2.Value.state == false)
            {
                _node = pair2.Value;
            }

        }

        foreach (var pair in _board.HexDictionary )
        {
           
            if (((pair.Value.Position - (Vector2)_snapLocationNeighbour).magnitude < 0.45f) && pair.Value.state == false)
            {
                //Debug.LogError(pair.Value);
                _node.SetState(true);
                pair.Value.SetState(true);

                HexTray.transform.GetChild(0).position = _snapLocation;
                HexTray.transform.GetChild(1).position = _snapLocationNeighbour;

                _child = HexTray.transform.GetChild(0).gameObject;//changing parent of tile
                _child.GetComponent<Node>().ResetSortingOrder();
                _child.transform.SetParent(_hexHolder.transform);
                _child = HexTray.transform.GetChild(0).gameObject;//changing parent of tile
                _child.GetComponent<Node>().ResetSortingOrder();
                _child.transform.SetParent(_hexHolder.transform);
                Spawn();
                break;
            }
            else { DragEnd(_touch); }
        }


    }
    public void Snap(Touch _touch)
    {
        if (HexTray.transform.childCount > 1)
        {
            //Debug.Log("twins");
            SnapTwo(_touch);
        }
        else
        {
            _offSetPosition = _cam.ScreenToWorldPoint(_touch.position);
            _offSetPosition.y = _offSetPosition.y + 1f;
            _snapLocation = (Vector3)_board.GetNearest(_offSetPosition);
            if (_snapLocation != new Vector3(2f, -4f, 0f))
            {
                HexTray.transform.position = _snapLocation;


                _child = HexTray.transform.GetChild(0).gameObject;//changing parent of tile
                _child.GetComponent<Node>().ResetSortingOrder();
                _child.transform.SetParent(_hexHolder.transform);


                Spawn();

            }
            else { DragEnd(_touch); }
            // make self child child of grid
        }
    }

    public void Raise(Touch _touch)
    {
        _endLocation = _cam.ScreenToWorldPoint(_touch.position);
        _endLocation.y = _endLocation.y + 1f;
        _startLocation = HexTray.transform.localPosition;
        _distance = Vector2.Distance(_startLocation, _endLocation);
        HexTray.transform.localPosition = Vector3.Lerp(_startLocation, _endLocation, Time.deltaTime * 2 + _distance);
    }

    public void Spawn()
    {
        var choice = Random.Range(0, 2);
        var Tile1 = Random.Range(0, 4);
        var Tile2 = Random.Range(0,4);
        Debug.Log(choice);
        if (choice > 0)
        {
            GameObject Hex = (GameObject)Instantiate(HexPrefab, new Vector2(2f, -4f), Quaternion.identity);//spawning new tile
            Hex.GetComponent<Node>().Upgrade(Tile1);
            Hex.transform.SetParent(HexTray.transform);
            HexTray.transform.position = new Vector2(2f, -4f);
            _child = HexTray.transform.GetChild(0).gameObject;
            _child.transform.localPosition = new Vector2(0f, 0f);
            

        }
        else
        {
            GameObject Hex = (GameObject)Instantiate(HexPrefab, new Vector2(2f, -4f), Quaternion.identity);//spawning new tile
            Hex.GetComponent<Node>().Upgrade(Tile1);
            Hex.transform.SetParent(HexTray.transform);
            GameObject Hex2 = (GameObject)Instantiate(HexPrefab, new Vector2(2f, -4f), Quaternion.identity);//spawning new tile
            Hex2.GetComponent<Node>().Upgrade(Tile2);
            Hex2.transform.SetParent(HexTray.transform);

            HexTray.transform.position = new Vector2(2f, -4f);

            _child = HexTray.transform.GetChild(0).gameObject;
            _child.transform.localPosition = new Vector2(0.5f, 0f);
            _child = HexTray.transform.GetChild(1).gameObject;
            _child.transform.localPosition = new Vector2(-0.5f, 0f);

            var turn = Random.Range(0, 3);

            for (int i =0; i <= turn; i++ )
            {
                Tap();
            }



        }

    }


}
