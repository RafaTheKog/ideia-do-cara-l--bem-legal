using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Animator anim;

    [Header ("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShoots;
    private float timeBtwShoots;

    [Header("References")]
    public GameObject slimeBullet;

    private Transform player;
    private Life life;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        life = GetComponent<Life>();
    }

    void Update()
    {
        if(PlayerDistance() < nearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else if(PlayerDistance() > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(PlayerDistance() < stoppingDistance && PlayerDistance() > nearDistance)
        {
            transform.position = this.transform.position;
        }

        if(timeBtwShoots <= 0)
        {
            Instantiate(slimeBullet, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
        }
        else timeBtwShoots -= Time.deltaTime;
    }

    private float PlayerDistance()
    {
        return Vector2.Distance(transform.position, player.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            var bullet = other.GetComponent<Bullet>();
            if (bullet != null) life.Damage( bullet.bulletDamage );
            else return;

            Destroy(other.gameObject);
        }
    }
}
