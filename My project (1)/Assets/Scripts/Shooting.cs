using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Shooting : MonoBehaviour
{
    public new string name;
    //public GameObject prefab;
    //public Sprite image;
    //[TextArea] public string description;
    public Transform gunbarell;
    public GameObject bullet;
    public float bulletSpeed;
    public float resetShot;
    public float reloadTime;
    public float fireRate;
    public float bulletsLeft;
    public float magazineSize;
    public bool shooting;
    public bool automatic;
    public bool reloading;
    public bool canShoot;
   [SerializeField] private float reloadTimer;

    public TextMeshProUGUI textBullets;
    public Image bulletCooldownImage;
    //public Image launcherCooldown;
    public VisualEffect muzzleFlash;

    public float explosionShake;
    public float explosionShakeTime;




    public void Awake()
    {
        bulletsLeft = magazineSize;
        canShoot = true;
    }

    private void Start()
    {
        bulletCooldownImage.fillAmount = 0.0f;
    }


    public void Update()
    {
        MyInput();
        textBullets.SetText(bulletsLeft + "/" + magazineSize);
        if (reloadTimer < 0)
        {
            reloadTimer = 0f;
            bulletCooldownImage.fillAmount = 0.0f;
        }
        else
        {
            reloadTimer -= Time.deltaTime;
            bulletCooldownImage.fillAmount = reloadTimer / reloadTime;
        }
    }

    public void MyInput()
    {
        if (automatic) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (shooting && !reloading && canShoot && bulletsLeft > 0)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && !reloading && bulletsLeft < magazineSize)
        {
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }
    }

    public void Shoot()
    {
        bulletsLeft--;
        canShoot = false;
        Invoke("FireRate", fireRate);

        var currentBullet = Instantiate(bullet, gunbarell.position, gunbarell.rotation);
        currentBullet.GetComponent<Rigidbody>().velocity = gunbarell.forward * bulletSpeed;
        muzzleFlash.Play();
        CameraShake.Instance.ShakeCamera(explosionShake, explosionShakeTime);
    }


    public void Reload()
    {
        reloading = true;
        canShoot = false;
        Invoke("ReloadFinished", reloadTime);
        reloadTimer = reloadTime;

    }


    public void FireRate()
    {
        canShoot = true;
    }

    public void ReloadFinished()
    {
        canShoot = true;
        reloading = false;
        bulletsLeft = magazineSize;
    }
}
