using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float screenLeft = -242, screenRight = 242, screenBottom = -274, screenTop = 274;
    public float speed = 10;
    [SerializeField] Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        bool isOutsideBounds = (pos.x < screenLeft || pos.x > screenRight || pos.y < screenBottom || pos.y > screenTop);
        if (isOutsideBounds) Destroy(this.gameObject);
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            Destroy(this.gameObject);
        }
    }
}
