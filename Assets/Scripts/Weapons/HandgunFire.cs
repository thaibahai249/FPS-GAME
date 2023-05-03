using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject muzzleFlash;
    public AudioSource gunFire;
    public bool isFiring = false;
    public AudioSource emptySound;
    public float targetDistance;
    public int damageAmount = 5;

  [SerializeField] EnemyDeath enemyHealth;


    private void Start()
    {
        enemyHealth = FindObjectOfType<EnemyDeath>().GetComponent<EnemyDeath>();
    }

    void Update()
    {

        if(GlobalAmmo.handgunAmmo < 1)
        {
            emptySound.Play();
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                if (isFiring == false)
                {
                    StartCoroutine(FiringHandgun());
                }
            }
        }

    }

    IEnumerator FiringHandgun()
    {
        RaycastHit theShot;
        isFiring = true;
        GlobalAmmo.handgunAmmo -= 1;
        if(Physics.Raycast(this.gameObject.transform.position,transform.TransformDirection(Vector3.forward), out theShot))
        {
            Debug.Log("KIEM TRA: " + theShot.transform.gameObject.tag.ToString());

            if(theShot.transform.gameObject.tag == "enemy")
            {
                enemyHealth.DamageEnemy(10);
                Debug.Log("xxxxxxxxxxxxx");
            }
            targetDistance = theShot.distance;
            //theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.RequireReceiver);
            Debug.Log("DEBUG DAME: " + damageAmount.ToString());
            Debug.Log("ENTER NEEEE");
        }
        TheGun.GetComponent<Animator>().Play("HandgunFire");
        muzzleFlash.SetActive(true);
        gunFire.Play();

        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        TheGun.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }    

}
