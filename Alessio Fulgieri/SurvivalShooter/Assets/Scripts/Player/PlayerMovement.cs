using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    #region editor
    [SerializeField]
    private float _playerSpeed = 6f;

    /// <summary>
    /// valore del layer floor default floor
    /// </summary>
    [SerializeField]
    private LayerMask _floorMask;
    #endregion
    #region internal
    /// <summary>
    /// controller dell animazione
    /// </summary>
    private Animator _animationController;
    /// <summary>
    /// lunghezza del raycast
    /// </summary>
    private float _camRayLength = 100.0f;
    private Rigidbody _rg;
    #endregion

    void Awake()
    {
        _animationController = GetComponent<Animator>();
        _rg = GetComponent<Rigidbody>();
    }



    void Update()
    {

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
        Rotate();
        Animate(h, v);

    }

    //vector.normalized normalizza il vettore
    void Move(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0f, v);
        movement = movement.normalized * _playerSpeed * Time.deltaTime;
        _rg.MovePosition(transform.position + movement);

    }
    void Rotate()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); //restituisce

        RaycastHit floorHit;
        //                  Ray     RaycastHit    float          LayerMask
        if (Physics.Raycast(camRay, out floorHit, _camRayLength, _floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            _rg.MoveRotation(newRotation);
        }

    }
    void Animate(float h, float v)
    {
        _animationController.SetBool("isWalking", h != 0 || v != 0);
    }

}

