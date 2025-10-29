using UnityEngine;

public class Indicator : MonoBehaviour
{

    [SerializeField] Boss boss;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = boss.transform.position.x;
        transform.position = pos;
    }
}
