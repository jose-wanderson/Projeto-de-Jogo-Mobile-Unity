using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoParte2 : MonoBehaviour
{
    [SerializeField] private float velocidade = 4; // Velocidade que o personagem irá se mover

    private Vector2 myInput; // Vector2 que armazena os inputs do joystick de movimento
    private CharacterController characterController; // Referência ao componente de CharacterController do personagem
    private Transform myCamera; // Referência a câmera principal da cena
    private Animator animator; // Referência ao componente Animator do personagem
    private PlayerShooting playerShooting;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>(); // Nesse código é feito a referenciação
        animator = GetComponent<Animator>(); // Nesse código é feito a referenciação
        myCamera = Camera.main.transform; // Nesse código é feito a referenciação
        playerShooting = GetComponentInChildren<PlayerShooting>();
    }

    /// <summary>
    /// Metodo responsável por obter as entradas do joystick.
    /// </summary>
    /// <param name="value">Callback com as entradas de joystick, vindos do Inputs Actions</param>
    public void MoverPersonagem(InputAction.CallbackContext value)
    {
        myInput = value.ReadValue<Vector2>();
    }


    private void Update()
    {
        RotacionarPersonagem(); // Chama o método para definir a rotação do personagem
        characterController.Move(transform.forward * myInput.magnitude * velocidade * Time.deltaTime);
        characterController.Move(Vector3.down * 9.81f * Time.deltaTime);

        animator.SetBool("Walking", myInput != Vector2.zero);
    }

    /// <summary>
    /// Rotaciona o personagem de acordo com a posição da câmera e entradas do usuário
    /// </summary>
    private void RotacionarPersonagem()
    {
        Vector3 forward = myCamera.TransformDirection(Vector3.forward); // Armazena um vetor que indica a direção "para frente"

        Vector3 right = myCamera.TransformDirection(Vector3.right); // Armazena um vetor que indica a direção "para o lado direito"


        /* Faz um calculo para indicar a direção que o personagem deve seguir, levando em consideração as entradas no joystick e a posição da câmera. 
           Por exemplo, se quisermos ir para frente, nossa direção não é X=0, Y=0, Z=1, pois essa direção está no eixo global, se nossa câmera estiver
           virada para a esquerda, ir para frente signica ir na direção X=-1, Y=0, Z=0. Por isso, a linha abaixo basicamente faz essa conversão de direção,
           indicando um Vector de direção baseada na rotação atual da câmera.
        */
        Vector3 targetDirection = myInput.x * right + myInput.y * forward;


        if (myInput != Vector2.zero && targetDirection.magnitude > 0.1f) // Verifica se o Input é diferente de 0 e se a magnitude(intesidade) do input é maior do que 0.1, em uma escala de 0 a 1. Ou seja, desconsidera pequenos movimentos no joystick.
        {
            Quaternion freeRotation = Quaternion.LookRotation(targetDirection.normalized); // Cria uma rotação com as direções forward. Ou seja, retorna uma rotação indicando a direção alvo.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.eulerAngles.x, freeRotation.eulerAngles.y, transform.eulerAngles.z)), 10 * Time.deltaTime); // Aplica a rotação ao personagem. O método Quaternion.Slerp aplica uma suavização na rotação, para que ela não aconteça de forma abrupta
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        animator.SetBool("Walking", walking);
    }


}