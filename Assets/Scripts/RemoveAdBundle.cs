using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RemoveAdBundle", menuName = "ScriptableObjects/RemoveAdBundle", order = 1)]
public class RemoveAdBundle : ScriptableObject
{
    private string _removeAdsID = "com.thunderzone.eye.noads";
    private string _title= "Remove Ads";
    private float _price = 2.99f;
}
