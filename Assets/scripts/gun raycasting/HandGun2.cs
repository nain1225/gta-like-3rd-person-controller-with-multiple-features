using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun2 : MonoBehaviour
{
    public Camera cam;
    public float shootingDamage = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 10f;
    private float TimeToShoot = 0f;
    public bool isMoving;

    [Header("Partical Effect")]
    public ParticleSystem HandgunEffect;
    public GameObject metalEffect;

    [Header("Ammo Count &Animation")]
    public int mag = 10;
    public int maxAmmoCount = 25;
    private int presentAmmo;
    public float AmmoReloading = 4.3f;
    private bool SetLoading = false;
    public Transform hands;

    [Header("UI & Sounds")]
    public GameObject AmmoOutUI;

    public void Awake()
    {
        hands.SetParent(hands);
        Cursor.lockState = CursorLockMode.Locked;
        presentAmmo = maxAmmoCount;
    }
    void Update()
    {
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
                TimeToShoot = Time.time + 1f / fireCharge;
                Shooting();
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

        HandgunEffect.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, shootingRange))
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
        
        SetLoading = true;
        Debug.Log("Reloading.......");
        yield return new WaitForSeconds(AmmoReloading);
        Debug.Log("Done Reloading.......");
        presentAmmo = maxAmmoCount;
        SetLoading = false;
    }
    IEnumerator AmmoOut()
    {
        AmmoOutUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        AmmoOutUI.SetActive(false);
    }
}
