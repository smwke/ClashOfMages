using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float speed = 50f;

   
    ConfigurableJoint joint;

    [SerializeField]
    float rotspeed = 1f;
    float timer = 0f;
    bool updown = true;
    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
    }
    void LateUpdate()
    {
        timer += Time.deltaTime;
        
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
        joint.targetPosition = transform.position;

        Spring();
    }
    void Spring()
    {
        if ( timer >= 0.5 && updown) {
            //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 1, transform.position.z), rotspeed * Time.deltaTime);
            joint.targetPosition = new Vector3(transform.position.x,1,transform.position.z);
            timer = 0f;
            updown = false;
        }

        if (timer >= 0.5 && !updown)
        {
            //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -1, transform.position.z), rotspeed * Time.deltaTime);
            joint.targetPosition = new Vector3(transform.position.x, -1, transform.position.z);
            timer = 0f;
            updown = true;
        }

    }

}
