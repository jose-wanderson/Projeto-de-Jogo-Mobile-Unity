using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{


    public AudioClip shootSound;

   
    public float effectDisplay = 0.1f;
    public Bullet playerBullet;

    public Rigidbody bombaPrefab;
    public Vector2 bombaImpuso;
    public Image bombaImagem;
    public float bombacoolDown = 10f;
    private float bombaTime;


    private float timer;
    private Light gunLigth;
    private ParticleSystem gunEffect;
    private AudioPlayer audioPlayer;

    private Level level;


    private void Awake()
    {
        gunLigth = GetComponent<Light>();
        gunEffect = GetComponent<ParticleSystem>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bombaTime = bombacoolDown;

        
            level = GameManager.Instance.levels[GameManager.Instance.level];
        
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 2f;
        bombaTime += Time.deltaTime;
        bombaImagem.fillAmount = bombaTime / bombacoolDown;

        if(timer > effectDisplay)
        {
            DisableEffects();
        }

    }

    void DisableEffects()
    {
        gunLigth.enabled = false;
    }

    public void Shoot()
    {
        if(timer > level.fireRate)
        {
            audioPlayer.PlaySound(shootSound);

            timer = 0;

            Bullet newBullet = Instantiate(playerBullet, transform.position, transform.rotation);
            newBullet.damage = level.damage;
            newBullet.speed = level.bulletSpeed;

            gunLigth.enabled = true;
            gunEffect.Stop();
            gunEffect.Play();



        }
    }


    public void Bomba()
    {
        if(bombaTime >= bombacoolDown)
        {
            bombaTime = 0;
            Rigidbody newBomba = Instantiate(bombaPrefab, transform.position, Quaternion.identity);
            newBomba.AddForce(transform.forward * bombaImpuso.x, ForceMode.Impulse);
            newBomba.AddForce(Vector3.up * bombaImpuso.y, ForceMode.Impulse);
        }
    }


}
