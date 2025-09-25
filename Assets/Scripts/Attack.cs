using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAttack()
    {
        Instantiate(attack);
    }
}
