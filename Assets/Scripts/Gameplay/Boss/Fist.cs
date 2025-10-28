using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static Boss;

public class Fist : MonoBehaviour
{
    public float speed;
    public Vector3 startingPosition;
    public Vector3 endingPosition;
    public string side;
    public string punchState;
    public float windup;

    public AudioClip fistSound;
    private AudioSource fistAudio;

    [SerializeField] Boss boss;
    [SerializeField] Warning warning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fistAudio = GetComponent<AudioSource>();
        if (side == "left")
        {
            startingPosition = new Vector3(-96, 150, 0);
            endingPosition = new Vector3(-96, -300, 0);
}
        if (side == "right")
        {
            startingPosition = new Vector3(96, 150, 0);
            endingPosition = new Vector3(96, -300, 0);
        }

        transform.position = startingPosition;
        transform.position += new Vector3(0, 200, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.CurrentState.ToString() == "Intro")
        {
            transform.position = Vector3.Lerp(transform.position, startingPosition, speed * Time.deltaTime);
        }

        if (boss.CurrentState.ToString() == "Phase1")
        {
            if (boss.movementPattern != side)
            {
                //Beginning the punch
                if (Vector3.Distance(transform.position, startingPosition) < 0.01f && !fistPunched)
                {
                    WindupPunch();
                }
                if (windupInitiated)
                {
                    windup -= Time.deltaTime;
                }
                if (windup < 0 && windupInitiated)
                {
                    PlayFistSFX();
                    transform.position = Vector3.MoveTowards(transform.position, endingPosition, speed * Time.deltaTime);
                    speed += 50;
                }
                //Returning the fist to starting position
                if (Vector3.Distance(transform.position, endingPosition) < 0.01f)
                {
                    ReturnFist();
                }
                if (!windupInitiated)
                {
                    Debug.Log("Returning...");
                    speed = 10f;
                    transform.position = Vector3.Lerp(transform.position, startingPosition, speed * Time.deltaTime);
                }
            }
            
        }
    }

    private bool windupInitiated;
    private bool soundPlayed;
    public bool fistPunched;
    public void WindupPunch()
    {
        if (!windupInitiated && !fistPunched)
        {
            windup = 3f;
            windupInitiated = true;
            fistPunched = true;
            soundPlayed = false;
            Instantiate(warning, startingPosition - new Vector3(0, 150, 0), Quaternion.identity);
            Debug.Log("Windup initialized.");
        }
    }

    public void ReturnFist()
    {
        if (windupInitiated)
        {
            windup = 1f;
            windupInitiated = false;
            Debug.Log("Return initialized.");
        }
    }

    public void PlayFistSFX()
    {
        if (!soundPlayed)
        {
            soundPlayed = true;
            fistAudio.PlayOneShot(fistSound);
        }
    }
}
