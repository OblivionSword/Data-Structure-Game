using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSimulation : MonoBehaviour
{

    public Stack simStack = new Stack();
    string input;

    void Start()
    {
        //Stack simStack = new Stack();
        
    }

    private void Update()
    {

    }

    public void ReadInputString(string s)
    {
        input = s;

        //Debug.Log(input);
    }

    public void PushStack()
    {
        simStack.Push(input);

        foreach (var item in simStack)
            Debug.Log(item);
    }

    public void PopStack()
    {
        simStack.Pop();

        foreach (var item in simStack)
            Debug.Log(item);
    }

}
