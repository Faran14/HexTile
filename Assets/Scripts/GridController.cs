using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : FindMatchHelper
{
    [SerializeField]private Node[] _hexArray = new Node[25];
    [SerializeField]private List<int> _IndexList= new List<int>();
    private bool _match = false;
    private int _matchCount;
    private BoardBuider _board;
    private bool _casHelper;
    [SerializeField]private GameObject _failImage;
    [SerializeField] private InputFlag _inputFlag;
    
    public void Start()
    {
        //for (int i=0; i<25; i++)
        //{
        //    __hexArray[i] = null;
        //}
        _matchCount = 0;
        _failImage.SetActive(false);

    }
    
    public void Initialize(BoardBuider board)
    {
        _board = board;
    }

    public void SetHex(Node Hex, int index)
    {
        _hexArray[index] = Hex;
    }

    public bool LevelFail()
    {
        foreach (var pair in _board.HexDictionary)
        {
            if (pair.Value.state == false)
            {
                return false;
            }
        }

        return true;
    }
    public void MatchThreeHelper(int index)
    {
        //Debug.Log("before loop");
        MatchThree(index);
        //Debug.Log("After loop");
        if (_IndexList.Count > 2)
        {
            Debug.Log("Match" + _IndexList.Count);
            //animation
            MergeAnimation();
            //will explode

            //if (_casHelper == false)
            //{
            //    _casHelper = true;
            //    MatchThreeHelper(_IndexList[0]);
            //}
            
        }

        _casHelper = false;
        _matchCount = 0;
        //_casHelper = _IndexList[0];
        _IndexList.Clear();
        if (LevelFail())
        {
            Debug.Log("Fail");
            _inputFlag.SetFlag(false);
            _failImage.SetActive(true);
        }
        else
        {
            Debug.Log("Succ");
        }
        


    }

    public void MergeAnimation()
    {
        _hexArray[_IndexList[0]].UpgradeHelper();
        foreach (var pair in _IndexList)
        {
            if (pair != _IndexList[0])
            {
                //continue;
                foreach(var pair2 in _board.HexDictionary)
                {
                    if (pair2.Value._index == pair)
                    {
                        pair2.Value.SetState(false);
                    }

                }

                _hexArray[pair].VanishTheHex();
                _hexArray[pair] = null;

            }
            
            //lerp


        }

    }
    public void MatchThree(int index)
    {

        _IndexList.Add(index);
        _match = false;
        //if (_IndexList.Contains(index) || _hexArray[index]==null)
        //{

        //    return;
        //}
        if (_hexArray[index] == null)
        {
            return;
        }
        if (index + Left >= 0 && index + Left <= 24)
        {
            Debug.Log("leftstart");
            if (!_IndexList.Contains(index + Left))
            {
                if (_hexArray[index + Left] != null && _hexArray[index].Value == _hexArray[index + Left].Value )
                {
                    if ((_hexArray[index + Left].Y_COOR <= _hexArray[index].Y_COOR +1)&& (_hexArray[index + Left].Y_COOR >= _hexArray[index].Y_COOR - 1))
                    {
                        Debug.Log("left");

                        _match = true;
                        _matchCount = _matchCount + 1;

                        MatchThree(index + Left);
                    }
                    
                }
            }
        }
        
        if (index + TopLeft(index) >= 0 && index + TopLeft(index) <= 24)
        {
            if (!_IndexList.Contains(index + TopLeft(index)))
                {
                if (_hexArray[index + TopLeft(index)] != null && _hexArray[index].Value == _hexArray[index + TopLeft(index)].Value)
                {
                    if ((_hexArray[index + TopLeft(index)].Y_COOR <= _hexArray[index].Y_COOR + 1) && (_hexArray[index + TopLeft(index)].Y_COOR >= _hexArray[index].Y_COOR - 1))
                    {
                        _match = true;
                        _matchCount = _matchCount + 1;

                        MatchThree(index + TopLeft(index));
                    }
                }
            }
        }
        
        if (index + TopRight(index) > 0 && index + TopRight(index) <= 24)
        {
            if (!_IndexList.Contains(index + TopRight(index)))
            {
                if (_hexArray[index + TopRight(index)] != null && _hexArray[index].Value == _hexArray[index + TopRight(index)].Value )
                {
                    if ((_hexArray[index + TopRight(index)].Y_COOR <= _hexArray[index].Y_COOR + 1) && (_hexArray[index + TopRight(index)].Y_COOR >= _hexArray[index].Y_COOR - 1))
                    {
                        _match = true;
                        _matchCount = _matchCount + 1;

                        MatchThree(index + TopRight(index));
                    }
                }
            }
        }
       
        if (index + Right <= 24 && index + Right >= 0)
        {
            if (!_IndexList.Contains(index + Right))
            {
                if (_hexArray[index + Right] != null && _hexArray[index].Value == _hexArray[index + Right].Value )
                {
                    if ((_hexArray[index + Right].Y_COOR <= _hexArray[index].Y_COOR + 1) && (_hexArray[index + Right].Y_COOR >= _hexArray[index].Y_COOR - 1))
                    {
                        _match = true;
                        _matchCount = _matchCount + 1;

                        MatchThree(index + Right);
                    }
                }
            }
        }
       
        if (index + BottomRight(index) >= 0 && index + BottomRight(index) <= 24)
        {
            if (!_IndexList.Contains(index + BottomRight(index)))
            {
                if (_hexArray[index + BottomRight(index)] != null && _hexArray[index].Value == _hexArray[index + BottomRight(index)].Value )
                {
                    if ((_hexArray[index + BottomRight(index)].Y_COOR <= _hexArray[index].Y_COOR + 1) && (_hexArray[index + BottomRight(index)].Y_COOR >= _hexArray[index].Y_COOR - 1))
                    {
                        _match = true;
                        _matchCount = _matchCount + 1;

                        MatchThree(index + BottomRight(index));
                    }
                }
            }
        }
        if (index + BottomLeft(index) <= 24 && index + BottomLeft(index) >= 0)
        {
            if (!_IndexList.Contains(index + BottomLeft(index)))
            {
                if (_hexArray[index + BottomLeft(index)] != null && _hexArray[index].Value == _hexArray[index + BottomLeft(index)].Value )
                {
                    if ((_hexArray[index + BottomLeft(index)].Y_COOR <= _hexArray[index].Y_COOR + 1) && (_hexArray[index + BottomLeft(index)].Y_COOR >= _hexArray[index].Y_COOR - 1))
                    {
                        _match = true;
                        _matchCount = _matchCount + 1;

                        MatchThree(index + BottomLeft(index));
                    }
                }
            }
        }

        if (_match == false)//base case
        {
            
            return;
        }

    }

}
