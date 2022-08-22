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
    public Vector2 EndPos;


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



    public void Upgrade()    
    {
       
         _sP = gameObject.GetComponent<SpriteRenderer>();
        _sP.sprite = SpriteList[Value];
        


    }

    public void Move(Vector2 start, Vector2 end,float dis)
    {
        gameObject.transform.position = Vector3.Lerp(start, end, Time.deltaTime * 2 + dis);
    }

}
