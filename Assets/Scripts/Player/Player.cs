using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    public Vector2 velocity;
    public float speed = 5;
    public float runSpeed = 15;
    public float jumpForce = 20;
    public Vector2 friction = new Vector2(.1f, 0);

    public Animator animator;
    public string boolRun = "Run";
    public string triggerDeath = "Death";



    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    public HealthBase healthBase;
    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerDeath;
        }
    }

    private void OnPlayerDeath()
    {
        healthBase.OnKill -= OnPlayerDeath;
        animator.SetTrigger(triggerDeath);
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }
    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool(boolRun, true);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, .1f);
            }
            myRigidBody.velocity = new Vector2(Input.GetKey(KeyCode.LeftShift) ? -runSpeed : -speed, myRigidBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool(boolRun, true);
            if (myRigidBody.transform.localScale.x == -1)
            {
                myRigidBody.transform.DOScaleX(1, .1f);
            }
            myRigidBody.velocity = new Vector2(Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed, myRigidBody.velocity.y);
        }else
        {
            animator.SetBool(boolRun, false);
        }

        if (myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity += friction * -1;
        }
        else if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity -= friction * -1;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && myRigidBody.velocity.y == 0)
        {
            myRigidBody.velocity = Vector2.up * jumpForce;
            myRigidBody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody.transform);
            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
