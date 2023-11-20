using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private int score = 0, highscore = 0;
    public TMP_Text scoreText, WinLoseTxt;
    public GameObject WinLose;
    public GameObject guritakalah;
    public CountdownControllerCopy countdownscript;

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.name == "enemy1(Clone)" || hit.transform.name == "enemy2(Clone)")
            {
                Destroy(hit.transform.gameObject);
                score++;
            }
        }
    }

    public void WinLoseText()
    {
        Debug.Log("Masuk");
        WinLose.SetActive(true);
        if (StaticData.lvl == 1){
            highscore = 10;
        }
        else if (StaticData.lvl == 2){
            highscore = 15;
        }
        else {
            highscore = 20;
        }
        if (score >= highscore) {
            guritakalah.SetActive(false);
            Debug.Log("Menang" + score + highscore);
            WinLoseTxt.text = "YOU WIN !!";
        }
        else if (score < highscore){
            guritakalah.SetActive(true);
            Debug.Log("Kalah" + score + highscore);
            WinLoseTxt.text = "YOU LOSE :(";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}