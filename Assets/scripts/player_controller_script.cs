using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller_script : MonoBehaviour
{
    [Header("Player controls")]
    public Transform cam;
    public float speed=1.1f;
    public float sprint = 5f;

    [Header("Player Health")]
    public float playerHealth = 200f;
    public float presentHealth;
    public HealthBar healthBar;

    [Header("Animations & Gravity")]
    public CharacterController cc;
    public Animator animator;
    public float SurfaceRadius = 0.3f;
    public Vector3 surfaceCheckoffset;
    public LayerMask surfaceLayer;
    bool onground;

    public float gravity = -9.81f;
    Vector3 velocity;
    // public float ground_distance = 0.4f;
    //public Transform ground_check;
    //public LayerMask mask;

    [Header("Player jumping & velocity")]
    public float turn_time = 0.1f;
    float turn_velocity;
    public float jumping_range = 1f;

    [Header("RayCast Info")]
    public float rayLength = 0.9f;
    public float heightRayLength = 0.9f;
    public Vector3 rayoffset = new Vector3(0, 0.9f, 0);
    public LayerMask obstacleLayer;
    bool isPlayerCOntrollerActive = true;

    public Player player;

    private void Awake()
    {
        /*if (MainMenu.instance.continueGame == true)
        {
            player.LoadPlayer();
        }*/
        Cursor.lockState = CursorLockMode.Locked;
        presentHealth = playerHealth;
        healthBar.setHealth(presentHealth);
    }
    void Update()
    {
        if (isPlayerCOntrollerActive == true)
        {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("PlayerController");
        }
        playermove();
        SurfaceCheck();
        //Debug.Log("Player on surface" + onground);
        Jump();
        ApplyGravity();
        CheckObstacle();
        sprinting();
    }

    void playermove()
    {
        float hv = Input.GetAxisRaw("Horizontal");
        float vv = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(hv, 0, vv);
        //var movementAmount = Mathf.Clamp01(Mathf.Abs(hv) + Mathf.Abs(vv));
        //transform.Translate( new Vector3(hv, 0,vv)*speed*Time.deltaTime);

    if (dir.magnitude >= 0.1f)
    {
            animator.SetBool("Walk",true);
            animator.SetBool("Running", false);
            jumping_range = 0;

            float target_rotation = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float rot_smoothness = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_rotation, ref turn_velocity, turn_time);
            transform.rotation = Quaternion.Euler(0f, rot_smoothness, 0f);
            Vector3 cam_rot = Quaternion.Euler(0f, target_rotation, 0f) * Vector3.forward;
            cc.Move(cam_rot * speed * Time.deltaTime);
    }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Running", false);
            jumping_range = 2f;
        }
        //animator.SetFloat("MovementValues", movementAmount, 0.1f, Time.deltaTime);
    }
    void SurfaceCheck()
    {
        onground = Physics.CheckSphere(transform.TransformPoint(surfaceCheckoffset), SurfaceRadius, surfaceLayer);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onground == true)
        {
            animator.SetBool("Idle", false);
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumping_range * -2 * gravity);
            Debug.Log("now ready to jump");
            jumping_range = 0;
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.ResetTrigger("Jump");
            jumping_range = 2f;
        }
    }
    void ApplyGravity()
    {
        // Apply gravity to the player's vertical velocity
        velocity.y += gravity * Time.deltaTime;

        // Move the player vertically based on velocity
        cc.Move(velocity * Time.deltaTime);

        // If the player is grounded, reset the vertical velocity to zero
        if (onground && velocity.y < 0)
        {
        velocity.y = 0f;
        }
    }
    ObstacleInfo CheckObstacle()
    {
        var hitdata = new ObstacleInfo();

        var rayOrign = transform.position + rayoffset;
        hitdata.hitfound = Physics.Raycast(rayOrign, transform.forward, out hitdata.hitInfo, rayLength, obstacleLayer);
        Debug.DrawRay(rayOrign, transform.forward * rayLength, (hitdata.hitfound) ? Color.red : Color.green);

        if (hitdata.hitfound)
        {
        var hieghtUpRayOrign = hitdata.hitInfo.point + Vector3.up * heightRayLength;
        hitdata.hiegtupHitfound = Physics.Raycast(hieghtUpRayOrign, Vector3.down, out hitdata.hieghtupInfo, heightRayLength, obstacleLayer);
        Debug.DrawRay(hieghtUpRayOrign, Vector3.down * heightRayLength, (hitdata.hiegtupHitfound) ? Color.blue : Color.green);

        /*var hieghtDownRayOrign = hitdata.hitInfo.point + Vector3.down * heightRayLength;
        hitdata.hiegtDownHitfound = Physics.Raycast(hieghtDownRayOrign, Vector3.up, out hitdata.hieghtDownHitInfo, heightRayLength, obstacleLayer);
        Debug.DrawRay(hieghtDownRayOrign, Vector3.up * heightRayLength, (hitdata.hiegtDownHitfound) ? Color.white : Color.green);*/
        }

        return hitdata;
    }
    struct ObstacleInfo
    {
        public bool hitfound;
        public RaycastHit hitInfo;
        public bool hiegtupHitfound;
        public RaycastHit hieghtupInfo;
        //public bool hiegtDownHitfound;
        //public RaycastHit hieghtDownHitInfo;
    }

    void sprinting()
    {
        if (Input.GetButton("Sprint") && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && onground)
        {
            float hv = Input.GetAxisRaw("Horizontal");
            float vv = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(hv, 0, vv);
            //var movementAmount = Mathf.Clamp01(Mathf.Abs(hv) + Mathf.Abs(vv));
            //transform.Translate( new Vector3(hv, 0,vv)*speed*Time.deltaTime);

            if (dir.magnitude >= 0.1f)
            {
                animator.SetBool("Running", true);
                animator.SetBool("Walk",false);
                float target_rotation = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float rot_smoothness = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_rotation, ref turn_velocity, turn_time);
                transform.rotation = Quaternion.Euler(0f, rot_smoothness, 0f);
                Vector3 cam_rot = Quaternion.Euler(0f, target_rotation, 0f) * Vector3.forward;
                cc.Move(cam_rot * sprint * Time.deltaTime);
                jumping_range = 0;
            }
            else
            {
                animator.SetBool("Running", false);
                animator.SetBool("Walk", true);
                jumping_range = 2f;
            }
        }
    }
    public void playerDamage(float takeDamage)
    {
        presentHealth -= takeDamage;
        healthBar.getHealth(presentHealth);
        if (presentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject, 1.0f);
    }
}
