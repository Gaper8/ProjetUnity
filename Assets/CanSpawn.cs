using Unity.VisualScripting;
using UnityEngine;

public class CanSpawn : MonoBehaviour
{
    public GameObject CanPrefab;
    public GameObject Player;

    private float _timer = 0;
    private bool _isPlayerInZone = false;

    void Update()
    {
        if (_isPlayerInZone)
        {
            _timer += Time.deltaTime;
            if (_timer > 1)
            {
                GameObject can = Instantiate(CanPrefab);
                can.transform.position = transform.position;
                can.GetComponent<CanDestroy>().Player = Player;
                _timer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerInZone = false;
        }
    }
}

