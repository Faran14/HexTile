using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UM.Store;
using TMPro;
using System;

public class StoreButton : MonoBehaviour, IItemPurchase
{
    public IAPItem Item;
    public IAPstore Store;
    [SerializeField] private RewardHandler _rewardHandler;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private GameObject _grid;
    [SerializeField] private GameObject _failMsg;
    [SerializeField] private GameObject _successMsg;
    [SerializeField] private AdHandler _adHandler;

    [SerializeField]
    long CurrentTime
    {
        get
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
    public void intialize(GameObject _fail,GameObject _succ)
    {
        _failMsg = _fail;
        _successMsg = _succ;
        _name.SetText(Item.Title);
        _price.SetText("$ " + Item.Price.ToString());
        

        Item.Prefab.SetActive(true);
        foreach (var pair in Item.RewardList)
        {
            
            if (pair.RewardType == RewardType.ad)
            {
                if (Item.ProductType == UnityEngine.Purchasing.ProductType.NonConsumable && _rewardHandler.Check(pair.RewardType)==true)
                {
                    transform.gameObject.SetActive(false);
                    break;
                }
                continue;
            }
            if (pair.RewardType == RewardType.coin)
            {
                _coins.SetText(pair.Amount.ToString());
            }
            else
            {
                var Icon = Instantiate(pair.Icon, new Vector3(0, 0, 0), Quaternion.identity);
                Icon.transform.SetParent(_grid.transform);
                Icon.GetComponentInChildren<TMP_Text>().text =pair.Amount.ToString();
                
            }

        }
    }
    


    public void PurchaseFail(IAPItem iAPItem)
    {
        _failMsg.SetActive(true);
    }

    public void PurchaseSuccess(IAPItem iAPItem)
    {
        _adHandler.lastAdTimer.SetValue(CurrentTime);
        _rewardHandler.GiveReward(iAPItem);
        _successMsg.SetActive(true);
        if (Item.ProductType == UnityEngine.Purchasing.ProductType.NonConsumable)
        {
            
            transform.gameObject.SetActive(false);
           //Debug.LogError("done");
        }
    }

    public void MakePurchase()
    {
        Store.PurcahseItem(Item, this);
    }
}
