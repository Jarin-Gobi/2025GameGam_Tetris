using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;
    public Vector2 dirVec;
    [SerializeField] public float speed;

    Rigidbody2D rb;
    Vector2 prevPos = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);

        dirVec = (rb.position - prevPos).normalized;
        prevPos = rb.position;
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
