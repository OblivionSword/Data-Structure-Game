using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSimulation : MonoBehaviour
{
    public Queue<string> simQueue;
    string text;

    // Start is called before the first frame update
    void Start()
    {
        simQueue = new Queue<string>();
    }

    public void EnqueueSim()
    {
        simQueue.Enqueue(text);

        foreach (var text in simQueue)
            Debug.Log(text);
    }

    public void DequeueSim()
    {
        simQueue.Dequeue();
        foreach (var text in simQueue)
            Debug.Log(text);
    }

    public void ReadStringInput(string s)
    {
        text = s;
    }
}
