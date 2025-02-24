using UnityEngine;

public class DestroyItems : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Blade")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {

    }
}

