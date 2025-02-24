using UnityEngine;

public class GestionBall : MonoBehaviour
{
    public GameObject wall;
    private Ball[] allBalloons;
    private int collectedBalloons = 0;

    void Start()
    {
        allBalloons = GetComponentsInChildren<Ball>();
    }

    public void CollectBalloon()
    {
        collectedBalloons++;

        if (collectedBalloons >= allBalloons.Length)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (wall != null)
        {
            wall.SetActive(false);
        }
    }

    private void OnEnable()
    {
        collectedBalloons = 0;

        foreach (Ball ballon in allBalloons)
        {
            ballon.gameObject.SetActive(true);
        }
    }
}
