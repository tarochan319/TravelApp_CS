using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_1 : MonoBehaviour {

    Animator animator;
    Quaternion targetRotation;

    [SerializeField]
    FloatingJoystick joystick;

    public Button walkButton;
    public Button runButton;
    private bool isRunning = false;

    //*** 初期処理 ***//
    void Awake() {

        animator = GetComponent<Animator>();
        targetRotation = transform.rotation;       
        walkButton.onClick.AddListener(WalkButtonClick);
        runButton.onClick.AddListener(RunButtonClick);
    }

    //*** モーション切り替え処理 ***//
    void WalkButtonClick() {

        isRunning = false;
        animator.SetBool("IsRunning", false);        
    }

    void RunButtonClick() {

        isRunning = true;
        animator.SetBool("IsRunning", true);
    }

    void Update() {

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        var velocity = new Vector3(horizontal, 0, vertical).normalized;
        var speed = isRunning ? 5f : 1.5f;
        var rotationSpeed = 500 * Time.deltaTime;

        if (velocity.magnitude > 0.5f)
        {
            targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        animator.SetFloat("IsRunning", velocity.magnitude * speed, 0.1f, Time.deltaTime);     
        var moveVector = transform.forward * velocity.magnitude * speed;
        transform.Translate(moveVector * Time.deltaTime, Space.World);
    }
}

