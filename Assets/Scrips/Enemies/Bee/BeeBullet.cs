using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBullet : MonoBehaviour
{
    public float speed = 2;
    public float LifeTime = 2;


    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
