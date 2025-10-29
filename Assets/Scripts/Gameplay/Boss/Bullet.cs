// Bullet


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private float screenLeft = -242, screenRight = 242, screenBottom = -274, screenTop = 274;
    public float bulletLife = 1f;  // Defines how long before the bullet is destroyed
    public float rotation = 0f;
    public float speed = 1f;


    private Vector2 spawnPoint;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {

        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        bool isOutsideBounds = (pos.x < screenLeft || pos.x > screenRight || pos.y < screenBottom || pos.y > screenTop);

        if (isOutsideBounds) Destroy(this.gameObject);
        if (timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }


    private Vector2 Movement(float timer)
    {
        // Moves right according to the bullet's rotation
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
