using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    public AudioSource audioSource; // Referência para o AudioSource

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa o tempo do jogo
            audioSource.Pause();  // Pausa o som
            Debug.Log("Jogo Pausado");
        }
        else
        {
            Time.timeScale = 1f; // Volta ao tempo normal do jogo
            audioSource.UnPause(); // Retoma o som
            Debug.Log("Jogo Despausado");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Jogo Fechado");
        Application.Quit();
    }
}