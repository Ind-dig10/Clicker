using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AdMenuHelper : MonoBehaviour
{
    public Text MyGoldText;
    public Text RecordGoldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowEndGame(int gold)
    {
        MyGoldText.text = gold.ToString();

        if (Setting.GoldRecord < gold)
        {
            Setting.GoldRecord = gold;
        }

        RecordGoldText.text = Setting.GoldRecord.ToString();
    }
        public  void ButtonRestartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}
