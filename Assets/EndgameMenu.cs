using TMPro;
using UnityEngine;

public class EndgameMenu : MonoBehaviour
{
    [SerializeField] EndgameData egd;
    [SerializeField] TextMeshProUGUI p1Text;
    [SerializeField] TextMeshProUGUI p2Text;
    [SerializeField] TextMeshProUGUI p3Text;
    [SerializeField] TextMeshProUGUI finalText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1Text.text = "Phase 1: " + egd.getP1Time().ToString("F2") + "s";
        p2Text.text = "Phase 2: " + egd.getP2Time().ToString("F2") + "s";
        p3Text.text = "Phase 3: " + egd.getP3Time().ToString("F2") + "s";
        finalText.text = "Final time: " + egd.getFinalTime().ToString("F2") + "s";

    }
}
