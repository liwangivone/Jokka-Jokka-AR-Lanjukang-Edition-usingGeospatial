using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownControllerCopy : MonoBehaviour
{
    public int countdownTime, pilihlvl;
    public TMP_Text countdownDisplay;
    public GameObject countdown;
    public GameObject logo;
    public GameObject[] UICountdown;
    public GameObject[] UILevel;
    public Button yourButton;
    public Button BtnLvlEasy, BtnLvlMedium, BtnLvlHard;

    void Start()
    {
        foreach (GameObject g in UILevel)
            g.SetActive(false);
        countdown.SetActive(false);
        logo.SetActive(true);
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(StartBtnClick);
        Button btneasy = BtnLvlEasy.GetComponent<Button>();
        Button btnmedium = BtnLvlMedium.GetComponent<Button>();
        Button btnhard = BtnLvlHard.GetComponent<Button>();
        btneasy.onClick.AddListener(LvlBtnClickEasy);
        btnmedium.onClick.AddListener(LvlBtnClickMedium);
        btnhard.onClick.AddListener(LvlBtnClickHard);
    }
    
    public void StartBtnClick()
    {
        foreach (GameObject g in UICountdown)
            g.SetActive(false);
        foreach (GameObject g in UILevel)
            g.SetActive(true);
    }

    public void LvlBtnClickEasy()
    {
        pilihlvl = 1;
        StartCountdown();
    }

    public void LvlBtnClickMedium()
    {
        pilihlvl = 2;
        StartCountdown();
    }

    public void LvlBtnClickHard()
    {
        pilihlvl = 3;
        StartCountdown();
    }
    public void StartCountdown()
    {
        StaticData.lvl = pilihlvl;
        countdown.SetActive(true);
        logo.SetActive(false);

        foreach (GameObject g in UILevel)
            g.SetActive(false);

        StartCoroutine(CountdownToStart());
    }

    public IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GO!";

        //GameController.instance.BeginGame();

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);

        SceneManager.LoadSceneAsync("SampleScene");
    }
}
