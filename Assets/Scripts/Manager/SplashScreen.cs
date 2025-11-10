using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
    // Defina o tempo de duração da tela inicial em segundos
    public float splashDuration = 3f;

    // Start é chamado quando o script é ativado
    void Start()
    {
        // Iniciar a troca de cena após o tempo definido
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    // Coroutine para aguardar o tempo da splash screen
    IEnumerator LoadNextSceneAfterDelay()
    {
        // Aguarda pelo tempo especificado
        yield return new WaitForSeconds(splashDuration);

        // Carrega a próxima cena
        SceneManager.LoadScene(1);
    }
}