using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Setup")]
    public int bulletDamage = 10;

    [Header("SerializeField")]
    [SerializeField] float speed;
    [SerializeField] float destroyTime = 2f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Destroy(gameObject);
    }
}
