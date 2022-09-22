using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rewards // rename
{
    public int Amount;
    public GameObject Icon;
    public RewardType RewardType;

    public void SetReward(int amount, GameObject icon, RewardType type)
    {
        Amount = amount;
        Icon = icon;
        RewardType = type;

    }
}

public enum RewardType // rename 
{
    coin,
    skip,
    ad
    
}