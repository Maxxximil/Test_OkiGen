using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject[] prefabs;
    public int MaxCountPool = 9;
    public int MaxCountElement = 3;


    private int currentPoolElementID = 0;
    private GameObject[,] PoolAR;

    private void Start()
    {

        PoolAR = new GameObject[prefabs.Length,MaxCountElement];
        for(int i = 0; i < prefabs.Length; i++)
        {
            for(int j = 0; j < MaxCountElement; j++)
            {
                PoolAR[i,j] = Instantiate(prefabs[i], transform.position, transform.rotation, SpawnPoint);
                PoolAR[i, j].SetActive(false);
            }
        }
    }
}
