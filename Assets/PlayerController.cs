using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 4f, rotSpeed = 10f;

    [SerializeField]
    Transform camera;

    CharacterController controller;
    Animator anim;

    float vInput, hInput;
    bool isWalking = false;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxisRaw("Vertical");
        hInput = Input.GetAxisRaw("Horizontal");

        Rotate();

        anim.SetBool("Walk", isWalking);
        anim.SetBool("Sprint", Input.GetKey(KeyCode.LeftShift));

        if (isWalking) controller.Move(transform.forward * Time.deltaTime * moveSpeed);
    }
    void Rotate()
    {

        float _rotSpeed = rotSpeed * Time.deltaTime;

        if (vInput > 0 && hInput == 0)// Forward movement
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camera.eulerAngles.y, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput > 0 && hInput > 0)//Forward-right movement
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camera.eulerAngles.y + 45, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput > 0 && hInput < 0)//Forward-left movement
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camera.eulerAngles.y - 45, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput == 0 && hInput > 0)//Right movement
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camera.eulerAngles.y + 90, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput == 0 && hInput < 0)//Left movement
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camera.eulerAngles.y - 90, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput < 0 && hInput == 0)//Back movement
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camera.eulerAngles.y + 180, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput < 0 && hInput > 0)//Back-right movement
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camera.eulerAngles.y + 135, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput < 0 && hInput < 0)//Back-left movement
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camera.eulerAngles.y - 135, 0f), _rotSpeed); isWalking = true;
        }
        else
        {
            isWalking = false;
        }

    }
}
