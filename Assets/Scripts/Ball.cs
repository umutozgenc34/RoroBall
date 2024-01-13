using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float maxSpeed = 10f;
    public float slowdownRate = 0.1f;
    private float timeSinceLastCollision = 0f;
    private Rigidbody2D rb;

    [SerializeField] private TextMeshProUGUI redScoreText;
    [SerializeField] private TextMeshProUGUI blueScoreText;

    public int scoreRed;
    public int scoreBlue;

    public int maxScore = 3; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText();
    }

    void Update()
    {
        if (timeSinceLastCollision > 0f)
        {
            timeSinceLastCollision -= Time.deltaTime;
            if (timeSinceLastCollision <= 0f)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            timeSinceLastCollision = 5f;
            RotateBall();

            if (collision.gameObject.CompareTag("Goalpost") || collision.gameObject.CompareTag("Line"))
            {
                maxSpeed = 10f;
                RotateBall();
            }
        }
    }

    void RotateBall()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void UpdateScoreText()
    {
        redScoreText.text = scoreRed.ToString();
        blueScoreText.text = scoreBlue.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("RedGoalCheck"))
        {
            
            scoreBlue++;
            UpdateScoreText();
            EndGameManager.endManager.BlueScore();
            ResetBallPosition();
        }
        else if (other.CompareTag("BlueGoalCheck"))
        {
            
            scoreRed++;
            UpdateScoreText();
            EndGameManager.endManager.RedScore();
            ResetBallPosition();
        }

        
        if (scoreRed >= maxScore || scoreBlue >= maxScore)
        {
            EndGameManager.endManager.ResolveGame();
        }
    }

    void ResetBallPosition()
    {
        
        transform.position = Vector3.zero;
    }
}