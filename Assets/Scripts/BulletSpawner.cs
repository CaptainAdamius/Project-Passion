using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    float bulletCooldown;
    [SerializeField] GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletCooldown -= Time.deltaTime;
        if (bulletCooldown <= 0)
        {
            SpawnBullet();
            bulletCooldown = 1f;
        }
        
    }

    void SpawnBullet()
    {
        Instantiate(bullet);
    }
}
