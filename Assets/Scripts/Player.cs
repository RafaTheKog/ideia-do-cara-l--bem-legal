using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;

    Vector2 moveInput;
    SpriteRenderer sprite;
    Animator anim;
    Life life;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        life = GetComponent<Life>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        transform.position = transform.position + movement * Speed * Time.deltaTime;
        sprite.flipX = (mousePos.x < screenPoint.x);
        
        anim?.SetBool("isMoving", (Mathf.Abs(moveInput.x) > 0 || Mathf.Abs(moveInput.y) > 0));        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            var bullet = other.GetComponent<EnemyBullet>();
            if (bullet != null) life.Damage( bullet.bulletDamage );
        }
    }
}
