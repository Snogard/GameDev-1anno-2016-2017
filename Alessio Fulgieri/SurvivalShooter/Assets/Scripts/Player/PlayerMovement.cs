using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public LayerMask floorMask;

    private Animator _anim;
    private Rigidbody _rg;
    private float _camRayLength = 100.0f;

    public float sensitivityX = 5f;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rg = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Rotate();
        Animating(h, v);
    }

    private void Move(float h, float v)
    {

        Vector3 moveDirection;
        moveDirection = new Vector3(speed * h, 0, speed * v);
        moveDirection = transform.TransformDirection(moveDirection) * Time.fixedDeltaTime;
        _rg.MovePosition(transform.position + moveDirection);


    }

    private void Rotate()
    {


        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);

    }

    private void Animating(float h, float v)
    {
        bool walking = (h != 0 || v != 0);
        _anim.SetBool("IsWalking", walking);
    }
}
