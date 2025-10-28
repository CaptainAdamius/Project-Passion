using UnityEngine;

public class BulletSFX : MonoBehaviour
{
    public AudioClip bulletSound;
    private AudioSource bulletAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayBulletSFX()
    {
        bulletAudio.PlayOneShot(bulletSound);
    }
}
