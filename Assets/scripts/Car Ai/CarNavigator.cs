using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigator : MonoBehaviour
{
    [Header("Car Info")]
    public float movingSpeed;
    public float turnSpeed = 300f;
    public float stopSpeed = 1f;
    public GameObject Sensor;
    float detectionRange = 10f;

    [Header("Destination var")]
    public Vector3 destination;
    public bool destinationReached;
    public Player Player; 


    void Update()
    {
        RaycastHit hitinfo;
        if(Physics.Raycast(Sensor.transform.position,Sensor.transform.forward,out hitinfo, detectionRange))
        {
            Debug.Log(hitinfo.transform.name); 
            CharacterNavigatorScript characterNavigatorScript = hitinfo.transform.GetComponent<CharacterNavigatorScript>();
            Player player = hitinfo.transform.GetComponent<Player>();

            if(characterNavigatorScript!= null)
            {
                movingSpeed = 0f;
                return;
            }
            if (player != null)
            {
                movingSpeed = 0f;
                return;
            }
        }


        Drive();
    }

    public void Drive()
    {
        movingSpeed = 10f;
        if (transform.position != destination)
        {
            //direction
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopSpeed)
            {
                //rotaion
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

                //move charcter
                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
            }
            else
            {
                destinationReached = true;
                Debug.Log("reached");
            }
        }
    }
    public void locateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
}
