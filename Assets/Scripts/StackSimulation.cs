using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSimulation : MonoBehaviour
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] Transform boxSpawnPosition;
    private GameObject box;

    public Stack<GameObject> simStack;

    private void Start()
    {
        simStack = new Stack<GameObject>();
    }

    public void PushStack()
    {
        box = Instantiate(boxPrefab, boxSpawnPosition);

        simStack.Push(box);

        Debug.Log("number of boxes in the stack = " + simStack.Count);
    }

    public void PopStack()
    {
        GameObject topBox = simStack.Peek().gameObject;

        Destroy(topBox);

        simStack.Pop();

        Debug.Log("number of boxes in the stack = " + simStack.Count);

    }

}
