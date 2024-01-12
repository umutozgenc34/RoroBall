using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;

    [SerializeField] private Button kickButton;
    [SerializeField] private float kickForce = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        kickButton.onClick.AddListener(KickBall);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        Vector2 direction = new Vector2(movementJoystick.joystickVec.x, movementJoystick.joystickVec.y).normalized;
        rb.velocity = direction * playerSpeed;
    }

    void KickBall()
    {
        
        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, playerCollider.bounds.size, 0);

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Ball"))
            {
                Rigidbody2D ballRb = collider.GetComponent<Rigidbody2D>();
                if (ballRb != null)
                {
                    
                    Vector2 kickDirection = (ballRb.transform.position - transform.position).normalized;
                    ballRb.AddForce(kickDirection * kickForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}

