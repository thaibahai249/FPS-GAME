using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorComplete : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject completePanel;
    public GameObject thePlayer;
    public GameObject floorTimer;

    void OnTriggerEnter(Collider other)
    {
        floorTimer.SetActive(false);
        StartCoroutine(CompletedFloor());
        thePlayer.GetComponent<SC_FPSController>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

    }

    IEnumerator CompletedFloor()
    {
        fadeOut.SetActive(true);
        GlobalComplete.nextFloor += 1;
        PlayerPrefs.SetInt("SceneToLoad", GlobalComplete.nextFloor);
        PlayerPrefs.SetInt("LivesSaved", GlobalLife.lifeValue);
        PlayerPrefs.SetInt("ScoreSaved", GlobalScore.scoreValue);
        PlayerPrefs.SetInt("AmmoSave", GlobalAmmo.handgunAmmo);

        yield return new WaitForSeconds(2);
        completePanel.SetActive(true);
        yield return new WaitForSeconds(15);
        GlobalScore.scoreValue = 0;
        GlobalComplete.enemyCount = 0;
        GlobalComplete.treasureCount = 0;
        
        SceneManager.LoadScene(GlobalComplete.nextFloor);
    }

}
