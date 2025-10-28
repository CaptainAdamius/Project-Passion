using UnityEngine;

public class Warning : MonoBehaviour
{

    private float life = 3f;
    public AudioClip warningSound;
    private AudioSource warningAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        warningAudio = GetComponent<AudioSource>();
        warningAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;
        
        if (life < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
