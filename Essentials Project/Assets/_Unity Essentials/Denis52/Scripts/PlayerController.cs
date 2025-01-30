using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _rotationSpeed = 120f;
    [SerializeField] private float jumpForce = 5.0f;

    private Rigidbody _rigidbody;
    private int _jumpCount  = 0;
    private int _maxJumps = 2;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Jump();
        MovePlayer();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _jumpCount < _maxJumps)
        {
            _jumpCount++;
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void MovePlayer()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);

        float turn = Input.GetAxis("Horizontal") * _rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        _rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        _jumpCount = 0;
    }
}