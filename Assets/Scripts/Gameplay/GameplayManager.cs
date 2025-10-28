using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public bool gameStarted;
    private float startTimer = 1f;

    [SerializeField] Boss boss;
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
    }
}
