using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;

    public float waitTime = 0.5f;
    private float resetTimer;

    private bool playerOnTop = false;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        resetTimer = 0f;
    }

    void Update()
    {
        // Solo activar si el jugador está encima de esta plataforma
        if (playerOnTop && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && resetTimer <= 0f)
        {
            effector.rotationalOffset = 180f;
            resetTimer = waitTime;
        }

        if (resetTimer > 0f)
        {
            resetTimer -= Time.deltaTime;

            if (resetTimer <= 0f)
            {
                effector.rotationalOffset = 0f;
            }
        }
    }

    // Detectamos si el jugador está pisando esta plataforma
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // El jugador está encima
            playerOnTop = true;
        }
    }

    // Cuando el jugador se va de esta plataforma
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnTop = false;
        }
    }
}
