using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private Transform firstParent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            firstParent = collision.transform.parent;
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = firstParent;
        }
    }
}

