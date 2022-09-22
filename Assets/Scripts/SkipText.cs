using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SkipText : MonoBehaviour
{
    [SerializeField] private IAPPowerUp _skip;
    [SerializeField] private TMP_Text _text;

    private void Update()
    {
        _text.text = _skip.GetAmount().ToString();
    }
}
