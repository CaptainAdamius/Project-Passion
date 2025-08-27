using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] TextMeshProUGUI CDText;
    [SerializeField] TextMeshProUGUI GuardText;
    [SerializeField] TextMeshProUGUI HitTypeText;
    float parryCooldown = 0;
    float parryTime = 0;
    public enum GuardState
    {
        Idle,
        Guarding,
        Parrying
    }
    GuardState gs = GuardState.Idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Managing cooldowns for the parry mechanic
        if (parryTime > 0)
        {
            parryTime -= Time.deltaTime;
        } else if (gs == GuardState.Parrying)
        {
            gs = GuardState.Idle;
        }
        if (parryCooldown > 0)
        {
            parryCooldown -= Time.deltaTime;
        }

        // Display for parry values & guard state
        TimeText.text = "Parry time = "+Mathf.Max(parryTime, 0).ToString("F2");
        CDText.text = "Cooldown = "+Mathf.Max(parryCooldown, 0).ToString("F2");
        GuardText.text = "Guard state = "+gs.ToString();

        // Setting guard states with the Parry button (Space bar)
        if (Input.GetKeyDown(KeyCode.Space) && parryCooldown <= 0)
        {
            ParryStart();
        }
        if (Input.GetKey(KeyCode.Space) && parryTime <= 0)
        {
            GuardStart();
        }
        else if (parryTime <= 0)
        {
            IdleStart();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyHitbox"))
        {
            switch(gs)
            {
                case GuardState.Idle: HitTypeText.text = "Hit type = Hit"; break;
                case GuardState.Guarding: HitTypeText.text = "Hit type = Guarded"; break;
                case GuardState.Parrying: HitTypeText.text = "Hit type = Parried"; parryCooldown = 0; break;
            } 
        }
    }
    public void ParryStart()
    {
        parryCooldown = 0.5f;
        parryTime = 0.2f;
        gs = GuardState.Parrying;
    }

    public void GuardStart()
    {
        gs = GuardState.Guarding;
    }

    public void IdleStart()
    {
        gs = GuardState.Idle;
    }
}
