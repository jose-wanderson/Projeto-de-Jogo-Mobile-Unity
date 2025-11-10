using UnityEngine;
using UnityEngine.Advertisements;

public class Banner : MonoBehaviour
{

    public static Banner instance;
    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;
    [SerializeField] string _androidAdUnitId = "Banner_Android";
    string _adUnitId = null;

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

        // Configurar o ID do anúncio e a posição do banner
        _adUnitId = _androidAdUnitId;
        Advertisement.Banner.SetPosition(_bannerPosition);

        // Carregar e exibir o banner automaticamente ao iniciar a Cena 0
        
    }


    public void LoadAndShowBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(_adUnitId, options);
    }

    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowBannerAd();
    }

    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }

    void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        Advertisement.Banner.Show(_adUnitId, options);
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    void OnDestroy()
    {
        // Limpar se necessário
    }
}
