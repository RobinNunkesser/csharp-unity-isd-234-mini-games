using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public float timeRemaining = 60;

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
    }
}