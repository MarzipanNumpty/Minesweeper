using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string androidAdUnitId = "Rewarded_Android";
    [SerializeField] string iOsAdUnitId = "Rewarded_iOS";
    string _adUnitId;
    [SerializeField] GameObject boardGameObject;
    private boardGenerator boardScript;

    private void Awake()
    {
        {
            boardScript = boardGameObject.GetComponent<boardGenerator>();
            _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? iOsAdUnitId
                : androidAdUnitId;
        }
    }

    public void LoadAd()
    {
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState listener)
    {
        Debug.Log("Unity Ads Rewarded Ad Completed");
        if (adUnitId.Equals(adUnitId) && listener.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Complete Level");
            boardScript.checkNumbers(true);
        }
        else
        {
            Debug.Log("is anybody there?");
        }
    }

    /*public void OnUnityAdsShowComplete(string adUnitIdSpec, UnityAdsShowCompletionState showCompletionState)
    {
        if(adUnitIdSpec.Equals(adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Complete Level");
            boardScript.checkNumbers(true);
        }
        else
        {
            Debug.Log("is anybody there?");
        }
    }*/

    public void OnUnityAdsLoaded(string adUnitIdSpec)
    {

    }

    public void OnUnityAdsFailedToLoad(string adUnitIdSpec, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitIdSpec}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitIdSpec, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitIdSpec}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitIdSpec) {
        Debug.Log("start");
    }
    public void OnUnityAdsShowClick(string adUnitIdSpec) { }

    public void OnUnityAdsAdLoaded(string adUnitIdSpec)
    {
        Debug.Log("load");
    }
}
