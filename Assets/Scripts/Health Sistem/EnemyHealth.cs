using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : Health 
{

    public AudioClip dearhSound, damageSound;
    
    public float sinkSpeed = 2.5f;
    private bool isSinkking;

    public int scoreValue = 10;


    private ParticleSystem hitParticles;
    private Animator anim;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private NavMeshAgent navMeshAgent;
    private AudioPlayer audioPlayer;
    private SphereCollider sphereCollider;

    [Header("Drop Item")]
    public GameObject vidaPrefab;
    public int PorcetagemDeDrop;
    


    private void Awake()
    {
        hitParticles = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        audioPlayer = GetComponent<AudioPlayer>();
        sphereCollider = GetComponent<SphereCollider>();
      
        Spawn();
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinkking)
        {
            transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
        }
    }


    public override void TakeDamage(int damage, Vector3 hitPoint)
    {

        if(isDead) 
            return;

        audioPlayer.PlaySound(dearhSound);

        currentHealth -= damage;
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death();
        }
    
    }

    protected override void Death()
    {
        isDead = true;

        audioPlayer.PlaySound(dearhSound);
        capsuleCollider.isTrigger = true;
        capsuleCollider.enabled = false;
        sphereCollider.enabled = false;
        anim.SetTrigger("Dead");

        LevelController.instance.UpdateScore(scoreValue);

        PlayGamesManager.instance.UnlonkAchievement(GPGSIds.achievement_first_blood);
        PlayGamesManager.instance.IncrementSchievement(GPGSIds.achievement_over_1000, scoreValue);
        PlayGamesManager.instance.IncrementSchievement(GPGSIds.achievement_heri_do_game, scoreValue);
    }

    public void StartSinking()
    {
        navMeshAgent.enabled = false;
        rb.isKinematic = true;
        isSinkking = true;

        if (Perc(PorcetagemDeDrop))
        {
            Instantiate(vidaPrefab, transform.position, vidaPrefab.transform.rotation);
        }
       

        Destroy(gameObject, 1 );
    }

    public bool Perc(int p)
    {

        int tepm = UnityEngine.Random.Range(0, 100);
        bool retorno = tepm <= p ? true : false;
        return retorno;
    }
    

    protected override void Spawn()
    {
        currentHealth = startingHealth;
    }

    public override void Recuparecao(int recuperacao)
    {
        
    }

}
