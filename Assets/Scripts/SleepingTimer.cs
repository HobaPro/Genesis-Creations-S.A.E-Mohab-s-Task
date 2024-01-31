using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepingTimer : MonoBehaviour
{
    // UI
    [SerializeField] private Text secondsTxt;

    public float seconds { get; private set; }

    public bool timeEnded { get; private set; }

    private void OnEnable()
    {
        seconds = 10.0f;

        timeEnded = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeEnded) return;

        seconds -= Time.deltaTime;


        if (seconds <= 0.0f)
        {
            timeEnded = true;

            GameManager.instance.PlayerWake_UpTime();
        }

        UI_SetSeconds();
    }

    private void UI_SetSeconds()
    {
        if (seconds < 10) secondsTxt.text = "0" + Mathf.Round(seconds).ToString();
        else secondsTxt.text = Mathf.Round(seconds).ToString();
    }
}
