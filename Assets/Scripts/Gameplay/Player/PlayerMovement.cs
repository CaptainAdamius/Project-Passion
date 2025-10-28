using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public float screenLeft, screenRight, screenTop, screenBottom;
    float horizontal;
    float vertical;

    [SerializeField] GameplayManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

            Vector3 moveDirection = new Vector2 (horizontal, vertical);
            transform.position += moveDirection * Time.deltaTime * speed;

            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, screenLeft, screenRight);
            pos.y = Mathf.Clamp(pos.y, screenBottom, screenTop);
            transform.position = pos;
        }
        
    }
}
