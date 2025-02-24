using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private Vector3 lastCheckPoint;
    public Transform spawnPoint;
    public int respawnDelay;
    public float MoveSpeed;
    public float RotationSpeed;
    public float JumpHeight;

    private int _objectsUnderPlayer;

    private void Start()
    {
        if (spawnPoint != null)
        {
            lastCheckPoint = spawnPoint.position;
            transform.position = spawnPoint.position;
        }
        else
        {
            lastCheckPoint = transform.position;
        }
        health = maxHealth;
    }
    void Update()
    {

        transform.Rotate(new Vector3(0, Input.mousePositionDelta.x * RotationSpeed, 0));

        Vector3 CurrentSpeed =
             transform.forward * Input.GetAxis("Horizontal") * MoveSpeed + transform.right * -Input.GetAxis("Vertical") * MoveSpeed;

        CurrentSpeed.y = GetComponent<Rigidbody>().linearVelocity.y;

        GetComponent<Rigidbody>().linearVelocity = CurrentSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            CurrentSpeed.y += JumpHeight;
        }

        GetComponent<Rigidbody>().linearVelocity = CurrentSpeed;
    }

    bool IsGrounded()
    {
        float raycastDistance = 0.2f;
        Vector3 origin = transform.position + Vector3.up * 0.1f;

        return Physics.Raycast(origin, Vector3.down, raycastDistance);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            Respawn();
        }
    }

    public void SetCheckpoint(Vector3 checkpoint)
    {
        lastCheckPoint = checkpoint;
    }

    public void Respawn()
    {
        health = maxHealth;
        transform.parent = null;
        transform.position = lastCheckPoint;

        Object.FindFirstObjectByType<HealthBar>().UpdateHealthBar(health, maxHealth);

        foreach (GameObject can in GameObject.FindGameObjectsWithTag("Can"))
        {
            Destroy(can);
        }
}

public void Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        _objectsUnderPlayer++;
        Debug.Log("Touché le sol, objets sous le joueur : " + _objectsUnderPlayer);
    }
    private void OnTriggerExit(Collider other)
    {
        _objectsUnderPlayer--;
        Debug.Log("Sorti du contact, objets sous le joueur : " + _objectsUnderPlayer);
    }
}
