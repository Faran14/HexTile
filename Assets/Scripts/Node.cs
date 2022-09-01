using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public float X_COOR;
    public float Y_COOR;
    public int Value;
    public bool state;
    private SpriteRenderer _sP;
    public List<Sprite> SpriteList = new List<Sprite>();
    public Vector2 Position;
    public int _index;


    private int _originalSortingOrder;

    private void Start()
    {
        _sP = gameObject.GetComponent<SpriteRenderer>();
        state = false;
        _originalSortingOrder = _sP.sortingOrder;
        
    }

    public void SetCOOR(float x, float y)
    {
        X_COOR = x;
        Y_COOR = y;
    }
    public void SetVal(int v)
    {
        Value = v;
    }
    public void SetState(bool SS)
    {
        state = SS;
    }
    public void SetPos(Vector2 pos)
    {
        Position = pos;
    }


    public void UpgradeHelper()
    {
        if (Value + 1 < SpriteList.Count)
        {
            Value = Value + 1;
            Debug.Log("VAyfdwggd8e3hfi4fufg" + Value);
            Upgrade(Value);
        }
    }

    public void Upgrade(int type)    
    {
       
         _sP = gameObject.GetComponent<SpriteRenderer>();
        _sP.sprite = SpriteList[type];
        SetVal(type);
        


    }

    public void IncreaseSortingOrder()
    {
        SetSortingOrder(_sP.sortingOrder + 1);
    }

    public void SetSortingOrder(int sortingOrder)
    {
        _sP.sortingOrder = sortingOrder;
    }

    public void ResetSortingOrder()
    {
        SetSortingOrder(_originalSortingOrder);
    }

    public void SetIndex(int index)
    {
        _index = index;
    }

   public void VanishTheHex()
    {
        //transform.parent = null;
        transform.gameObject.SetActive(false);
        //Destroy(transform.gameObject);
    }

}
