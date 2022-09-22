using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

[CreateAssetMenu(fileName = "IAPItem", menuName = "ScriptableObjects/IAPItem", order = 1)]
public class IAPItem : ScriptableObject
{
    [SerializeField] public string SKU;
    [SerializeField] public string Title;
    [SerializeField] public float Price;
    [SerializeField] public List<Rewards> RewardList;
    [SerializeField] public GameObject Prefab;
    public ProductType ProductType;
    public Product Product;
    ProductDefinition _productDefinition;
    public ProductDefinition ProductDefinition
    {
        get
        {
            if (_productDefinition == null)
            {
                _productDefinition = new ProductDefinition(SKU, ProductType);
            }
            return _productDefinition;
        }
    }
}
