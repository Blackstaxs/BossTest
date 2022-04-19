using UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Projectile;
    public ObjectPool ProjectilePool;
    public Camera Cam;
    public NavMeshAgent Agent;
    public float ParallelProjectilesSpacing = 0.1f;
    public Vector3 ProjectileOffsetDirection = new Vector3(0, 0, 1.0f);
    public float ProjectileOffset = 0.5f;
    public float ProjectileForce = 32f;
    public float health;
    public int MaxHealth;
    public int damageTaken;

    //Memory References
    public MemorySO DoubleShot;
    private int parallelProjectiles;

    public MemorySO ChargeShot;
    private bool useChargeShot = false;
    
    
    private PlayerInput playerInput;
    private Vector3 mousePosition;
    private Vector3 directionMask = new Vector3(1.0f, 0.0f, 1.0f);
    private float playerDamage = 5;
    private string bossTag = "BOSS";
    private string wingTag = "WING";

    //UI
    public GameObject leftIndicator;
    public GameObject rightIndicator;
    public Canvas indicatorCanvas;

    private void OnEnable()
    {
        InitializeMemoryValues();
        
        //subscribe Inputs
        playerInput = new PlayerInput();
        playerInput.Enable();
        health = MaxHealth;

        if (useChargeShot)
        {
            playerInput.Testing.Charge.started += PlayerInput_onChargeBegin;
            playerInput.Testing.Charge.canceled += PlayerInput_onChargeRelease;
            playerInput.Testing.Charge.performed += PlayerInput_onChargeTimeout;
        }
        else
        {
            playerInput.Testing.Attack.performed += PlayerInput_onAttack;
        }
    }
    
    private void OnDisable()
    {
        //unsubscribe Inputs
        playerInput.Testing.Attack.performed -= PlayerInput_onAttack;
        playerInput.Disable();
    }

    void Start()
    {
        Projectile.GetComponent<PlayerBullet>().damageValue = playerDamage;
    }

    private void Update()
    {
        RaycastHit hit;
        mousePosition = playerInput.Testing.MousePosition.ReadValue<Vector2>();
        Ray ray = Cam.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //indicatorCanvas.transform.LookAt(new Vector3(hit.point.x, indicatorCanvas.transform.position.y, hit.point.z));
        }
    }

    void SpawnProjectiles()
    {
        Vector3 offset = new Vector3();
        GameObject projectile;
        Rigidbody rb;
        if (parallelProjectiles % 2 == 1)
        {
            projectile = ProjectilePool.GetPooledObject();
            if (projectile != null)
            {
                projectile.transform.position = (transform.forward * ProjectileOffset) + transform.position;//= transform.TransformPoint(ProjectileOffset);
                projectile.transform.rotation = transform.rotation;
                projectile.SetActive(true);
                rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * ProjectileForce, ForceMode.Impulse);
            }
            else
                Debug.Log("Out of ammo!");
        }
        
        //left
        for (int projectileIndex = 0; projectileIndex < parallelProjectiles / 2; projectileIndex++)
        {
            offset.x -= ParallelProjectilesSpacing;
            projectile = ProjectilePool.GetPooledObject();
            if (projectile != null)
            {
                projectile.transform.position = (transform.forward * ProjectileOffset) + transform.position +
                    (transform.TransformDirection(ProjectileOffsetDirection) * ProjectileOffset * projectileIndex);
                //transform.TransformPoint(position + ProjectileOffset);
                projectile.transform.rotation = transform.rotation;
                projectile.SetActive(true);
                rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * ProjectileForce, ForceMode.Impulse);
            }
        }
            
        //right
        offset = new Vector3();
        for (int projectileIndex = 0; projectileIndex < parallelProjectiles / 2; projectileIndex++)
        {
            offset.x += ParallelProjectilesSpacing;
            projectile = ProjectilePool.GetPooledObject();
            if (projectile != null)
            {
                projectile.transform.position = (transform.forward * ProjectileOffset) + transform.position +
                    (transform.TransformDirection(ProjectileOffsetDirection) * ProjectileOffset * projectileIndex);
                projectile.transform.rotation = transform.rotation;
                projectile.SetActive(true);
                rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            }
        }

    }

    public void InitializeMemoryValues()
    {
        parallelProjectiles = DoubleShot != null ? DoubleShot.IntValue : 1;
        useChargeShot = ChargeShot != null;
    }
    
    //Input

    private void PlayerInput_onAttack(InputAction.CallbackContext context)
    {
        Vector3 direction, bearing;
        Ray ray = Cam.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

        }
        direction = Vector3.Scale(directionMask, hit.point);
        direction.y = transform.position.y;
        Debug.DrawLine(ray.origin, transform.position, Color.blue, 100f);
        Debug.DrawLine(transform.position, hit.point, Color.green, 100f);

        bearing = transform.position + transform.forward;
        transform.LookAt(direction);

        SpawnProjectiles();

        transform.LookAt(bearing);
    }
    
    private void PlayerInput_onChargeBegin(InputAction.CallbackContext context)
    {
        leftIndicator.SetActive(true);
        rightIndicator.SetActive(true);
        leftIndicator.GetComponent<ChargeIndicator>().enabled = true;
        rightIndicator.GetComponent<ChargeIndicator>().enabled = true;
    }

    private void PlayerInput_onChargeRelease(InputAction.CallbackContext context)
    {
        //TODO change functionality so that it's not a mess
        float multiplier = leftIndicator.GetComponent<ChargeIndicator>().GetChargeMultiplier();
        multiplier = multiplier > 1 ? 1 : multiplier;
        Projectile.GetComponent<PlayerBullet>().damageValue = playerDamage * multiplier * ChargeShot.FloatValue;
        leftIndicator.SetActive(false);
        rightIndicator.SetActive(false);
        PlayerInput_onAttack(context);
    }
        
    private void PlayerInput_onChargeTimeout(InputAction.CallbackContext context)
    {
        leftIndicator.SetActive(false);
        rightIndicator.SetActive(false);
    }

    public float PlayerDamage
    {
        get => playerDamage;
        set => playerDamage = value;
    }

    private void OnParticleCollision(GameObject collision)
    {
        if (collision.CompareTag("WING"))
        {
            TakeDamage(damageTaken);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == bossTag)
        {
            TakeDamage(damageTaken);
        }
        if (collision.gameObject.tag == wingTag)
        {
            TakeDamage(damageTaken);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        gameObject.SetActive(false);

    }
}