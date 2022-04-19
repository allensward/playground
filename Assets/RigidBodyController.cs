using UnityEngine;

public class RigidBodyController : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    private bool isGrounded = true;
    private int jumpCount = 0;


    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Jumpforce;
    [SerializeField] private int MaxJumps;

    // Update is called once per frame
    private void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        Vector3 MoveVector;
        float sprintSpeed = Speed * 2.5f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveVector = transform.TransformDirection(PlayerMovementInput) * sprintSpeed;
        }
        else
        {
            MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        }

        //Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 2))
        {
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            jumpCount--;
        }

    }

    private void MovePlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "floor")
    //    {
    //        isGrounded = true;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.name == "floor")
    //    {
    //        isGrounded = false;
    //    }
    //}
}
