using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_2 : MonoBehaviour {

    Animator animator;
    Quaternion targetRotation;

    [SerializeField]
    FloatingJoystick movementJoystick;

    public Button walkButton;
    public Button runButton;
    private bool isRunning = false;

    //*** 初期処理 ***//
    void Awake() {

        TryGetComponent(out animator);

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

        float horizontal = movementJoystick.Horizontal;
        float vertical = movementJoystick.Vertical;       
        var velocity = new Vector3(horizontal, 0, vertical).normalized;
        var speed = isRunning ? 5f : 1.5f;
        var rotationSpeed = 600 * Time.deltaTime;

        if (movementJoystick.Horizontal == 0 && movementJoystick.Vertical == 0)
        {
            horizontal = 0;
            vertical = 0;
            animator.SetFloat("Speed", 0);
        }

        if (velocity.magnitude > 0.1f)
        {
            targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        animator.SetFloat("Speed", velocity.magnitude * speed, 0.1f, Time.deltaTime);     
        var moveVector = transform.forward * velocity.magnitude * speed;
        transform.Translate(moveVector * Time.deltaTime, Space.World);
    }
}
