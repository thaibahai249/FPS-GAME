using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Per10HealthCollect : MonoBehaviour
{
    public AudioSource collectsound;

    void OnTriggerEnter(Collider other)
    {
        if (GlobalHeath.healthValue >= 91)
        {
            GlobalHeath.healthValue = 100;
        }
        else
        {
            GlobalHeath.healthValue += 10;
        }
        collectsound.Play();
        GetComponent<BoxCollider>().enabled = false;
        this.gameObject.SetActive(false);
    }
}
