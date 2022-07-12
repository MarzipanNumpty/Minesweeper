using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string androidAdunityID = "Interstitial_Android";
    [SerializeField] string IOSAdUnitID = "Interstitial_iOS";
    string adUnitID;
    bool showAd;

    void Awake()
    {
        adUnitID = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? IOSAdUnitID
            : androidAdunityID;
    }

    public void LoadAd()
    {
        if(showAd)
        {
            Advertisement.Load(adUnitID, this);
        }
    }

    public void ShowAd()
    {
        if(showAd)
        {
            showAd = false;
            Advertisement.Show(adUnitID, this);
        }
        else
        {
            showAd = true;
        }
    }

    // Implement Load Listener and Show Listener interface methods:  
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        // Optionally execite code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Optionally execite code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState){    }
}
