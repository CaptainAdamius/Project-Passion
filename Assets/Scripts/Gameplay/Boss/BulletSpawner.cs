// Bullet Spawner


using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }


    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;


    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    [SerializeField] private float rotateSpeed = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;
    private float count = 0f;
    [SerializeField] private float burstNumber = 0f;
    [SerializeField] private float burstDelay = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            count = burstNumber;
        }
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotateSpeed + 1f);
        if (timer >= firingRate)
        {
            Fire();
            count--;
            timer = 0;
            if (count == 0)
            {
                timer -= burstDelay;
            }
        }
    }

    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
