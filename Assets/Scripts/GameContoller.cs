using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    public GameObject[] Prefabs;
    public Transform SpawnPoint;  
    public int MaxCount = 9;


    private GameObject[] pool;
    private List<GameObject> Elements;
    private void Start()
    {
        Elements = new List<GameObject>();
        //pool = new GameObject[MaxCount];
        SpawnElement();
    }

    private void SpawnElement()
    {
        StartCoroutine(Spawn());
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
