using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public Transform spawnPosition;

    public GameObject boxPrefab;

    public void InstanstiateBox()
    {
        Instantiate(boxPrefab, spawnPosition);
    }

}
