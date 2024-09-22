using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_person_controller : MonoBehaviour
{
    public float speed = 2f;
    public CharacterController cc;
    public float gravity = -9.8f;

    Vector3 velocity;
    bool onground;

    public float check_distance = 1f;
    public Transform check_point;
    public LayerMask check_mask;
    public float jumpheight = 5f;

    void Update()
    {
        float haxis = Input.GetAxis("Horizontal");
        float vaxis = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(haxis, 0, vaxis);
        cc.Move(dir * speed * Time.deltaTime);


        onground = Physics.CheckSphere(check_point.position,check_distance,check_mask);
        if(onground && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity;
        cc.Move(velocity * Time.deltaTime);

        if(Input.GetButton("Jump") && onground)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
            Debug.Log("jump pressed");
        }
    }
}
