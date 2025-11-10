using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class NetworkGame : MonoBehaviour
{
    // Define o intervalo de tempo entre as verificações de rede (em segundos)
    public float checkInterval = 5f; // A cada 5 segundos
    private float nextCheckTime = 0f;

    void Start()
    {
        // Checa a conexão logo ao iniciar
        StartCoroutine(CheckInternetConnectionCoroutine());
    }

    void Update()
    {
        // Verifica se já passou o tempo necessário para a próxima checagem
        if (Time.time >= nextCheckTime)
        {
            StartCoroutine(CheckInternetConnectionCoroutine());
            // Define o tempo da próxima verificação
            nextCheckTime = Time.time + checkInterval;
        }
    }

    // Coroutine para fazer uma requisição HTTP e verificar a internet
    IEnumerator CheckInternetConnectionCoroutine()
    {
        // Tenta acessar um site confiável (ex: Google)
        UnityWebRequest request = new UnityWebRequest("http://www.google.com");
        request.timeout = 5; // Timeout de 5 segundos
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            // Não há conexão com a internet ou houve algum erro
            Debug.Log("No internet connection: " + request.error);
            // Carrega a cena de erro
            SceneManager.LoadScene(0);
        }
        else
        {
            // Conexão com a internet disponível
            Debug.Log("Internet connection available");
            // O jogo continua normalmente
        }
    }
}