using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public float timeRemaining = 60;

    public static Timer Instance { get; private set; }
    [CanBeNull] public Action TimerEndAction { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        var minutes = Mathf.FloorToInt(timeRemaining / 60);
        var seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = $"{minutes:00}:{seconds:00}";
        if (timeRemaining > 0) return;
        TimerEndAction?.Invoke();
    }
}