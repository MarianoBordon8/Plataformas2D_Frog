using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FruitManager : MonoBehaviour
{
    public GameObject transition;

    public Text totalFruits;
    public Text fruitsCollected;
    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
        totalFruits.text=totalFruitsInLevel.ToString();
    }
    private void Update()
    {
        AllFruitCollected();
        fruitsCollected.text = transform.childCount.ToString();
    }
    public void AllFruitCollected()
    {
        if (transform.childCount == 0)
        {
            
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
            
        }
    }

    void ChangeScene()
    {
        PlayerPrefs.DeleteKey("CheckPointPositionX");
        PlayerPrefs.DeleteKey("CheckPointPositionY");

        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        int totalEscenas = SceneManager.sceneCountInBuildSettings;

        if (escenaActual < totalEscenas - 1)
        {
            SceneManager.LoadScene(escenaActual + 1);
        }
        else
        {
            SceneManager.LoadScene(0); 
        }
    }

}
