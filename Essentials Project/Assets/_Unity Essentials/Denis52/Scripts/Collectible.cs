using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float _rotateX = 0f;
    [SerializeField] private float _rotateY = 1f;
    [SerializeField] private float _rotateZ = 0f;

    private void Update()
    {
        transform.Rotate(_rotateX, _rotateY, _rotateZ);
        
    }
}
