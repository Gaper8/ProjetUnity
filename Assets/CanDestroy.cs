using UnityEngine;
using UnityEngine.AI;

public class CanDestroy : MonoBehaviour
{
    public int damage;
    public int HealthCan;
    private int StartLifePoint;

    public GameObject FirePrefab;
    public GameObject Player;

    public GameObject Animator;

    private void Start()
    {
        StartLifePoint = HealthCan;
        GetComponent<NavMeshAgent>().Warp(transform.position);
        Player = GameObject.FindGameObjectWithTag("Player");

}
private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Blade")
        {
            HealthCan--;
        }

        if (HealthCan <= 0)
        {
            Destroy(gameObject, 1.5f);
            GameObject fire = Instantiate(FirePrefab);
            fire.transform.position = transform.position;
            Destroy(fire, 5);
            Animator.GetComponent<Animator>().SetTrigger("IsDead");
            GetComponent<NavMeshAgent>().enabled = false;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}

