using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealthCollect : MonoBehaviour
{
    public AudioSource collectsound;

    void OnTriggerEnter(Collider other)
    {
        GlobalHeath.healthValue = 100;
        collectsound.Play();
        GetComponent<BoxCollider>().enabled = false;
        this.gameObject.SetActive(false);
    }
}
