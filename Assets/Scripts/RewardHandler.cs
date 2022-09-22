using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RewardHandler", menuName = "ScriptableObjects/RewardHandler")]
public class RewardHandler : ScriptableObject
{
    
    [SerializeField] private bool _removeAds;
    [SerializeField] private IAPPowerUp _coin;
    [SerializeField] private IAPPowerUp _skip;
    

    public void GiveReward(IAPItem pack)
    {
        foreach(var item in pack.RewardList)
        {
            if (item.RewardType == RewardType.coin)
            {
                _coin.AddAmount(item.Amount);
            }
            if (item.RewardType == RewardType.skip)
            {
                _skip.AddAmount(item.Amount);
            }
            if (item.RewardType == RewardType.ad)
            {
                _removeAds = true;
            }
        }
        
    }
    public bool Check(RewardType type)
    {
        if (type == RewardType.ad)
        {
            return _removeAds;

        }
        return false;
    }
    
}
