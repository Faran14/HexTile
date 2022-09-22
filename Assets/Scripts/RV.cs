using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RV : MonoBehaviour
{
    [SerializeField] IAPPowerUp _coin;
    [SerializeField] TMP_Text _text;
    [SerializeField] int amount;
    [SerializeField] AdHandler _adHandler;
    [SerializeField] GameObject _failPop;
    private int count;

    private void Start()
    {
        count = 0;
        _text.text = amount.ToString();
        _adHandler.Initialze();
    }


    public void reward()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            if (count== 0)
            {
                Debug.LogError("iehfiou");
                var fp = Instantiate(_failPop, GetComponentInParent<Canvas>().transform);
                _failPop = fp;
                count = count + 1;
            }
            else
            {
                _failPop.SetActive(true);
            }

            return;
        }
        _adHandler.RewardedAd(rewardHelper, _failPop);
    }

    public void rewardHelper()
    {
        
        _coin.AddAmount(100);
    }





}
