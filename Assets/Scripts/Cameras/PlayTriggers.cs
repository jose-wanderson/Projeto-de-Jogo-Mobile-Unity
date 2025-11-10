using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTriggers : MonoBehaviour
{

    public GameObject camB;
   
    // Start is called before the first frame update
    
    void Start()
    {

    }

    private void FixedUpdate()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Sensores":
                camB.SetActive(true);
                break;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Sensores":
                camB.SetActive(false);
                break;
        }
    }
}
