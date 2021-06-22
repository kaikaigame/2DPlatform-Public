using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRange : MonoBehaviour
{
    public int damage;
    public float destroyTime;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").
            GetComponent<PlayerHealth>();

        //防止持续爆炸伤害
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("对敌人造成伤害");
            other.GetComponent<Enemy>().TakeDamage(damage);
        }

        if (other.gameObject.CompareTag("Player") && 
            other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }
    }
}
