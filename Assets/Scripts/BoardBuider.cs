using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBuider : MonoBehaviour
{
    [SerializeField] private GameObject HexPrefab;
    private float _xOffset;
    private float _yOffset;
    public float SizeRows;
    public float SizeColumns;
    private Node H;
    public Dictionary<string, Node> HexDictionary = new Dictionary<string, Node>();
    private GameObject _pair;
    private GameObject _pair2;

    private void Start()
    {
        _xOffset = 1f;
        _yOffset = 0.866f;
        HexPlacer(SizeRows,SizeColumns);

    }
    private void HexPlacer(float SR, float SC)
    {
        for (int row=0; row<SR; row++)
        {
            for (int column=0; column<SC;column++)
            {
                float FinalRowPos = row * _xOffset;

                if (column%2==1)
                {
                    FinalRowPos =  FinalRowPos+ (_xOffset / 2);
                }
                if ((column % 2 == 1)&& (row== SR-1))
                {
                    continue;
                }

                GameObject Hex = (GameObject)Instantiate(HexPrefab, new Vector2(FinalRowPos, column * _yOffset), Quaternion.identity);
                Hex.name = "Hex " + row + ", " + column;
                H = Hex.gameObject.GetComponent<Node>();
                H.SetCOOR(row,column);
                H.SetVal(0);
                H.SetPos(new Vector2(FinalRowPos, column* _yOffset));
                Hex.transform.SetParent(this.transform);
                HexDictionary.Add(Hex.name, H);
            }

        }
    }

    public Vector3 GetNearest(Vector2 pos)
    {
        
        foreach (var pair in HexDictionary)
        {
            float distance = Vector2.Distance(pos, pair.Value.Position);
            if (distance < 0.5f && pair.Value.state == false)
            {
                Vector2 loc = pair.Value.Position;
               
                //pair.Value.state = true;
                
                return loc;
            }
            
        }

        return new Vector3(2f, -4f, 0f);
    }
    public void HighLight(Vector2 pos)
    {
        foreach (var pair in HexDictionary)
        {
            float distance = Vector2.Distance(pos, pair.Value.Position);
            if (distance < 0.5f && pair.Value.state == false)
            {
                //Vector2 loc = pair.Value.Position;
                pair.Value.GetComponent<SpriteRenderer>().color = Color.green;
                //pair.Value.state = true;
                //return loc;
            }
            if (distance >= 0.5f)
            {
                pair.Value.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        //return new Vector3(2f, -4f, 0f);
    }
    public void HighLightTwin(Vector2 pos, Vector2 delta)
    {
        Node TileOne=null;
        Node TileTwo=null;


        foreach (var pair in HexDictionary)
        {
            float distance = Vector2.Distance(pos, pair.Value.Position);
            
            
            if (distance < 0.5f && pair.Value.state == false)
            {
                TileOne = pair.Value;
                foreach (var pair2 in HexDictionary)
                {
                    if (TileOne != pair2.Value)
                    { 
                        if (((pair2.Value.Position - (Vector2)(pos + delta)).magnitude < 0.45f) && pair2.Value.state == false)
                        {
                                TileTwo = pair2.Value;
                                break;
                        }
                        
                    }
                }

                break;
            }
          
        }
        
        foreach(var pair in HexDictionary)
        {
            if (TileOne != null && TileTwo != null && (pair.Value == TileOne || pair.Value == TileTwo) )
            {
                //Vector2 loc = pair.Value.Position;
                pair.Value.GetComponent<SpriteRenderer>().color = Color.green;
                //pair.Value.state = true;
                //return loc;
            }
            else
            {
                pair.Value.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        //return new Vector3(2f, -4f, 0f);
    }

}
