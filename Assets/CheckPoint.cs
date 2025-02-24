using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().SetCheckpoint(transform.position);
        }
    }
}
