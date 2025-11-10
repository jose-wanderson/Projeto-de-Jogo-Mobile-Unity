using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestandoTeste : MonoBehaviour
{
    public GameObject playerInGame; // Referência ao jogador na cena "Game"
    void Start()
    {
        // Verifica se o material foi selecionado na cena anterior
        if (PlayerSelect.selectedMaterial != null)
        {
            Renderer playerRenderer = playerInGame.GetComponentInChildren<Renderer>();
            if (playerRenderer != null)
            {
                // Aplica o material selecionado ao jogador
                playerRenderer.material = PlayerSelect.selectedMaterial;
            }
            else
            {
                Debug.LogError("O jogador na cena 'Game' não possui um componente Renderer.");
            }
        }
        else
        {
            Debug.LogError("Nenhum material foi selecionado na cena anterior.");
        }
    }
}