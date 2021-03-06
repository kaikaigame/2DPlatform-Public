using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float startTime;
    public float time;

    private Animator anim;
    private new PolygonCollider2D collider2D;

    //private PlayerInputActions controls;
    private PlayerControls controls;

    void Awake()
    {
        //controls = new PlayerInputActions();
        controls = new PlayerControls();

        controls.GamePlay.Attack.started += ctx => Attack();
    }

    void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    void OnDisable()
    {
        controls.GamePlay.Disable();
    }

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").
            GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        //Attack();
    }

    void Attack()
    {
        ////Input Manager
        //if (Input.GetButtonDown("Attack"))
        //{
        //    anim.SetTrigger("Attack");
        //    StartCoroutine(StartAttack());
        //}

        //Input System
        anim.SetTrigger("Attack");
        StartCoroutine(StartAttack());
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }

        if (other.gameObject.CompareTag("YellowStar"))
        {
            other.GetComponent<YellowStar>().GenGift();
        }
    }
}
