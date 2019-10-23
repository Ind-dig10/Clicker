using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public int RubyChanse;

    public int MaxHealth = 100;
    public int Health = 100;
    public int Gold = 90;

    bool _isDead;
    GameHelper _gameHelper;
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();

        _gameHelper.HealthSlider.maxValue = MaxHealth;
        _gameHelper.HealthSlider.value = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit(int Damage)
    {
        if(_isDead)
        {
            return;
        }

        int health = Health - Damage;
        if(health <= 0)
        {
            _isDead = true;
            _gameHelper.TakeGold(Gold);
            int random = Random.Range(0, 100);
            if(random < RubyChanse)
            {
                _gameHelper.TakeRuby(1);
            }
            Destroy(gameObject);
        }
        GetComponent<Animator>().SetTrigger("Hit");
        Health = health;
        _gameHelper.HealthSlider.value = Health;
       // Debug.Log("Health = " + Health);
    }
}
