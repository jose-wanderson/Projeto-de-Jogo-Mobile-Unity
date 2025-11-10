using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttck : MonoBehaviour
{

    public float attackRate = 1;
    public int damage = 10;

    private GameObject player;
    private bool playerInRage;
    private float timer;

    private PlayerHealth playerHealth;

    public GameObject damageImpact;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovimentoParte2>().gameObject;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackRate && playerInRage)
        {
            Attack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRage = false;
        }
    }


    void Attack()
    {
        timer = 0;
        playerHealth.TakeDamage(damage, Vector3.zero);
    }



    void StartAttack () 
    {
        damageImpact.SetActive(false);
    }

    void FinishAttack () 
    {
        damageImpact.SetActive(true);
    }


}
