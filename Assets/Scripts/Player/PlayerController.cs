using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;

    public float climbSpeed;
    public float restoreTime;

    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;

    private bool isGround;
    private bool canDoubleJump;
    private bool isOneWayPlatform;

    private bool isLadder;
    private bool isClimbing;

    private bool isJumping;
    private bool isFalling;
    private bool isDoubleJumping;
    private bool isDoubleFalling;

    private float playerGravity;
    
    //private PlayerInputActions controls;
    private PlayerControls controls;
    private Vector2 move;

    void Awake()
    {
        //controls = new PlayerInputActions();
        controls = new PlayerControls();

        //Event that is triggered when the action has been fully performed
        controls.GamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();

        //Event that is triggered when the action has been started 
        //but then canceled before being fully performed
        controls.GamePlay.Move.canceled += ctx => move = Vector2.zero;

        //Event that is triggered when the action has been started
        controls.GamePlay.Jump.started += ctx => Jump();
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
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        playerGravity = myRigidbody.gravityScale;//初始重力
    }

    void Update()
    {
        if (GameManager.isGameAlive)
        {
            CheckAirStatus();
            Flip();
            Run();
            Climb();

            //Jump();
            //Attack();

            CheckGrounded();
            CheckLadder();
            SwitchAnimation();
            OneWayPlatformCheck();
        }
    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform")) ||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("DestructibleLayer")) ||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));

        isOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }

    void CheckLadder()
    {
        isLadder = myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
        //Debug.Log("isLadder:" + isLadder);
    }

    void Flip()//翻转人物
    {
        //有速度才可能翻转
        bool plyerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (plyerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void Run()
    {
        #region Input Manager

        //float moveDir = Input.GetAxis("Horizontal");
        ////Debug.Log("moveDir = " + moveDir.ToString());
        ////y速度保持不变
        //Vector2 playerVelo = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        //myRigidbody.velocity = playerVelo;
        ////水平轴速度大于 无限小的值
        //bool plyerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        //myAnim.SetBool("Run", plyerHasXAxisSpeed);

        #endregion

        #region Input System

        Vector2 playerVelocity = new Vector2(move.x * runSpeed, myRigidbody.velocity.y);

        myRigidbody.velocity = playerVelocity;
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run", playerHasXAxisSpeed);

        #endregion
    }

    void Jump()
    {
        //if (Input.GetButtonDown("Jump"))
        //{
            if (isGround)
            {
                myAnim.SetBool("Jump", true);
                Vector2 jumpVelo = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVelo;
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    //二段跳
                    myAnim.SetBool("DoubleJump", true);
                    Vector2 doubleJumpVelo = new Vector2(0.0f, doubleJumpSpeed);
                    myRigidbody.velocity = Vector2.up * doubleJumpVelo;
                    canDoubleJump = false;
                }
            }
        //}
    }

    void Climb()
    {
        #region Input Manager

        //float moveY = Input.GetAxis("Vertical");

        //if (isClimbing)
        //{
        //    myRigidbody.velocity = new Vector2
        //        (myRigidbody.velocity.x, moveY * climbSpeed);
        //    canDoubleJump = false;
        //}

        //if (isLadder)
        //{
        //    //上下时才能爬梯子
        //    if (moveY > 0.5f || moveY < -0.5f)
        //    {
        //        myAnim.SetBool("Jump", false);
        //        myAnim.SetBool("DoubleJump", false);
        //        myAnim.SetBool("Climbing", true);
        //        myRigidbody.velocity = new Vector2
        //            (myRigidbody.velocity.x, moveY * climbSpeed);
        //        myRigidbody.gravityScale = 0.0f;
        //    }
        //    else
        //    {
        //        if (isJumping || isFalling
        //            || isDoubleJumping || isDoubleFalling)
        //        {
        //            myAnim.SetBool("Climbing", false);
        //        }
        //        else
        //        {
        //            //停在梯子上
        //            //myAnim.SetBool("Climbing", false);
        //            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.0f);
        //        }
        //    }
        //}
        //else
        //{
        //    myAnim.SetBool("Climbing", false);
        //    myRigidbody.gravityScale = playerGravity;
        //}

        //if (isLadder && isGround)
        //{
        //    myRigidbody.gravityScale = playerGravity;
        //}

        //Debug.Log("myRigidbody.gravityScale:"+ myRigidbody.gravityScale);

        #endregion

        #region Input System

        if (isClimbing)
        {
            myRigidbody.velocity = new Vector2
                (myRigidbody.velocity.x, move.y * climbSpeed);
            canDoubleJump = false;
        }

        if (isLadder)
        {
            //上下时才能爬梯子
            if (move.y > 0.5f || move.y < -0.5f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("DoubleJump", false);
                myAnim.SetBool("Climbing", true);
                myRigidbody.velocity = new Vector2
                    (myRigidbody.velocity.x, move.y * climbSpeed);
                myRigidbody.gravityScale = 0.0f;
            }
            else
            {
                if (isJumping || isFalling
                    || isDoubleJumping || isDoubleFalling)
                {
                    myAnim.SetBool("Climbing", false);
                }
                else
                {
                    //停在梯子上
                    //myAnim.SetBool("Climbing", false);
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.0f);
                }
            }
        }
        else
        {
            myAnim.SetBool("Climbing", false);
            myRigidbody.gravityScale = playerGravity;
        }

        if (isLadder && isGround)
        {
            myRigidbody.gravityScale = playerGravity;
        }

        #endregion

    }

    //void Attack()
    //{
    //    if (Input.GetButtonDown("Attack"))
    //    {
    //        myAnim.SetTrigger("Attack");
    //    }
    //}

    void SwitchAnimation()
    {
        myAnim.SetBool("Idle", false);

        if (myAnim.GetBool("Jump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Fall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("Fall", false);
            myAnim.SetBool("Idle", true);
        }

        if (myAnim.GetBool("DoubleJump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("DoubleJump", false);
                myAnim.SetBool("DoubleFall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("DoubleFall", false);
            myAnim.SetBool("Idle", true);
        }
    }

    void OneWayPlatformCheck()
    {
        if (isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }

        //Input Manager
        //float moveY = Input.GetAxis("Vertical");
        //if (isOneWayPlatform && moveY < -0.1f)
        //{
        //    gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
        //    Invoke("RestorePlayerLayer", restoreTime);
        //}


        //Input System
        //按 下 键，player图层变成OneWayPlatform，不与单向平台碰撞
        if (isOneWayPlatform && move.y < -0.1f)
        {
            gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
            Invoke("RestorePlayerLayer", restoreTime);
        }
    }

    void RestorePlayerLayer()
    {
        if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }

    void CheckAirStatus()
    {
        isJumping = myAnim.GetBool("Jump");
        isFalling = myAnim.GetBool("Fall");
        isDoubleJumping = myAnim.GetBool("DoubleJump");
        isDoubleFalling = myAnim.GetBool("DoubleFall");
        isClimbing = myAnim.GetBool("Climbing");

        //Debug.Log("isJumping:" + isJumping);
        //Debug.Log("isFalling:" + isFalling);
        //Debug.Log("isDoubleJumping:" + isDoubleJumping);
        //Debug.Log("isDoubleFalling:" + isDoubleFalling);
        //Debug.Log("isClimbing:" + isClimbing);
    }
}
