using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] private InputFlag _inputFlag;
    public void close()
    {
        transform.gameObject.SetActive(false);
        _inputFlag.SetFlag(true);
    }
}
