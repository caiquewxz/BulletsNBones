using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : Projectile
{
    public float rateOfFire;
    public float reloadCooldown;
    public bool canChangeFireMode;
    public int maxAmmoInMag;
    public int currentAmmoInMag;
    public int reserveAmmoInMag;
    public Text ammoText;
    public Text fireModeText;
    public AudioSource reloadSound;
    public AudioSource fireSound;
    private int ammoToReload;
    private bool isReloading;
    private float automaticFireTimer;
    private bool canAutoShoot;
    private bool automaticFireMode;
    private GameObject weapon;

    private void Start()
    {
        ChangeFireMode();
        SetCurrentAmmo(maxAmmoInMag);
        canAutoShoot = true;
        automaticFireTimer = rateOfFire;
    }

    void Update()
    {
        //single fire
        if ((Input.GetButtonDown("Fire1") && currentAmmoInMag > 0) && (!isReloading && !automaticFireMode))
        {
            Fire();
        }

        //full auto fire 
        automaticFireTimer += Time.deltaTime;

        if ((Input.GetButton("Fire1") && currentAmmoInMag > 0) && (!isReloading && automaticFireMode))
        {
            if (canAutoShoot)
            {
                StartCoroutine(AutomaticFire());
                automaticFireTimer = 0f;
                canAutoShoot = false;
            }
        }

        //reload
        if (reserveAmmoInMag > 0)
        {
            if ((Input.GetKeyDown(KeyCode.R) || currentAmmoInMag <= 0) && !isReloading)
            {
                StartCoroutine(Reload());
            }
        }

        //change fire mode
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeFireMode();
        }
    }

    IEnumerator Reload()
    {
        GameObject weapon = GameObject.FindWithTag("Weapon");

        if (currentAmmoInMag < maxAmmoInMag)
        {
            isReloading = true;
            Debug.Log("Reloading Ammo!");

            if (weapon != null)
            {
                reloadSound.Play();
            }

            yield return new WaitForSeconds(reloadCooldown);
            Debug.Log("Ammo Reloaded!");
            ammoToReload = maxAmmoInMag - currentAmmoInMag;

            if (reserveAmmoInMag < maxAmmoInMag)
            {
                ammoToReload = reserveAmmoInMag;
            }

            reserveAmmoInMag = reserveAmmoInMag - ammoToReload;

            if (reserveAmmoInMag < 0)
            {
                reserveAmmoInMag = 0;
            }

            Debug.Log("reserve ammo: " + reserveAmmoInMag);
            isReloading = false;
            SetCurrentAmmo(ammoToReload + currentAmmoInMag);
        }
    }

    private void Fire()
    {
        SetCurrentAmmo(currentAmmoInMag - 1);
        //passar logica de add force e timeToDie para projetil
        CreateBullet();
        fireSound.Play();
        Debug.Log("atual ammo in mag: " + currentAmmoInMag);
    }

    IEnumerator AutomaticFire()
    {
        SetCurrentAmmo(currentAmmoInMag - 1);
        //passar logica de add force e timeToDie para projetil
        CreateBullet();
        fireSound.Play();
        Debug.Log("atual ammo in mag: " + currentAmmoInMag);
        yield return new WaitForSeconds(rateOfFire);
        canAutoShoot = true;
    }

    private void SetCurrentAmmo(int ammo)
    {
        currentAmmoInMag = ammo;
        UpdateAmmoText();
    }

    private void UpdateFireModeText()
    {
        if (automaticFireMode)
        {
            fireModeText.text = "full auto mode";
        }
        else
        {
            fireModeText.text = "single fire mode";
        }
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + currentAmmoInMag + "/" + reserveAmmoInMag;
    }

    private void ChangeFireMode()
    {
        if (canChangeFireMode)
        {
            automaticFireMode = !automaticFireMode;
            UpdateFireModeText();
        }
    }
}