using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string androidGameID;
    [SerializeField] string IOSGameID;
    [SerializeField] bool testMode = true;
    [SerializeField] bool enablePerPlacementMode = true;
    private string gameID;


    void Awake()
    {
        InitializeAds();
    }
    public void InitializeAds()
    {
        gameID = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? IOSGameID
            : androidGameID;
        Advertisement.Initialize(gameID, testMode, enablePerPlacementMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads Initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
