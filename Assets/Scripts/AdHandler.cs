using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdHandler : MonoBehaviour
{
    private const string MaxKey = "hlKffQFn1sKXRefAUUKG4o-i-OOURETonfImCKvE29oyDwftIiyhVZMlNNxwUFl8NgUmynX33XOEq5m09yb34Z";
    private const string RewardedAdUnit = "585f249ad115c420";
    private const string InterstitialAdUnit = "7d62e5180461f57a";
    private const string BannerAdUnit = "b56d58800dadb2d1";
    [SerializeField] private Tray _skipButton;
    [SerializeField] private Retry _exitButton;
    private int count = 0;
    [SerializeField] private AdTimer lastAdTimer;
    //this is temp

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

    private void Start()
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

        MaxSdk.InitializeSdk(adUnitIds);

        MaxSdk.LoadInterstitial(InterstitialAdUnit);
        MaxSdk.LoadRewardedAd(RewardedAdUnit);
    }

    private void OnDestroy()
    {
        
        MaxSdkCallbacks.OnSdkInitializedEvent -= OnMaxInitialized;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent -= OnRewardedAdReceivedRewardEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent -= OnInterstitialHiddenEvent;
    }


    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdkBase.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        Debug.LogError($"{reward.Amount} : {reward.Label}");
        //this call back fires two events on claim// need help
        //temp solution is count check
        
            _skipButton.SkipHelper();

       
    }
    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
        //LoadInterstitial();
        lastAdTimer.SetTimer(CurrentTime);
        MaxSdk.LoadInterstitial(InterstitialAdUnit);
        _exitButton.exit();
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
    
    public void RewardedAd()
    {
        //Debug.Log("IN function");
        MaxSdk.LoadRewardedAd(RewardedAdUnit);
        if (MaxSdk.IsRewardedAdReady(RewardedAdUnit))
        {
            MaxSdk.ShowRewardedAd(RewardedAdUnit);

        }
    }
    public void InterAd()
    {
        Debug.Log("IN function");
        MaxSdk.LoadInterstitial(InterstitialAdUnit);
        if (MaxSdk.IsInterstitialReady(InterstitialAdUnit))
        {
            if (lastAdTimer.GetTimer() + 30 < CurrentTime)
            {
                //Debug.LogError(lastAdTimer.GetTimer()) ;
                MaxSdk.ShowInterstitial(InterstitialAdUnit);

            }
            else
            {

                _exitButton.exit();
            }
        }

    }
}
