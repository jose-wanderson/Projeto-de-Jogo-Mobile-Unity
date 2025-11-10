using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkCheck : MonoBehaviour
{
    void Start()
    {
        CheckInternetConnection();
    }

    void CheckInternetConnection()
    {
        // Verifica o tipo de conexão
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // Não há conexão com a internet
            Debug.Log("No internet connection");
            // Carrega a cena de erro, que pode informar o jogador sobre a falta de internet
            SceneManager.LoadScene("SemNet");
        }
        else
        {
            // Conexão com a internet disponível
            Debug.Log("Internet connection available");
            // Carrega a cena principal do jogo
            SceneManager.LoadScene("Menu");
        }
    }
}