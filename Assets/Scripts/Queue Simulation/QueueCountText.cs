using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QueueCountText : MonoBehaviour
{
    [SerializeField] QueueSimulation queueSim;
    TextMeshProUGUI queueCounterText;
    int queueCounter;

    // Start is called before the first frame update
    void Start()
    {
        queueCounterText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        queueCounter = queueSim.GetQueueCount();
        queueCounterText.text = queueCounter.ToString();
    }
}
