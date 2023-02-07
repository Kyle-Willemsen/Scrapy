using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    public bool shootingExplosives;
    private float currentAmmo;
    public float maxAmmo;
    public GameObject bullet;
    public Transform barrel;
    public float bulletSpeed;
    public float fireRate;
    public float reloadTime;
    public float reloadCounter;
    public bool canShoot = true;
    public float CurrentAmmo { get { return currentAmmo; } set { currentAmmo = Mathf.Clamp(value, 0, maxAmmo); } }

    public TextMeshProUGUI launcherText;
    public Image launcherCooldownImage;

    private void Start()
    {
        CurrentAmmo = maxAmmo;
        reloadCounter = reloadTime;
        launcherCooldownImage.fillAmount = 0.0f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && CurrentAmmo > 0 && canShoot)
        {
            Shooting();
        }

        if (CurrentAmmo < maxAmmo)
        {
            reloadCounter -= Time.deltaTime;
            launcherCooldownImage.fillAmount = reloadCounter / reloadTime;
        }

        if (reloadCounter <= 0)
        {
            reloadCounter = 0;
            Timer();
            launcherCooldownImage.fillAmount = 0.0f;
        }
        launcherText.SetText(currentAmmo + "/" + maxAmmo);
    }

    public void Shooting()
    {
        canShoot = false;
        var currentBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        currentBullet.GetComponent<Rigidbody>().velocity = barrel.forward * bulletSpeed;
        currentAmmo--;
        Invoke("ResetShot", fireRate);
    }

    void ResetShot()
    {
        canShoot = true;
    }

    private void Timer()
    {
        CurrentAmmo++;
        reloadCounter = reloadTime;
    }
}
