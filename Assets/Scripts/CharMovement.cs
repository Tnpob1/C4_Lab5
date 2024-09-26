using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
// https://stackoverflow.com/questions/62030512/cs0104-ambiguous-reference-between-system-numerics-vector3-and-unityengine-v
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using System;

public class CharMovement : MonoBehaviour
{
    Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float force = 700.0f;
    public float jumpForce = 700.0f;
    public float gravity = 20.0f;

    public bool isGrounded = false;

    public bool IsIdle = false;
    public bool IsDance = false;
    public bool IsWalk = false;

    CharacterController controller;

    Vector3 inputDirection = Vector3.zero;
    Vector3 targetDirection = Vector3.zero;
    Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Animation Controller parameters for the character
        anim.SetBool("IsIdle", true);
        anim.SetBool("IsDance", false);
        //Time to start the animation
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //get the input from the keyboard
        float x = -(Input.GetAxis("Vertical"));
        float z = Input.GetAxis("Horizontal");
        inputDirection = new Vector3(x, 0, z);

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalk", true);
            Debug.Log("W key is pressed: " + IsWalk);
        }
        else if (Input.GetKey(KeyCode.S))
        {

            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsDance", false);
            Debug.Log("S key is pressed: " + IsIdle);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsDance", true);
            Debug.Log("D key is pressed: " + IsDance);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("IsDance", true);
            anim.SetBool("IsWalk", true);
            Debug.Log("A key is pressed: " + IsWalk);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("IsDance", true);
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsIdle", false);
            Debug.Log("Space key is pressed: " + IsWalk);
        }
    }
}