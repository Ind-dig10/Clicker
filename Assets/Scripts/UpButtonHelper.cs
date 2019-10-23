using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonHelper : MonoBehaviour
{
    public bool IsRuby;

    public bool IsHero;
    public Text DamageText;
    public Text PriceText;

    public GameObject HeroPrefab;
    public GameObject upPrefab;

    public Image UiVieImage;

    public int Damage = 10;
    public int Price = 100;
    

    GameHelper _gameHelper;
    void Start()
    {
        DamageText.text = "+"+ Damage.ToString();
        PriceText.text = Price.ToString();
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upClick()
    {
        if(!IsRuby && _gameHelper.PlayerGold >= Price || IsRuby && _gameHelper.PlayerRuby >= Price)
        {
            if(!IsRuby)
            {
                _gameHelper.PlayerGold -= Price;
            }
            else { _gameHelper.PlayerRuby -= Price; }
            if (IsHero == false)
            {
                _gameHelper.PlayerDamage += Damage;
            }
            else
            {
                GameObject hero = Instantiate(HeroPrefab) as GameObject;
                Vector3 heroPos = new Vector3(Random.Range(3.0f,7), -3.5f,0 );

                hero.transform.position = heroPos;
            }
            GameObject upEffect = Instantiate(upPrefab) as GameObject;
            Transform canvas = GameObject.Find("Canvas").transform;
            upEffect.transform.SetParent(canvas);
            upEffect.GetComponent<Image>().sprite= UiVieImage.sprite;
            Destroy(upEffect,1);

            if(IsHero == false)
            {
                Destroy(gameObject);
            }
           
        }
    }
}
