using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    public float speed;
    private Vector3 neutralPosition;

    public enum BossState
    {
        Intro,
        Phase1,
        Transition1,
        Phase2,
        Transition2,
        Phase3
    }
    BossState bs = BossState.Intro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        neutralPosition = new Vector3(0, 120, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Game start
        if (bs == BossState.Intro)
        {
            transform.position = Vector3.Lerp(transform.position, neutralPosition, speed * Time.deltaTime);
        }
    }
}
