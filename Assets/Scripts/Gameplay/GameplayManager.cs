using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public bool gameStarted;
    private float startTimer = 1f;
    private float p1Time = 0f, p2Time = 0f, p3Time = 0f;

    [SerializeField] Boss boss;
    [SerializeField] TextMeshProUGUI p1Text;
    [SerializeField] TextMeshProUGUI p2Text;
    [SerializeField] TextMeshProUGUI p3Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Vector3.Distance(boss.transform.position, boss.movementPositions[0]) < 0.01f)
        {
            startTimer -= Time.deltaTime;
            if (startTimer < 0)
            {
                gameStarted = true;
                Debug.Log("Game has started!");
            }
        }

        switch (boss.CurrentState)
        {
            case Boss.BossState.Phase1: p1Time += Time.deltaTime; break;
            case Boss.BossState.Phase2: p2Time += Time.deltaTime; break;
            case Boss.BossState.Phase3: p3Time += Time.deltaTime; break;
        }

        p1Text.text = "Phase 1: " + p1Time.ToString("F2") + "s";
        p2Text.text = "Phase 2: " + p2Time.ToString("F2") + "s";
        p3Text.text = "Phase 3: " + p3Time.ToString("F2") + "s";
    }
}
