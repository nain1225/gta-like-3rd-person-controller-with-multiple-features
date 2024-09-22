using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    //movement variables
    [Header("Player controls")]
    public Transform cam;
    public float speed = 1.1f;
    public float sprint = 5f;
    public Transform TransformPlayer;

    [Header("Animations & Gravity")]
    public CharacterController cc;
    public Animator animator;
    public float SurfaceRadius = 0.3f;
    public Vector3 surfaceCheckoffset;
    public LayerMask surfaceLayer;
    bool onground;

    public float gravity = -9.81f;
    Vector3 velocity;

    [Header("Player jumping & velocity")]
    public float turn_time = 0.1f;
    float turn_velocity;
    public float jumping_range = 1f;

    [Header("RayCast Info")]
    public float rayLength = 0.9f;
    public float heightRayLength = 0.9f;
    public Vector3 rayoffset = new Vector3(0, 0.9f, 0);
    public LayerMask obstacleLayer;

    //shooting variables
    public Camera camm;
    public float shootingDamage = 15f;
    public float shootingRange = 100f;
    public float fireCharge = 2f;
    private float TimeToShoot = 0f;
    public bool isMoving;

    [Header("Partical Effect")]
    public ParticleSystem HandgunEffect;
    public GameObject metalEffect;

    [Header("Ammo Count &Animation")]
    public int mag = 10;
    public int maxAmmoCount = 7;
    private int presentAmmo;
    public float AmmoReloading = 1.3f;
    private bool SetLoading = false;
    public Transform hands;

    [Header("UI & Sounds")]
    public GameObject AmmoOutUI;
    bool isShotGunActive = true;
    public GameObject AmmoUi;

    public void Awake()
    {
        AmmoUi.SetActive(true);
        hands.SetParent(hands);
        Cursor.lockState = CursorLockMode.Locked;
        presentAmmo = maxAmmoCount;
    }
    void Update()
    {
        if (isShotGunActive == true)
        {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("ShootGunContoller");
        }

        playermove();
        SurfaceCheck();

        Jump();
        ApplyGravity();
        sprinting();
        //Debug.Log("Player on surface" + onground);
        if (SetLoading)
            return;
        if (presentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (isMoving == false)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= TimeToShoot)
            {
                animator.SetBool("shoot", true);
                TimeToShoot = Time.time + 1f / fireCharge;
                Shooting();
            }
            else
            {
                animator.SetBool("shoot", false);
            }
        }

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
            animator.SetBool("walkforward", true);
            animator.SetBool("RunForward", false);
            jumping_range = 0;

            float target_rotation = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float rot_smoothness = Mathf.SmoothDampAngle(TransformPlayer.eulerAngles.y, target_rotation, ref turn_velocity, turn_time);
            TransformPlayer.rotation = Quaternion.Euler(0f, rot_smoothness, 0f);
            Vector3 cam_rot = Quaternion.Euler(0f, target_rotation, 0f) * Vector3.forward;
            cc.Move(cam_rot * speed * Time.deltaTime);

            isMoving = true;
        }
        else
        {
            animator.SetBool("walkforward", false);
            animator.SetBool("RunForward", false);
            jumping_range = 2f;
            isMoving = false;
        }
        //animator.SetFloat("MovementValues", movementAmount, 0.1f, Time.deltaTime);
    }
    void SurfaceCheck()
    {
        onground = Physics.CheckSphere(TransformPlayer.position, SurfaceRadius, surfaceLayer);
        //Debug.Log("surface checker viewed" + onground);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onground == true)
        {
            animator.SetBool("IdleAim", false);
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumping_range * -2 * gravity);
            Debug.Log("now ready to jump");
            jumping_range = 0;
        }
        else
        {
            animator.SetBool("IdleAim", true);
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
                animator.SetBool("RunForward", true);
                animator.SetBool("walkforward", false);
                float target_rotation = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float rot_smoothness = Mathf.SmoothDampAngle(TransformPlayer.eulerAngles.y, target_rotation, ref turn_velocity, turn_time);
                TransformPlayer.rotation = Quaternion.Euler(0f, rot_smoothness, 0f);
                Vector3 cam_rot = Quaternion.Euler(0f, target_rotation, 0f) * Vector3.forward;
                cc.Move(cam_rot * sprint * Time.deltaTime);
                jumping_range = 0;
                isMoving = true;
            }
            else
            {
                animator.SetBool("RunForward", false);
                animator.SetBool("walkforward", true);
                jumping_range = 2f;
                isMoving = false;
            }
        }
    }
    void Shooting()
    {
        if (mag == 0)
        {
            StartCoroutine(AmmoOut());
            return;
        }
        presentAmmo--;
        if (presentAmmo == 0)
        {
            mag--;

        }
        //update ui
        AmmoCount.instance.UpdateAmmoCount(presentAmmo);
        AmmoCount.instance.UpdateMagCount(mag);

        HandgunEffect.Play();

        if (Physics.Raycast(camm.transform.position, camm.transform.forward, out RaycastHit hitInfo, shootingRange))
        {
            Debug.Log(hitInfo.transform.name);

            ObjDamageCount objDamageCount = hitInfo.transform.GetComponent<ObjDamageCount>();
            if (objDamageCount != null)
            {
                objDamageCount.DamageCount(shootingDamage);
                GameObject effect = Instantiate(metalEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(effect, 1f);
            }

        }
    }
    IEnumerator Reload()
    {
        speed = 0f;
        sprint = 0f;
        SetLoading = true;
        Debug.Log("Reloading.......");
        animator.SetBool("Reload", true);

        yield return new WaitForSeconds(AmmoReloading);
        Debug.Log("Done Reloading.......");
        animator.SetBool("Reload", false);

        presentAmmo = maxAmmoCount;
        speed = 1.1f;
        sprint = 5f;
        SetLoading = false;
    }
    IEnumerator AmmoOut()
    {
        AmmoOutUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        AmmoOutUI.SetActive(false);
    }
}
