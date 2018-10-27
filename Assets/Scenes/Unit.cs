using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public float Health;

    public float moveSpeed = 2.5f, sprintSpeed = 5f, rotSpeed = 10f;


    void TakeDamage(float damage)
    {
        if (Health - damage <= 0) Die();
        else Health -= damage;
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
