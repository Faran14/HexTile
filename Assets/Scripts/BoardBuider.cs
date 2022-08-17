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
                Hex.transform.SetParent(this.transform);
            }

        }
    }
}
