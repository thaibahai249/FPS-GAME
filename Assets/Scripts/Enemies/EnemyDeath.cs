using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int enemyHealth = 50;
    public bool enemyDead = false;
    public GameObject enemyAI;
    public GameObject theEnemy;

   public void DamageEnemy(int damageAmount)
    {
        enemyHealth -= damageAmount;
        Debug.Log("Enter here");
    }

    void Update()
    {
        if (enemyHealth <= 0 && enemyDead == false)
        {
            enemyDead = true;
            theEnemy.GetComponent<Animator>().Play("Death");
            enemyAI.SetActive(false);
            GlobalScore.scoreValue += 100;
            GlobalComplete.enemyCount += 1;
        }
    }
}
