using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    [SerializeField]
    int Health;
    public float moveSpeed = 2.5f, sprintSpeed = 5f, rotSpeed = 10f;
}
