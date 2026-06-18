using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData data;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput = movementInput.normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementInput.x * data.DataClass.walkSpeed, movementInput.y * data.DataClass.walkSpeed);
    }
}
