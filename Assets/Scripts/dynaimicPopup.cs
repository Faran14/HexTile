using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dynaimicPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private static dynaimicPopup _spawnedPrefab;

    public static void ShowRestorePop(string ptext, dynaimicPopup prefab)
    {
        if (_spawnedPrefab == null)
        {
            _spawnedPrefab = Instantiate(prefab);
            _spawnedPrefab.Init(ptext);
        }
        else
        {
            _spawnedPrefab.Init(ptext);
        }
    }

    private void Init(string text)
    {
        _text.text = text;
        transform.gameObject.SetActive(true);
    }

    public void CloseButton()
    {
        transform.gameObject.SetActive(false);
    }

}
