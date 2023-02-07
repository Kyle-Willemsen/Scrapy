using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WBMovement : MonoBehaviour
{
    Camera cam;
    private CharacterController controller;
    public GameObject humanoidForm;
    public GameObject wbForm;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float wbSpeed;
    [SerializeField] float gpMovingSpeed;
    private float currentSpeed;

    private Vector3 velocity;
    private bool isGrounded;
    private float gravityValue = -9.81f;
    private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckWB;
    private Ray mousePos;
    private Vector3 pointToLook;
    private bool canChangeState = true;
    [HideInInspector] public Vector3 facingfDir;

    [Header("Charge")]
    private bool isCharging;
    [SerializeField] float chargeTime;
    [SerializeField] float chargeSpeed;
    [SerializeField] int chargeDamage;
    private bool canCharge = true;
    [SerializeField] float chargeCooldownTimer;


    [Header("GroundPound")]
    [SerializeField] float gpSpeed;
    [SerializeField] float gpTime;
    [SerializeField] float gpRadius;
    [SerializeField] int gpDamage;
    [SerializeField] int gpShieldDamage;
    [SerializeField] float gpHeight;
    private bool canGroundPound = true;

    //UI
    public GameObject ammunitionUI;
    public GameObject wreckingballUI;
    public Image chargeCooldownImage;
    public Image groundPoundCooldownImage;
    [SerializeField] float gpTimer;
    [SerializeField] float chargeTimer;

    private bool alreadyHit;
    public float camShake;
    public float camShakeTime;

    private void Awake()
    {
        controller = GetComponentInParent<CharacterController>();
        cam = Camera.main;
    }

    public void Start()
    {
        chargeCooldownImage.fillAmount = 0f;
        currentSpeed = wbSpeed;
    }

    private void Update()
    {
        ChangeForm();
        Movement();
        MouseLook();
        Gravity();
        Charge();
        GroundPound();
    }

    private void ChangeForm()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canChangeState == true)
        {
            humanoidForm.SetActive(true);
            wbForm.SetActive(false);
            controller.height = 2f;
            wreckingballUI.SetActive(false);
            ammunitionUI.SetActive(true);
        }
    }

    public void Movement()
    {
        facingfDir = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);

        if (!isCharging)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * currentSpeed);

            if (move != Vector3.zero)
            {
                transform.LookAt(facingfDir);
            }
        }
    }
    private void MouseLook()
    {
        if (!isCharging)
        {
            mousePos = cam.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(mousePos, out rayLength))
            {
                 pointToLook = mousePos.GetPoint(rayLength);
                 transform.LookAt(facingfDir);
            }
        }
    }


    public void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheckWB.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Charge()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded && canCharge)
        {
            StartCoroutine(ChargeCoroutine());
            chargeTimer = chargeCooldownTimer;
        }

        if (chargeTimer < 0)
        {
            chargeTimer = 0f;
            chargeCooldownImage.fillAmount = 0.0f;
        }
        else
        {
            chargeTimer -= Time.deltaTime;
            chargeCooldownImage.fillAmount = chargeTimer / chargeCooldownTimer;
        }
    }
    public void GroundPound()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && canGroundPound && isGrounded)
        {
            StartCoroutine(GroundPoundCoroutine());
            gpTimer = chargeCooldownTimer;
        }

        if (gpTimer < 0)
        {
            gpTimer = 0f;
            groundPoundCooldownImage.fillAmount = 0.0f;
        }
        else
        {
            gpTimer -= Time.deltaTime;
            groundPoundCooldownImage.fillAmount = gpTimer / chargeCooldownTimer;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (alreadyHit) return;
        Debug.Log("registering colldier");

        if (hit.gameObject.tag == "Enemy" && isCharging)
        {
            Debug.Log("knock");
            hit.gameObject.GetComponent<EnemyStats>().EnemyTakeDamage(chargeDamage);
            alreadyHit = true;
            hit.gameObject.GetComponent<EnemyAI>().Knockback(facingfDir);
        }
        if (hit.gameObject.tag == "Shield" && isCharging)
        {
            hit.gameObject.GetComponent<Shield>().ShieldTakeDamage(chargeDamage);
            alreadyHit = true;
        }
    }

    private void CheckForDestructables()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, gpRadius, enemyLayerMask);
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<EnemyStats>())
            {
                c.GetComponent<EnemyStats>().EnemyTakeDamage(gpDamage);
                alreadyHit = true;
                
            }
            else if (c.GetComponentInChildren<Shield>())
            {
                c.GetComponentInChildren<Shield>().ShieldTakeDamage(gpShieldDamage);
                alreadyHit = true;
            }
        }
    }

    public IEnumerator ChargeCoroutine()
    {
        canCharge = false;
        isCharging = true;
        canChangeState = false;
        float startTime = Time.time;
        while (Time.time < startTime + chargeTime)
        {
            controller.Move(chargeSpeed * transform.forward * Time.deltaTime);
            yield return null;
        }
        alreadyHit = false;
        canChangeState = true;
        isCharging = false;
        yield return new WaitForSeconds(chargeCooldownTimer);
        canCharge = true;
    }

    public IEnumerator GroundPoundCoroutine()
    {
        canGroundPound = false;
        canChangeState = false;
        float startTime = Time.time;
        while (Time.time < startTime + gpTime)
        {
            velocity.y = gpHeight;
            currentSpeed = gpMovingSpeed;
            yield return new WaitForSeconds(0.45f);
            velocity.y = -2f * gpSpeed;
            if (!alreadyHit)
            {
                CheckForDestructables();
            }
            CameraShake.Instance.ShakeCamera(camShake, camShakeTime);
            alreadyHit = false;
            currentSpeed = wbSpeed;
    
            yield return new WaitForSeconds(chargeCooldownTimer);
        }
        canGroundPound = true;
        canChangeState = true;
    }
}
