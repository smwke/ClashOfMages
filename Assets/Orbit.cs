using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    Transform target; float speed = 100f;

    [SerializeField]
    float rotspeed = 1f;
    private void Start()
    {
    }
    void LateUpdate()
    {
        transform.parent = null;

        transform.position = Vector3.Lerp(transform.position,target.position - target.forward*2,rotspeed * Time.deltaTime);
        
    }

}
