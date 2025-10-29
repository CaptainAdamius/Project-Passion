using UnityEngine;
using static Parry;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private SpriteRenderer render;
    public float screenLeft, screenRight, screenTop, screenBottom;
    float invincibility = 0;
    float horizontal;
    float vertical;
    float fireCooldown = 0;

    public AudioClip playerSound;
    private AudioSource playerAudio;

    Animator anim;

    [SerializeField] GameplayManager gm;
    [SerializeField] PlayerBullet bullet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //All actions within this box activate only when the game starts
        if (gm.gameStarted)
        {
            // Enable movement
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (horizontal > 0)
            {
                render.flipX = false;
            }
            if (horizontal < 0)
            {
                render.flipX = true;
            }
            anim.SetFloat("horizontal", horizontal);

            Vector3 moveDirection = new Vector2 (horizontal, vertical);
            transform.position += moveDirection * Time.deltaTime * speed;

            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, screenLeft, screenRight);
            pos.y = Mathf.Clamp(pos.y, screenBottom, screenTop);
            transform.position = pos;

            if (invincibility > 0)
            {
                invincibility -= Time.deltaTime;
            }
            if (fireCooldown > 0)
            {
                fireCooldown -= Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Space) && fireCooldown <= 0)
            {
                FireBullet();
                fireCooldown = 0.1f;
            }

            
            
        }
        
    }

    public void FireBullet()
    {
        Instantiate(bullet, transform.position + new Vector3(10, 50, 0), Quaternion.identity);
        Instantiate(bullet, transform.position + new Vector3(-10, 50, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyHitbox") && invincibility <= 0)
        {
            invincibility = 3;
            playerAudio.PlayOneShot(playerSound);
        }
    }
}
