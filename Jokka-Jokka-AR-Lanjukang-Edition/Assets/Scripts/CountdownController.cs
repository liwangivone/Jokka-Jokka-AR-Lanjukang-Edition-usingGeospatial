using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public TMP_Text countdownDisplay;
    public GameObject[] UICountdown;

    void Start()
    {

    }
     
    public void BtnClick()
    {
        Debug.Log("Pencet");
        GameObject.Find("CountdownText").SetActive(true);

        foreach (GameObject g in UICountdown)
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
    }
}
