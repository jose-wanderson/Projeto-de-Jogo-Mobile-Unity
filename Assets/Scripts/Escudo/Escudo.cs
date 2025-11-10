using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escudo : MonoBehaviour
{
    private int damage = 50;
    public bool ignoreTrigger;
    MeshRenderer mesh;
    MeshCollider meshCollider;

    public Image escudoImagem;
    public float escudoCoolDown = 100;
    private float escudoTime;



    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }


    private void Start()
    {
        escudoTime = escudoCoolDown;
    }

    private void Update()
    {
        escudoTime += Time.deltaTime;
        escudoImagem.fillAmount = escudoTime / escudoCoolDown;
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();

        if (ignoreTrigger) return;

        if (health != null)
        {
            DoDamage(health, damage);
        }
    }

    public void DoDamage(Health health, int damage)
    {
        health.TakeDamage(damage, transform.position);
    }

    public void AtivarScudo()
    {

        EscudoTimeBotao();

    }

    IEnumerator AtivardorEscudo()
    {
        meshCollider.enabled = true;
        mesh.enabled = true;
        yield return new WaitForSeconds(3);
        meshCollider.enabled = false;
        mesh.enabled = false;
    }

    public void EscudoTimeBotao()
    {
        if (escudoTime >= escudoCoolDown)
        {
            escudoTime = 0;
            StartCoroutine(AtivardorEscudo());


        }
    }

}

