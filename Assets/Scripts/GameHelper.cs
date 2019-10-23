using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    const int Freeq = 3;
    public int GameTime = 10;
    public Text GameTimetext;
    public AdMenuHelper EndmynuHelper;
    public Text DamageText;
    public Transform StartPosition;
    public Slider HealthSlider;
    public GameObject GoldPrefab;
    public GameObject RubyPrefab;
    public GameObject[] MonstersPrefabs;
    public Text PlayerGoldUi;
    public Text RubyText;
    public int PlayerGold;
    public int PlayerRuby;
    public int PlayerDamage = 10;

    int count = 0;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        SpawnMonster();
        InvokeRepeating("Timer",0,1);
    }
    void Timer()
    {
        currentTime++;

        GameTimetext.text = (GameTime - currentTime).ToString();
        if(currentTime >= GameTime )
        {
            Time.timeScale = 0;

            EndmynuHelper.gameObject.SetActive(true);
            EndmynuHelper.ShowEndGame(PlayerGold);
        }

    }
    // Update is called once per frame
    void Update()
    {
        PlayerGoldUi.text = PlayerGold.ToString();
        DamageText.text = PlayerDamage.ToString();
        RubyText.text = PlayerRuby.ToString();
    }
    public void TakeRuby(int ruby)
    {
        PlayerRuby += ruby;
        GameObject rubyObj = Instantiate(RubyPrefab) as GameObject;
        Destroy(rubyObj, 3);
    }
public void TakeGold(int gold)
    {
       
        PlayerGold += gold;
        GameObject goldObj = Instantiate(GoldPrefab) as GameObject;
        Destroy(goldObj, 2);

        SpawnMonster();
    }

    public void SpawnMonster()
    {
        count++;
        int randomMaxValue = count / Freeq + 1;
        if(randomMaxValue >= MonstersPrefabs.Length)
        {
            randomMaxValue = MonstersPrefabs.Length;
        }
        int index = Random.Range(0, randomMaxValue);
        GameObject monsterObj = Instantiate(MonstersPrefabs[index]) as GameObject;
        monsterObj.transform.position = StartPosition.position;
        index+=1;
       
    }
}
