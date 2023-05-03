using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLife : MonoBehaviour
{
    public GameObject lifeDisplay;
    public static int lifeValue = 3;
    public int internalHealth;


    void Update()
    {
        internalHealth = lifeValue;
        lifeDisplay.GetComponent<Text>().text ="" + lifeValue;
    }
}
