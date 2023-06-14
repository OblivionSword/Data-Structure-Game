using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxCountText : MonoBehaviour
{
    [SerializeField] StackSimulation stackSim;
    TextMeshProUGUI boxCounterText;
    private int boxCounter;

    // Start is called before the first frame update
    void Start()
    {
        boxCounterText = FindObjectOfType<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        boxCounter = stackSim.GetBoxCount();
        boxCounterText.text = boxCounter.ToString();
    }
}
