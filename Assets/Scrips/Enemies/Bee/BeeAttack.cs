using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public Animator animator;
    public float distenceRaycast = 0.5f;
    private float cooldownAttack = 1.5f;
    private float actualCooldownAttack;
    public GameObject beeBullet;

    private void Start()
    {
        actualCooldownAttack = 0;

    }
    private void Update()
    {
        actualCooldownAttack -= Time.deltaTime;
        //Debug.DrawRay(transform.position, Vector2.down, Color.red, distenceRaycast);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distenceRaycast);
        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player"))
            {
                if (actualCooldownAttack < 0)
                {
                    Invoke("LaunchBullet", 0.5f);
                    animator.Play("Attack");
                    actualCooldownAttack = cooldownAttack;
                }
            }
        }
    }
    void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}
