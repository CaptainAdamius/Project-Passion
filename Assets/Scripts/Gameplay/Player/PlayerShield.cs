using UnityEngine;

public class PlayerShield : MonoBehaviour
{

    [SerializeField] Player play;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (play == null)
            play = FindAnyObjectByType<Player>();
        transform.SetParent(play.transform);
        Destroy(gameObject, 3f);
    }

}
