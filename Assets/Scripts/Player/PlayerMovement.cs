using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public float screenLeft, screenRight, screenTop, screenBottom;
    float horizontal;
    float vertical;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector2 (horizontal, vertical);
        transform.position += moveDirection * Time.deltaTime * speed;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, screenLeft, screenRight);
        pos.y = Mathf.Clamp(pos.y, screenBottom, screenTop);
        transform.position = pos;
    }
}
