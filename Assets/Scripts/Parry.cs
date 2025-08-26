using TMPro;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] TextMeshProUGUI CDText;
    [SerializeField] TextMeshProUGUI GuardText;
    float parryCooldown = 0;
    float parryTime = 0;
    int guardState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parryTime = 2;
        parryCooldown = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (parryTime > 0)
        {
            parryTime -= Time.deltaTime;
        } else if (guardState == 2)
        {
            guardState = 0;
        }
        if (parryCooldown > 0)
        {
            parryCooldown -= Time.deltaTime;
        }


        TimeText.text = "Parry time = "+Mathf.Max(parryTime, 0).ToString("F2");
        CDText.text = "Cooldown = "+Mathf.Max(parryCooldown, 0).ToString("F2");
        GuardText.text = "Guard state = "+guardState.ToString();

        if (Input.GetKeyDown(KeyCode.Space) && parryCooldown <= 0)
        {
            ParryStart();
        }

        if (Input.GetKey(KeyCode.Space) && parryTime <= 0)
        {
            guardState = 1;
        }
        else if (parryTime <= 0)
        {
            guardState = 0;
        }

    }

    public void ParryStart()
    {
            parryCooldown = 0.5f;
            parryTime = 0.2f;
            guardState = 2;
    }
}
