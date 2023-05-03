using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderAI : MonoBehaviour
{
    public string hitTag;
    public bool lookingAtPlayer = false;
    public GameObject theSolider;
    public AudioSource fireSound;
    public bool isFiring = false;
    public float fireRate = 1f;
    public int genHurt;
    public AudioSource[] hurtSound;
    public GameObject hurtFlash;

    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            hitTag = Hit.transform.tag;
        }
        if (hitTag == "Player" && isFiring == false)
        {
            StartCoroutine(EnemyFire());
        }
        if(hitTag != "Player")
        {
            theSolider.GetComponent<Animator>().Play("Idle");
            lookingAtPlayer = false;
        }

        IEnumerator EnemyFire()
        {
            isFiring = true;
            theSolider.GetComponent<Animator>().Play("FirePistol", -1 ,0);
            theSolider.GetComponent<Animator>().Play("FirePistol");
            fireSound.Play();
            lookingAtPlayer = true;
            GlobalHeath.healthValue -= 5;
            hurtFlash.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            hurtFlash.SetActive(false);
            genHurt = Random.Range(0, 3);
            hurtSound[genHurt].Play();
            yield return new WaitForSeconds(fireRate);
            isFiring = false;
        }
    }
    }
