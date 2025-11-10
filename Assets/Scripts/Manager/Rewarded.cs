using UnityEngine;
using UnityEngine.Advertisements;

public class Rewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    public static Rewarded instance;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    string _adUnitId = null; // Isso permanecerá nulo para plataformas não suportadas

    private void Awake()
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
    
    _adUnitId = _androidAdUnitId;
    }

    // Chame este método público quando quiser preparar um anúncio para ser exibido automaticamente.
    public void ShowRewardedAdAutomatically()
    {
        // IMPORTANTE! Carregue o conteúdo APÓS a inicialização (neste exemplo, a inicialização é tratada em um script diferente).
        Debug.Log("Carregando Anúncio: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // Implementa um método para mostrar o anúncio automaticamente quando estiver carregado:
    private void ShowAdAutomatically()
    {
        Debug.Log("Mostrando Anúncio automaticamente");
        Advertisement.Show(_adUnitId, this);
    }

    // Callback de carregamento de anúncio:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Anúncio Carregado: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Se o anúncio for carregado com sucesso, mostra-o automaticamente:
            ShowAdAutomatically();
        }
    }

    // Implementa o método de retorno de chamada OnUnityAdsShowComplete do Show Listener para determinar se o usuário recebe uma recompensa:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Anúncio Unity Rewarded concluído");
            // Conceda uma recompensa.
        }
    }

    // Implementa os callbacks de erro de Load e Show Listener:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Erro ao carregar a Unidade de Anúncio {adUnitId}: {error.ToString()} - {message}");
        // Use os detalhes do erro para determinar se deve tentar carregar outro anúncio.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Erro ao exibir a Unidade de Anúncio {adUnitId}: {error.ToString()} - {message}");
        // Use os detalhes do erro para determinar se deve tentar carregar outro anúncio.
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Anúncio Unity Ads começou a ser exibido. Placement ID: " + placementId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Anúncio Unity Ads começou a ser exibido. Placement ID: " + placementId);
    }

    // Implementa os callbacks adicionais se necessário...

    // Não há mais interação com o botão, então você pode remover o OnDestroy() se não for mais necessário.
}