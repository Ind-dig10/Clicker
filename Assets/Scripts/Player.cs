using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform AttackStartposition;

    public GameObject[] AttackPrefabs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunAttack()
    {
        GetComponent<Animator>().SetTrigger("Attack");

        int index = Random.Range(0, AttackPrefabs.Length);

        GameObject effect = Instantiate(AttackPrefabs[index]) as GameObject;

        effect.transform.position = AttackStartposition.position;
        Destroy(effect, 0.20f);
    }
}
