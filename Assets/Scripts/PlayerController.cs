using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;
    public Vector2 dirVec;
    [SerializeField] public float speed;
    public Scanner scanner;
    private Animator animator;
    public Damageable damageable;
    [SerializeField] public GameObject[] toppings;

    Rigidbody2D rb;
    Vector2 prevPos = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        scanner = GetComponent<Scanner>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
    }
    public bool _isMoving = false;

    public bool IsMoving
    {
        get { return _isMoving; }
        private set
        {
            _isMoving = value;
            animator.SetBool("IsMoving", value);
        }
    }



    private void FixedUpdate()
    {
        if (!GameManager.Instance.isLive)
        {
            return;
        }
        if(damageable.IsAlive)
        {
            Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + nextVec);

            dirVec = (rb.position - prevPos).normalized;
            prevPos = rb.position;
        }
        else
        {
            SceneManager.LoadScene(2);
        }
       
    }

    private void OnMove(InputValue value)
    {
        if (!GameManager.Instance.isLive)
        {
            IsMoving = false;
            return;
        }
        inputVec = value.Get<Vector2>();
        if (!damageable.IsAlive)
        {
            IsMoving = false;
        }
        else IsMoving = inputVec != Vector2.zero;
    }

    public void OnTopping(int id)
    {
        if (toppings[id] != null)
            toppings[id].SetActive(true);
    }
}
