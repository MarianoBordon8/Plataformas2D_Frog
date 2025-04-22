using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Text text;
    public string levelName;
    private bool inDoor = false;

    private float doorTime = 3;
    private float startTime = 3;

    public bool pc;
    public Image relojUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pc)
            {
                text.gameObject.SetActive(true);
            }
            else
            {
                doorTime = startTime;
                relojUI.fillAmount = 1;
                relojUI.gameObject.SetActive(true);
            }

            inDoor = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (pc)
        {
            text.gameObject.SetActive(false);
        }
        else
        {
            relojUI.gameObject.SetActive(false);
            relojUI.fillAmount = 1;
        }
        inDoor = false;
        doorTime = startTime;


    }

    private void Update()
    {
        if (pc)
        {
            if (inDoor && Input.GetKey("e"))
            {
                SceneManager.LoadScene(levelName);
            }
        }
        else
        {
            if (inDoor)
            {
                doorTime -= Time.deltaTime;
                relojUI.fillAmount = doorTime / startTime;
            }

            if (doorTime < 0)
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }
}
