using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float speed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (SpawnPointController.instance.isGameOver) return;
        Rigidbody2D.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeleteZone"))
        {
            Destroy(gameObject);
        }
    }
}
