using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSimulation : MonoBehaviour
{
    [SerializeField] GameObject personPrefab;
    [SerializeField] Transform spawnPosition;
    private GameObject person;

    public Queue<GameObject> simQueue;
    int queueCount;

    // Start is called before the first frame update
    void Start()
    {
        simQueue = new Queue<GameObject>();
    }

    private void Update()
    {
        queueCount = simQueue.Count;
    }

    public void EnqueueSim()
    {
        person = Instantiate(personPrefab, spawnPosition);

        simQueue.Enqueue(person);
    }

    public void DequeueSim()
    {
        try
        {
            GameObject frontQueue = simQueue.Peek().gameObject;

            Destroy(frontQueue);

            simQueue.Dequeue();
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }

       
    }

    public int GetQueueCount()
    {
        return queueCount;
    }

}