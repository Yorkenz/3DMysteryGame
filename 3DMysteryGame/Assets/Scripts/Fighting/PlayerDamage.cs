using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileSpawner : MonoBehaviour
{
    // Reference to PlayerInput and InputAction for shooting
    private PlayerInput playerInput;
    public InputActionReference Action;

    public GameObject projectilePrefab; // Assign prefab in Inspector
    [Header("Projectile Settings")]
    public float AttackSpeed = 10f;
    public float AttackCoolDown = 0.5f; // Time between shots
    public float bulletLifetime = 2f;
    

    private float spawnDistance = 2f; // Distance in front of camera
    //timer to track cooldown
    float timer = 0;
    private Animation anim;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        anim = gameObject.GetComponent<Animation>();
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (Action.action.IsPressed() && timer > AttackCoolDown) // When clicking
        {
            timer = 0;
            SpawnProjectile();
            // anim.Play("attack Anim"); Attack animation

        }
        
    }

    void SpawnProjectile()
    {
        // 1. Calculate spawn position and rotation based on camera
        Vector3 spawnPosition = transform.position + transform.forward + new Vector3(0, .5f, 0) * spawnDistance;
        GameObject Projectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);
        // 2. Add speed forward
        Rigidbody rb = Projectile.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * AttackSpeed, ForceMode.VelocityChange);
        // 3. Destroy after lifetime
        Destroy(Projectile, bulletLifetime);
    }

}

