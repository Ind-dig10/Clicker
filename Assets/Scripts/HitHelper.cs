using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHelper : MonoBehaviour
{
    GameHelper _gameHelper;
    Player _playerHelper;
    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
        _playerHelper = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void  OnMouseDown()
    {
        Debug.Log("OnMouseDown()");
   //     if(_gameHelper.Endgame)
  //      {
   //         return;
  //      }
        GetComponent<HealthEnemy>().GetHit(_gameHelper.PlayerDamage);
        _playerHelper.RunAttack();

    }
}
