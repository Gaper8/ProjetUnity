using UnityEngine;

public class ThrowBlade : MonoBehaviour
{
    public GameObject PrefabBlade;
    public float BladeThrowPower;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject Blade = Instantiate(PrefabBlade);
            Blade.transform.position = transform.position + new Vector3(-1, 2, 0);
            Blade.GetComponent<Rigidbody>().AddForce(transform.forward * BladeThrowPower);
        }
    }
}

