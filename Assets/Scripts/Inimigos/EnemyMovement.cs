using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;

    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;

    private Animator anim;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    
    void Start()
    {
        player = FindObjectOfType<MovimentoParte2>().transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            anim.SetBool("Player Dead", true);
            nav.enabled = false;

        }

        
    }

    public void Restat()
    {
        nav.enabled = true;
        anim.SetBool("Player Dead", false);
    }

}
