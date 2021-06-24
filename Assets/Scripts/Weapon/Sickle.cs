using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public int damage;
    public float tuning;

    private Rigidbody2D rb2d;
    private Transform playerTransform;
    private Transform sickleTransform;
    private Vector2 startSpeed;
    private CameraShake camShake;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
        startSpeed = rb2d.velocity;//记录初始速度

        playerTransform = GameObject.FindGameObjectWithTag("Player").
            GetComponent<Transform>();

        sickleTransform = GetComponent<Transform>();

        camShake = GameObject.FindGameObjectWithTag("CameraShake").
            GetComponent<CameraShake>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
            transform.Rotate(0, 0, rotateSpeed);

        //线性插值 回到角色位置
        float yBack = Mathf.Lerp(transform.position.y,
            playerTransform.position.y, tuning);

        transform.position = new Vector3
            (transform.position.x, yBack, 0.0f);

        rb2d.velocity = rb2d.velocity -
            startSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x -
            playerTransform.position.x) < 0.5f)
        {
            Destroy(gameObject);//回收回旋镖
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
