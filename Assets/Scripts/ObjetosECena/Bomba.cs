using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{

    public GameObject Explosao;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosao, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
