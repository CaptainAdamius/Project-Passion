using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float speed = 3;
    [SerializeField] public List<Vector3> movementPositions;
    private int hp;
    public int phaseHp;
    [SerializeField] TextMeshProUGUI hpText;
    public string movementPattern;

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

    public BossState CurrentState;

    [SerializeField] GameplayManager gm;
    [SerializeField] Fist leftFist;
    [SerializeField] Fist rightFist;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = phaseHp;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState = bs;

        // Game intro
        if (bs == BossState.Intro)
        {
            transform.position = Vector3.Lerp(transform.position, movementPositions[0], speed * Time.deltaTime);
            if (gm.gameStarted)
            {
                bs = BossState.Phase1;
                Debug.Log("Phase 1 initiated.");
                movementPattern = "left";
            }
        }

        // Movement
        if (bs == BossState.Phase1 || bs == BossState.Phase2 || bs == BossState.Phase3)
        {
            speed = 1.25f;
            switch (movementPattern)
            {
                case "left":
                    transform.position = Vector3.Lerp(transform.position, movementPositions[1], speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, movementPositions[1]) < 0.01f) {
                        movementPattern = "right";
                        ResetFist(rightFist);
                        break;
                    }
                    break;

                case "right":
                    transform.position = Vector3.Lerp(transform.position, movementPositions[2], speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, movementPositions[2]) < 0.01f) {
                        movementPattern = "left";
                        ResetFist(leftFist);
                        break;
                    }
                    break;

                default: break;
            }
        }

        hpText.text = "Boss HP: " + hp.ToString();

        if (hp <= 0)
        {
            hp = phaseHp;
            switch (bs)
            {
                case BossState.Phase1: bs = BossState.Transition1; break;
                case BossState.Phase2: bs = BossState.Transition2; break;
                case BossState.Phase3: SceneManager.LoadScene("Start Menu"); break;
            }
        }

        if (bs == BossState.Transition1 ||  bs == BossState.Transition2)
        {
            speed = 3;
            transform.position = Vector3.Lerp(transform.position, movementPositions[0], speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, movementPositions[0]) < 0.01f)
            {
                switch (bs)
                {
                    case BossState.Transition1: bs = BossState.Phase2; ResetFist(rightFist); ResetFist(leftFist); break;
                    case BossState.Transition2: bs = BossState.Phase3; ResetFist(rightFist); ResetFist(leftFist); break;
                }
            }
        }
    }

    public void ResetFist(Fist fist)
    {
        if (fist.fistPunched)
        {
            fist.windupInitiated = false;
            fist.fistPunched = false;
            Debug.Log("Reset fist.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerHitbox"))
        {
            switch (bs)
            {
                case BossState.Phase1: case BossState.Phase2: case BossState.Phase3:
                    hp--; Debug.Log(hp); break;
                default: break;
            }
        }
        
    }

}

