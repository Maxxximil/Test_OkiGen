using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController UI;

    public GameObject GameScreen;
    public TMP_Text QuestText;
    public TMP_Text CollectedText;
    public GameObject AddOneText;
    public GameObject WinScreen;

    public int questNumb;
    string questName;

    private void Start()
    {
        UI = this;
        questNumb = Random.Range(1, 6);
        int rand = Random.Range(0, GameContoller.Instance.AllNames.Length);
        questName = GameContoller.Instance.AllNames[rand];

        QuestText.text = "Collect " + questNumb + " " + questName;
        CollectedText.text = "0 / " + questNumb;
        GameContoller.Instance.QuestName = questName;
    }

    public void UpdateUI(int count)
    {
        CollectedText.text = count + " / " + questNumb;
        StartCoroutine(PlusOne());
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator PlusOne()
    {
        AddOneText.SetActive(false);
        AddOneText.SetActive(true);
        yield return new WaitForSeconds(1f);
        AddOneText.SetActive(false);

    }
}
