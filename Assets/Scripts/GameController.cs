using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Rock - Paper - Scissors
// 1 = Rock, 2 = Paper, 3 = Scissors, 4 = Unknown ("?")
public class GameController : MonoBehaviour
{
    Image imgYou;
    Image imgCom;

    TMP_Text txtYou;
    TMP_Text txtCom;
    TMP_Text txtResult;

    int cntYou = 0;
    int cntCom = 0;

    private void InitGame()
    {
        imgYou = GameObject.Find("ImgYou").GetComponent<Image>();
        imgCom = GameObject.Find("ImgCom").GetComponent<Image>();

        txtYou = GameObject.Find("ImgScore_You").transform.Find("Text").GetComponent<TMP_Text>();
        txtCom = GameObject.Find("ImgScore_Com").transform.Find("Text").GetComponent<TMP_Text>();
        txtResult = GameObject.Find("TxtResult").GetComponent<TMP_Text>();

        txtResult.text = "Select the button below";
    }

    void Start()
    {
        InitGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnButtonClick(GameObject buttonObject)
    {
        int you = int.Parse(buttonObject.name.Substring(0, 1));
        CheckResult(you);
    }

    void CheckResult(int yourResult)
    {
        int comResult = UnityEngine.Random.Range(1, 4);
        int k = yourResult - comResult;

        if (k == 0)
        {
            txtResult.text = "Draw";
        }
        else if (k == 1 || k == -2)
        {
            txtResult.text = "You win!";
            cntYou++;
        }
        else
        {
            txtResult.text = "Computer win!";
            cntCom++;
        }

        SetResult(yourResult, comResult);
    }

    void SetResult(int you, int com)
    {
        imgYou.sprite = Resources.Load("img_" + you, typeof(Sprite)) as Sprite;
        imgCom.sprite = Resources.Load("img_" + com, typeof(Sprite)) as Sprite;

        imgCom.transform.localScale = new Vector3(-1, 1, 1);

        txtYou.text = cntYou.ToString();
        txtCom.text = cntCom.ToString();
    }
}