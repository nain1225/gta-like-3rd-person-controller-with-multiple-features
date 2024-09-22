using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangster01 : MonoBehaviour
{
    [Header("Character Info")]
    public float movingSpeed;
    public float runningSpeed;
    private float CurrentMovingSpeed;
    public float turnSpeed = 300f;
    public float stopSpeed = 1f;
    public float GangsterHealth = 100f;
    public float presentHealth;
    public GameObject bloodEffect;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool isdestinationReached;
    public Animator animator;

    [Header("Gangster Ai")]
    public GameObject Playerbody;
    public LayerMask PlayerLayer;
    public float shootingRadius;
    public float visionRadius;
    public bool playerInshootingRadius;
    public bool playerInvisionRadius;

    [Header("Gangster Shooting var")]
    public float giveDamageof = 6f;
    public float shootingRange = 300f;
    public GameObject ShootingRaycastArea;
    public float timebtwShoot;
    bool previouslyShoot;
    public Player player;

    private void Start()
    {
        Playerbody = GameObject.Find("player");
        presentHealth = GangsterHealth;
        CurrentMovingSpeed = movingSpeed;
        player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        playerInshootingRadius = Physics.CheckSphere(transform.position, shootingRadius, PlayerLayer);
        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, PlayerLayer);

        if (!playerInvisionRadius && !playerInshootingRadius)
        {
            Walk();
        }
        if (playerInvisionRadius && !playerInshootingRadius)
        {
            ChasePlayer();
        }
        if (playerInvisionRadius && playerInshootingRadius)
        {
            ShootPlayer();
        }
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
                isdestinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

                //move charcter
                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
                animator.SetBool("Walk", true);
                animator.SetBool("Run", false);
                animator.SetBool("Shoot", false);

            }
            else
            {
                isdestinationReached = true;
                //Debug.Log("reached");
            }
        }
    }
    public void locateDestination(Vector3 destination)
    {
        this.destination = destination;
        isdestinationReached = false;
    }
    public void ChasePlayer()
    {
        transform.position += transform.forward * CurrentMovingSpeed * Time.deltaTime;
        transform.LookAt(Playerbody.transform);

        CurrentMovingSpeed = runningSpeed;
        animator.SetBool("Walk", false);
        animator.SetBool("Run", true);
        animator.SetBool("Shoot", false);
    }
    public void ShootPlayer()
    {
        movingSpeed = 0f;
        //CurrentMovingSpeed = 0f;
        transform.LookAt(Playerbody.transform);
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
        animator.SetBool("Shoot", true);

        if (!previouslyShoot)
        {
            RaycastHit hit;
            if (Physics.Raycast(ShootingRaycastArea.transform.position, ShootingRaycastArea.transform.forward, out hit, shootingRange))
            {
                Debug.Log("Shooting" + hit.transform.name);

                player_controller_script player_ = hit.transform.GetComponent<player_controller_script>();
                if (player_ != null)
                {
                    player_.playerDamage(giveDamageof);
                    GameObject effect = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(effect, 1f);

                }
            }
            previouslyShoot = true;
            Invoke(nameof(ActivelyShooting), timebtwShoot);
        }

    }
    private void ActivelyShooting()
    {
        previouslyShoot = false;
    }

    public void getGangsterDamage(float takeDamage)
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
        shootingRange = 0f;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
       //player.KillCount += 1;
        player.PlayerMoney += 10;
        Object.Destroy(gameObject, 4.0f);
    }
}
