using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavigatorScript : MonoBehaviour
{
    [Header("Character Info")]
    public float movingSpeed;
    public float turnSpeed = 300f;
    public float stopSpeed = 1f;
    public float AiC_Health = 100f;
    public float presentHealth;
    public Animator animator;
    public Player player;

    [Header("Destination var")]
    public Vector3 destination;
    public bool destinationReached;

    private void Start()
    {
        presentHealth = AiC_Health;
    }
    void Update()
    {
        Walk();
        player = GameObject.FindObjectOfType<Player>();
    }

    public void Walk()
    {
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
    public void getAiC_Damage(float takeDamage)
    {
        presentHealth -= takeDamage;
        if (presentHealth <= 0)
        {
            Die();
            animator.SetBool("Die", true);

        }
    }
    private void Die()
    {
        movingSpeed = 0f;
        player.KillCount += 1;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        player.PlayerMoney += 5;
        //Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject, 4.0f);
    }
}
