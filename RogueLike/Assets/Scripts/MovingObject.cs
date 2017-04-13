using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]

public abstract class MovingObject : MonoBehaviour
{

    #region Inspector
    [SerializeField]
    float _moveTime = 0.1f;

    [SerializeField]
    LayerMask _blockingLayer;
    #endregion

    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidBody;
    private float _inverseMoveTime;//speed

    protected virtual void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _inverseMoveTime = 1f / _moveTime;
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemaibubgDistance = (transform.position - end).sqrMagnitude;
        while (sqrRemaibubgDistance > float.Epsilon)
        {

            Vector3 newPosition = Vector3.MoveTowards(_rigidBody.position, end, _inverseMoveTime * Time.deltaTime);
            _rigidBody.MovePosition(newPosition);
            sqrRemaibubgDistance = (transform.position - end).sqrMagnitude;

            yield return null; //dice di stopparsi a questo frame
        }


    }

    protected abstract void OnCantMove<T>(T component) where T : Component;

    protected abstract void OnMove();


    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = new Vector2(xDir, yDir);

        _boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, _blockingLayer);

        if (hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }

        return false;
    }

    protected virtual void AttemptMove<T>(int xDir, int yDir) where T : Component
    {
        RaycastHit2D hit;
        bool isMoving = Move(xDir, yDir,out hit);
        if (isMoving)
        {
            OnMove();
        }
        else
        {
            T hitComponent = GetComponent<T>();
            if(hitComponent!=null)
            {
                OnCantMove<T>(hitComponent);
            }
        }
    }
}
