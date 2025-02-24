using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GestionBall gestionBall = GetComponentInParent<GestionBall>();
            if (gestionBall != null)
            {
                gestionBall.CollectBalloon();
            }

            gameObject.SetActive(false);
        }
    }
}
