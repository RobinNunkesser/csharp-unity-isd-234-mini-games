using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private ToggleGroup _toggleGroup;
    
    public int Players { get; private set; }
    
    public static GameManager Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Manager Start");
        //_toggleGroup = GetComponent<ToggleGroup>();
        _toggleGroup = GameObject.Find("PlayerToggleGroup").GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
        }
    }

    public void PlayGame()
    {
        Debug.Log("Play Game");
        var activeToggle = _toggleGroup.ActiveToggles().FirstOrDefault();
        switch (activeToggle.name)
        {
            case "TwoPlayerToggle":
                Players = 2;
                break;
            case "ThreePlayerToggle":
                Players = 3;
                break;
            default:
                Players = 4;
                break;
        }
        Debug.Log(activeToggle.name + " _ " + activeToggle.GetComponentInChildren<Text>().text);
        SceneManager.LoadScene(1);
    }
}
