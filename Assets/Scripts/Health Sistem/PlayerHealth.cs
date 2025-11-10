using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class PlayerHealth : Health
{

    public UnityEngine.UI.Slider healthSlider;
    public UnityEngine.UI.Image damageImage;
    public Color damageColor;
    public float flashSpeed = 5f;

    public AudioClip damageSound, deathSound;

    public GameObject adButton;

    private bool damaged;
    private Animator anim;
    private MovimentoParte2 movimentoParte2;
    private bool alReadyDied;

    private AudioPlayer audioPlayer;





    private void Awake()
    {
        anim = GetComponent<Animator>();
        movimentoParte2 = GetComponent<MovimentoParte2>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }


    public override void TakeDamage(int damage, Vector3 hitPoint)
    {
        if(isDead) return;

        audioPlayer.PlaySound(damageSound);
        damaged = true;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0) 
        {
            Death();
        
        }
    }

    protected override void Death()
    {
       isDead = true;
        audioPlayer.PlaySound(deathSound);
        anim.SetTrigger("Die");
        movimentoParte2.enabled = false;
        LevelController.instance.GameOver();

        if(!alReadyDied)
        {
            adButton.SetActive(true);
            alReadyDied = true;
        }

    }

    protected override void Spawn()
    {
        currentHealth = startingHealth;
    }

    public override void Recuparecao(int recuperacao)
    {
        currentHealth += recuperacao;
        healthSlider.value = currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Vida":
                if (currentHealth < 100) 
                {
                    int vida = 20;
                    Recuparecao(vida);
                }
                Destroy(other.gameObject);
                break;
        }
    }

    public void Respawn()
    {
        currentHealth = startingHealth;
        anim.Rebind();
        healthSlider.value = currentHealth;
        movimentoParte2.enabled = true;
        Invoke("SetISdead", 5f);
        


        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();
        
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Restat();
        }
    }

    void SetISdead()
    {
        isDead = false;
    }

}
