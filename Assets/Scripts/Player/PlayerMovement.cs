using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public class PlayerMovement : MonoBehaviour
{
    private Vector2 myInput;
    public FixedJoystick moveJoystick;

    public float speed;

    private Vector3 movement;
    private Rigidbody rb;

    private Animator animator;

    private PlayerShooting playerShooting;

    private SpeedPerson speedPerson;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
    }

    // Start is called before the first frame update
    void Start()
    {
        speedPerson = GameManager.Instance.speedPerson[GameManager.Instance.speedPersonagem];
    }

    private void FixedUpdate()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        float h = moveJoystick.Horizontal;
        float v = moveJoystick.Vertical;
         
        Move(h, v);
        Turning(h, v);
        Animating(h, v);
    }
    public void MoverPersonagem(InputAction.CallbackContext value)
    {
        myInput = value.ReadValue<Vector2>();
    }
    private void Move ( float h, float z )
    {
        movement.Set(h, 0, z);
        movement = movement.normalized * speedPerson.speedPersonagem * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turning( float h, float z )
    {
        Vector3 rot = new Vector3(h,0,z);
        if(rot!= Vector3.zero )
        {
            transform.rotation = Quaternion.LookRotation(rot);
           // playerShooting.Shoot();
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        animator.SetBool("Walking", walking);
    }


}
