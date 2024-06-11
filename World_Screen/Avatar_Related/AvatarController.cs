using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AvatarController : MonoBehaviour {

    public float moveSpeed = 1f;
    public FloatingJoystick joystick;
    private Animator animator;
    private Vector3 moveDirection;
    private Rigidbody rb;
    private bool isRunning = false;

    //*** コンポーネント取得処理 ***//
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        TryGetComponent(out animator);
    }

    //*** モーション切り替え処理 ***//
    void WalkButtonClick() {

        isRunning = false;
        animator.SetBool("Speed", false);        
    }

    void RunButtonClick() {

        isRunning = true;
        animator.SetBool("Speed", true);
    }

    //*** コンポーネント取得処理 ***//
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * moveSpeed);
        }
    }

    //*** 移動実行処理 ***//
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
