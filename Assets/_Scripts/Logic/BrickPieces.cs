using UnityEngine;

public class BrickPieces : MonoBehaviour
{
    [SerializeField] Vector3 gravity;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(gravity);
    }
}
