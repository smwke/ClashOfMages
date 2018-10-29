using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Unit thisUnit;

    [SerializeField]
    Transform _camera;
    [SerializeField]
    ParticleSystem slash;

    CharacterController controller;
    Animator anim;

    public GameObject[] spells;
    Spell[] spellObj = new Spell[4];

    float vInput, hInput, timer = 0f;
    bool isWalking = false, isAttacking = false;

    void Start()
    {
        foreach(var spell in spells)
        {
            var obj = Instantiate(spell, transform);
            spellObj[0] = obj.gameObject.GetComponent<Spell>();
        }

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        thisUnit = GetComponent<Unit>();
    }

    void Update()
    {
        vInput = Input.GetAxisRaw("Vertical");
        hInput = Input.GetAxisRaw("Horizontal");

        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && !isAttacking && timer >= 3) Attack();

        Spells(); // gets spell casting input /
        Rotate(); // get rotation vector and set the walking bool to true if we are moving /
        Move(); // moves the character according to previous booleans /



        ///if (isWalking) controller.Move(transform.forward * Time.deltaTime * moveSpeed); /
    }
    void Spells()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            CastSpell(0);
        }
    }
    void CastSpell(int id)
    {
        if (timer >= spellObj[id].coolDown)
        {
            Debug.Log("A spell should be succesfully casted!");
            timer = 0f;
            spellObj[id].CastSpell();
        }
    }
    void Attack()
    {
        isAttacking = true;
        anim.SetBool("Attack", isAttacking);
        anim.SetLayerWeight(1, 1);
        slash.Play();
        timer = 0f;
    }
    public void AttackDone()
    {
        isAttacking = false;
        anim.SetBool("Attack", isAttacking);
        anim.SetLayerWeight(1, Mathf.Lerp(1,0,Time.deltaTime));
        
    }
    void Move()
    {
        anim.SetBool("Walk", isWalking);

        if (Input.GetKey(KeyCode.LeftShift) && !isAttacking)
        {
            anim.SetBool("Sprint", true);
            if (isWalking) controller.Move(transform.forward * Time.deltaTime * thisUnit.sprintSpeed);
        }
        else
        {
            anim.SetBool("Sprint", false);
            if (isWalking) controller.Move(transform.forward * Time.deltaTime * thisUnit.moveSpeed);
        }
    }
    void Rotate()
    {
        float _rotSpeed = thisUnit.rotSpeed * Time.deltaTime;

        if (vInput > 0 && hInput == 0)// Forward movement /
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, _camera.eulerAngles.y, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput > 0 && hInput > 0)//Forward-right movement /
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, _camera.eulerAngles.y + 45, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput > 0 && hInput < 0)//Forward-left movement /
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, _camera.eulerAngles.y - 45, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput == 0 && hInput > 0)//Right movement /
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, _camera.eulerAngles.y + 90, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput == 0 && hInput < 0)//Left movement /
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, _camera.eulerAngles.y - 90, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput < 0 && hInput == 0)//Back movement /
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, _camera.eulerAngles.y + 180, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput < 0 && hInput > 0)//Back-right movement /
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, _camera.eulerAngles.y + 135, 0f), _rotSpeed); isWalking = true;
        }
        else if (vInput < 0 && hInput < 0)//Back-left movement /
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, _camera.eulerAngles.y - 135, 0f), _rotSpeed); isWalking = true;
        }
        else
        {
            isWalking = false;
        }

    }
}
