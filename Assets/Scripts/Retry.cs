using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    [SerializeField] private InputFlag _inputFlag;
    [SerializeField] private AdHandler _adHandler;
   
    [SerializeField] private GameObject _failPop;
   
    public void Start()
    {

       
        _failPop.SetActive(false);
    }
    public void retry()
    {
        _inputFlag.SetFlag(true);
        SceneManager.LoadScene(2);
    }
    public void Adretry()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
           retry();

            return;
        }
        _adHandler.InterAd(retry, _failPop);
    }
    public void exit()
    {
        
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            exitHelper();
            
            return;
        }
        _adHandler.InterAd(exitHelper, _failPop);
       
    }
    public void exitHelper()
    {
        _inputFlag.SetFlag(true);
        SceneManager.LoadScene(1);
    }

}
