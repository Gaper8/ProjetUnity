using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image lifeFill;
    public Transform player;
    public Vector3 LifeFillOverPlayer;

    private PlayerController playerController;

    void Start()
    {
            playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player == null) return;

        transform.position = player.position + LifeFillOverPlayer;

        UpdateHealthBar(playerController.health, playerController.maxHealth);
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {

        float healthPercentage = (float)currentHealth / maxHealth;
        lifeFill.fillAmount = Mathf.Clamp01(healthPercentage);

        if (healthPercentage > 0.6f)
        {
            lifeFill.color = Color.green;
        }
        else if (healthPercentage > 0.3f)
        {
            lifeFill.color = Color.yellow;
        }
        else
        {
            lifeFill.color = Color.red;
        }
    }
}
