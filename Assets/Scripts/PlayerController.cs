using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        BoundMovement();


        Shoot();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float moveX = x * speed;
        float moveY = y * speed;

        rb.velocity = new Vector2(moveX, moveY);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    void BoundMovement()
    {
        float dist = (this.transform.position - Camera.main.transform.position).z;

        float leftBoarder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBoarder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float topBoarder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBoarder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        Vector3 playerSize = GetComponent<Renderer>().bounds.size;

        this.transform.position = new Vector3(
        Mathf.Clamp(this.transform.position.x, leftBoarder + playerSize.x / 2, rightBoarder - playerSize.x / 2),
        Mathf.Clamp(this.transform.position.y, topBoarder + playerSize.y / 2, bottomBoarder - playerSize.y / 2),
        this.transform.position.z
        );
    }
}
