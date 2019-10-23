using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHelper : MonoBehaviour
{
    public int Damage { get; set; }
    HealthEnemy _healthenemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( _healthenemy == null)
        {
            _healthenemy = GameObject.FindObjectOfType<HealthEnemy>();
        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _healthenemy.transform.position, Time.deltaTime * 15);

            if(Vector2.Distance(transform.position, _healthenemy.transform.position) <0.1f)
            {
                _healthenemy.GetHit(Damage);
                Destroy(gameObject);
            }
        }
    }
}
