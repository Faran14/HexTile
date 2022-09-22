using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "IAPPower", menuName = "ScriptableObjects/IAPPower")]
public class IAPPowerUp : ScriptableObject
{
    [SerializeField] private int _count;
    [SerializeField] private string _key;
    

    private void Awake()
    {
        //get dat from prefs
       
        _count = PlayerPrefs.GetInt(_key);
        Debug.LogError(PlayerPrefs.GetInt(_key));
        
    }


    public int GetAmount()
    {
        return _count;
    }
    public void SetAmount(int i)
    {
        _count = i;
    }
    public void AddAmount(int i)
    {
        _count = _count + i;
        PlayerPrefs.SetInt(_key, _count);
        PlayerPrefs.Save();
        
    }
    public void RemoveAmount(int i)
    {
        
        _count = _count - i;
        PlayerPrefs.SetInt(_key, _count);
        PlayerPrefs.Save();
        
    }

}
