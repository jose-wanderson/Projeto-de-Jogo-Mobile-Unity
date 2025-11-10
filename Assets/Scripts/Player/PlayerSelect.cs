using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    GameObject player; // O jogador que está sendo instanciado na cena de seleção
    int i; // Índice do personagem selecionado

    public GameObject[] players; // Array de personagens (prefabs)
    public Button next, previous, select; // Botões de navegação e seleção
    public static Material selectedMaterial; // Material estático para ser acessado na cena "Game"

    // Posição e rotação do objeto "Player" original na cena de seleção
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        i = 0;

        // Inicializa os eventos dos botões corretamente
        next.onClick.AddListener(Next);
        previous.onClick.AddListener(Previous);
        select.onClick.AddListener(Select);

        // Captura a posição e rotação do objeto "Player" original na cena
        GameObject originalPlayer = GameObject.Find("Player");
        if (originalPlayer != null)
        {
            initialPosition = originalPlayer.transform.position; // Posição do "Player"
            initialRotation = originalPlayer.transform.rotation; // Rotação do "Player"
        }

        // Instancia o jogador inicial e define o material inicial
        InstantiatePlayer();
        UpdateSelectedMaterial();
    }

    void InstantiatePlayer()
    {
        if (player != null)
        {
            player.SetActive(false); // Desativa o jogador atual em vez de destruí-lo
        }

        // Instancia o novo jogador na posição e rotação do objeto original
        player = Instantiate(players[i], initialPosition, initialRotation);
        player.SetActive(true);
    }

    // Atualiza o material selecionado com base no personagem atual
    void UpdateSelectedMaterial()
    {
        Renderer playerRenderer = player.GetComponentInChildren<Renderer>();
        if (playerRenderer != null)
        {
            selectedMaterial = playerRenderer.material;
        }
        else
        {
            Debug.LogError("O jogador atual não possui um componente Renderer.");
        }
    }

    // Avança para o próximo personagem
    void Next()
    {
        i++;
        if (i >= players.Length)
        {
            i = 0;
        }
        InstantiatePlayer();
        UpdateSelectedMaterial();
    }

    // Retrocede para o personagem anterior
    void Previous()
    {
        i--;
        if (i < 0)
        {
            i = players.Length - 1;
        }
        InstantiatePlayer();
        UpdateSelectedMaterial();
    }

    // Carrega a cena do jogo quando o personagem é selecionado
    void Select()
    {
        SceneManager.LoadScene("Game");
    }
}
