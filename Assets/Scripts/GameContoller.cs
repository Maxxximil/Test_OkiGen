using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    public static GameContoller Instance;

    public GameObject[] Prefabs;
    public GameObject Conveyor;
    public GameObject Basket;
    public Transform SpawnPoint;  
    public int MaxCount = 9;
    public string[] AllNames;
    public string QuestName;

    private bool _isWin = false;
    
    public List<GameObject> Elements;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
        Elements = new List<GameObject>();
        SpawnElement();
    }

    private void SpawnElement()
    {
        if(!_isWin)
            StartCoroutine(Spawn());
    }

    public void WinGame()
    {
        _isWin = true;
        UIController.UI.WinScreen.SetActive(true);
        UIController.UI.GameScreen.SetActive(false);
        Conveyor.SetActive(false);
        var obj = FindObjectsOfType<Take>();
        foreach(var el in obj)
        {
            el.gameObject.SetActive(false);
        }
        Basket.SetActive(false);
    }

    IEnumerator Spawn()
    {
        int rand = Random.Range(0, Prefabs.Length);
        if (Elements.Count > MaxCount)
        {
            Destroy(Elements[0]);
            Elements.RemoveAt(0);
        }
        Elements.Add(Instantiate(Prefabs[rand], SpawnPoint.position, transform.rotation));
        yield return new WaitForSeconds(2f);
        SpawnElement();
    }
}
