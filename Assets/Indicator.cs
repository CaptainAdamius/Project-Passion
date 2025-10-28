using UnityEngine;

public class Indicator : MonoBehaviour
{

    [SerializeField] Boss boss;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = boss.transform.position.x;
        transform.position = pos;
    }
}
