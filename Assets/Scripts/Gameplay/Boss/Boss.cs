using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class Boss : MonoBehaviour
{
    public float speed;
    [SerializeField] public List<Vector3> movementPositions;
    public int hp;
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
        hp = 500;
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
                bs = BossState.Phase2;
                Debug.Log("Phase 1 initiated.");
                movementPattern = "left";
            }
        }

        if (bs == BossState.Phase2)
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
    }

    public void ResetFist(Fist fist)
    {
        if (fist.fistPunched)
        {
            fist.fistPunched = false;
            Debug.Log("Reset fist.");
        }
    }

}

