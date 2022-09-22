using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    [SerializeField] private IAPPowerUp _coin;
    [SerializeField] private TMP_Text _text;

    private void Update()
    {
        _text.text = _coin.GetAmount().ToString();
    }
}
