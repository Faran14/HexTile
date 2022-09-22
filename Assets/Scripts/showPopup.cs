using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showPopup : MonoBehaviour
{
    [SerializeField] private GameObject _exitpopup;
    [SerializeField] private GameObject _retrypopup;
    [SerializeField] private InputFlag _inputFlag;
    public void ShowExitPopUp()
    {
        _inputFlag.SetFlag(false);
        _exitpopup.SetActive(true);
    }
    public void ShowRetryPopup()
    {
        _inputFlag.SetFlag(false);
        _retrypopup.SetActive(true);
    }
}
