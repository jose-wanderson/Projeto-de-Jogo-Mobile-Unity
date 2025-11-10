using UnityEngine;
using UnityEngine.Advertisements;

public class Interstitial : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    public static Interstitial instance;
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    string _adUnitId;

    void Awake()
    {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            // Get the Ad Unit ID for Android:
            _adUnitId = _androidAdUnitId;
    }

    void Start()
    {
        // Chama automaticamente o anúncio ao iniciar o jogo:
        LoadAndShowAd();
    }

    public void LoadAndShowAd()
    {
        LoadAd();
        ShowAd();
    }

    // Método para carregar o anúncio:
    void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // Método para mostrar o anúncio:
    void ShowAd()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }

    // Implement Load Listener e Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
}