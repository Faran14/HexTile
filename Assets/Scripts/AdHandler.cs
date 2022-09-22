using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AdHandler", menuName = "ScriptableObjects/AdHandler", order = 1)]
public class AdHandler : ScriptableObject
{
    private const string MaxKey = "hlKffQFn1sKXRefAUUKG4o-i-OOURETonfImCKvE29oyDwftIiyhVZMlNNxwUFl8NgUmynX33XOEq5m09yb34Z";
    private const string RewardedAdUnit = "585f249ad115c420";
    private const string InterstitialAdUnit = "7d62e5180461f57a";
    private const string BannerAdUnit = "b56d58800dadb2d1";
    private int count = 0;
    public Float lastAdTimer;
    [SerializeField] private RewardHandler _rewardHandler;
    public Action RewardAction;
    public Action ExitAction;
    private int retryAttempt;
    [SerializeField] private GameObject failPopup;
    //this is temp
    //private void Awake()
    //{
    //    DontDestroyOnLoad(this);
    //}
    //[SerializeField] long lastAdTimer;

    [SerializeField]long CurrentTime
    {
        get
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }

    //showInterstitial()
    //{
    //    if (lastAdTimer + 30 < CurrentTime)
    //    {

    //    }
    //}

    //InterstitialHidden()
    //{
    //    lastAdTimer = CurrentTime;
    //}

    public void Initialze()
    {
        string[] adUnitIds = {
            // rewarded
            RewardedAdUnit,
            // interstitial
            InterstitialAdUnit,
            // banner
            BannerAdUnit

        };

        MaxSdk.SetSdkKey(MaxKey);
        MaxSdk.SetUserId(SystemInfo.deviceUniqueIdentifier);
        MaxSdk.SetVerboseLogging(true);
        MaxSdkCallbacks.OnSdkInitializedEvent += OnMaxInitialized;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdk.InitializeSdk(adUnitIds);

        MaxSdk.LoadInterstitial(InterstitialAdUnit);
        MaxSdk.LoadRewardedAd(RewardedAdUnit);
        
        
    }

    private void OnDestroy()
    {
        
        MaxSdkCallbacks.OnSdkInitializedEvent -= OnMaxInitialized;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent -= OnRewardedAdReceivedRewardEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent -= OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent -= OnInterstitialLoadFailedEvent;
    }


    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdkBase.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        Debug.LogError($"{reward.Amount} : {reward.Label}");
        //this call back fires two events on claim// need help
        //temp solution is count check
        lastAdTimer.SetValue(CurrentTime);
        MaxSdk.LoadRewardedAd(RewardedAdUnit);
        //_skipButton.SkipHelper();
        RewardAction?.Invoke();
        RewardAction = null;
        
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)
        //Debug.LogError("OnInterstitialLoadFailedEvent");
        retryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));
        Debug.LogError("No reward");
        failPopup.SetActive(true);
        //Invoke("LoadInterstitial", (float)retryDelay);
        MaxSdk.LoadInterstitial(InterstitialAdUnit);
        

    }
    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)
        //Debug.LogError("OnInterstitialLoadFailedEvent");
        retryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));
        failPopup.SetActive(true);
        //Invoke("LoadInterstitial", (float)retryDelay);
      
        MaxSdk.LoadRewardedAd(RewardedAdUnit);

    }


    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
        //LoadInterstitial();
        lastAdTimer.SetValue(CurrentTime);
        MaxSdk.LoadInterstitial(InterstitialAdUnit);
        //_exitButton.exit();
        ExitAction?.Invoke();
        ExitAction = null;
    }


    private void OnMaxInitialized(MaxSdkBase.SdkConfiguration sdkConfiguration)
    {
        if (MaxSdk.IsInitialized())
        {
            #if DEVELOPMENT_BUILD || UNITY_EDITOR
            MaxSdk.ShowMediationDebugger();
            #endif
            Debug.Log("MaxSDK initialized");
        }
        else
        {
            Debug.Log("Failed to init MaxSDK");
        }
    }
    
    public void RewardedAd(Action callBack, GameObject popup)
    {
        failPopup = popup;
        RewardAction = callBack;
        //Debug.Log("IN function");
        MaxSdk.LoadRewardedAd(RewardedAdUnit);
        if (MaxSdk.IsRewardedAdReady(RewardedAdUnit))
        {
            MaxSdk.ShowRewardedAd(RewardedAdUnit);

        }
    }
    public void InterAd(Action callBack, GameObject popup)
    {
        failPopup = popup;
        //failPopup.SetActive(false);
        ExitAction = callBack;
        //Debug.Log("IN function");
        MaxSdk.LoadInterstitial(InterstitialAdUnit);
        if (MaxSdk.IsInterstitialReady(InterstitialAdUnit))
        {
            if (lastAdTimer.GetValue() + 30 < CurrentTime && _rewardHandler.Check(RewardType.ad)== false)
            {
                //Debug.LogError(lastAdTimer.GetTimer()) ;
                MaxSdk.ShowInterstitial(InterstitialAdUnit);

            }
            else
            {

                //_exitButton.exit();
                ExitAction();
            }
        }

    }
}
