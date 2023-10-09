using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    private List<Transform> _snakeSpawn;
    public Transform snakePrefab;

    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed, 0);

        _snakeSpawn = new List<Transform>();
        _snakeSpawn.Add(this.transform);
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = new Vector2(0, moveSpeed);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.velocity = new Vector2(0, -moveSpeed);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.velocity = new Vector2(moveSpeed, 0);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.velocity = new Vector2(-moveSpeed, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isGameOver)
        {
            for (int i = _snakeSpawn.Count - 1; i > 0; i--)
            {
                _snakeSpawn[i].position = _snakeSpawn[i - 1].position;
            }
        }
    }
    public class KinematicCollision : MonoBehaviour
    {
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float moveSpeed = 5f;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

            // Tính toán vị trí mới dựa vào input
            Vector2 newPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

            // Di chuyển đối tượng Kinematic bằng MovePosition
            rb.MovePosition(newPosition);
        }

        // Xử lý va chạm với Collider2D
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                // Xử lý khi va chạm với vật cản (đổi hướng, giảm tốc độ, hoặc thực hiện hành động nào đó)
            }
        }
    }

    private void grow()
    {
        Transform snakeSpawn = Instantiate(this.snakePrefab);
        snakeSpawn.position = _snakeSpawn[_snakeSpawn.Count - 1].position;

        _snakeSpawn.Add(snakeSpawn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isGameOver)
        {
            if (collision.gameObject.tag == "Food")
            {
                grow();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
