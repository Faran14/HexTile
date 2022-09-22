using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UM.Store;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private IAPstore _store;
    [SerializeField] private GameObject _page;
    [SerializeField] private GameObject _fail;
    [SerializeField] private GameObject _succ;
    [SerializeField] private GameObject _rV;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        var RV = Instantiate(_rV, new Vector3(0, 0, 0), Quaternion.identity);
        RV.transform.SetParent(_page.transform);
        foreach (var pair in _store.IAPItems)
        {
            var card = Instantiate(pair.Prefab, new Vector3(0, 0, 0), Quaternion.identity);
            card.transform.SetParent(_page.transform);
            card.transform.GetComponent<StoreButton>().Item = pair;
            
            card.transform.GetComponent<StoreButton>().intialize(_fail, _succ);
            //card.transform.position=(new Vector3(0, 0, 0));

        }
    }
}
