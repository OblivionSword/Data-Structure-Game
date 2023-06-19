using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StackSimulation : MonoBehaviour
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] Transform boxSpawnPosition;
    private GameObject box;
    private int boxCount;

    public Stack<GameObject> simStack;

    private void Start()
    {
        simStack = new Stack<GameObject>();
    }

    private void Update()
    {
        boxCount = simStack.Count;
    }

    public void PushStack()
    {
        box = Instantiate(boxPrefab, boxSpawnPosition);

        simStack.Push(box);
    }

    public void PopStack()
    {
        try
        {
            if (simStack.Count == 0)
                return;

            GameObject topBox = simStack.Peek().gameObject;

            Destroy(topBox);

            simStack.Pop();
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
        
    }

    public int GetBoxCount()
    {
        return boxCount;
    }

    public void QuitSim()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
