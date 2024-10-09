using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        private ToggleGroup _gameTimeToggleGroup;
        private ToggleGroup _playersToggleGroup;

        public int Players { get; private set; } = 2;
        public int PlayTime { get; private set; } = 30;

        public static GameManager Instance { get; private set; }

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
            Debug.Log("Game Manager Start");
            //_toggleGroup = GetComponent<ToggleGroup>();
            _playersToggleGroup = GameObject.Find("PlayersToggleGroup")
                .GetComponent<ToggleGroup>();
            _gameTimeToggleGroup = GameObject.Find("PlayTimeToggleGroup")
                .GetComponent<ToggleGroup>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void PlayGame()
        {
            Debug.Log("Play Game");

            var activePlayersToggle =
                _playersToggleGroup.ActiveToggles().FirstOrDefault();
            Players = activePlayersToggle?.name switch
            {
                "TwoPlayerToggle" => 2,
                "ThreePlayerToggle" => 3,
                _ => 4
            };
            Debug.Log(activePlayersToggle.name + " _ " + activePlayersToggle
                .GetComponentInChildren<Text>().text);

            var activePlayTimeToggle =
                _gameTimeToggleGroup.ActiveToggles().FirstOrDefault();
            PlayTime = activePlayTimeToggle?.name switch
            {
                "30PlayTimeToggle" => 30,
                "60PlayTimeToggle" => 60,
                "90PlayTimeToggle" => 90,
                "120PlayTimeToggle" => 120,
                _ => int.MaxValue
            };

            Debug.Log(activePlayTimeToggle.name + " _ " + activePlayTimeToggle
                .GetComponentInChildren<Text>().text);

            SceneManager.LoadScene(1);
        }
    }
}