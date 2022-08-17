using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public float X_COOR;
    public float Y_COOR;
    public int Value;
    private SpriteRenderer _sP;
    List<Sprite> SpriteList = new List<Sprite>();


    public void SetCOOR(float x, float y)
    {
        X_COOR = x;
        Y_COOR = y;
    }
    public void SetVal(int v)
    {
        Value = v;
    }
    

    public void Upgrade()    
    {
       
         _sP = gameObject.GetComponent<SpriteRenderer>();
        _sP.sprite = SpriteList[Value];
        


    }
}
