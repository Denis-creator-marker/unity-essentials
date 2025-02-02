using UnityEngine;

public class PickUpItem : MonoBehaviour
{ 
    [SerializeField] private GameObject onCollectEffect;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            Destroy(gameObject);

            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }

    }
}
