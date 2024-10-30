using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        public ToggleGroup gameTimeToggleGroup;
        public ToggleGroup playersToggleGroup;
        public ToggleGroup gameToggleGroup;

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
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void ShowCredits()
        {
            SceneManager.LoadSceneAsync((int)Scenes.Credits,
                LoadSceneMode.Additive);
        }

        public void PlayGame()
        {
            Debug.Log("Play Game");

            var activePlayersToggle =
                playersToggleGroup.ActiveToggles().FirstOrDefault();
            Players = activePlayersToggle?.name switch
            {
                "TwoPlayerToggle" => 2,
                "ThreePlayerToggle" => 3,
                _ => 4
            };
            Debug.Log(activePlayersToggle.name + " _ " + activePlayersToggle
                .GetComponentInChildren<Text>().text);

            var activePlayTimeToggle =
                gameTimeToggleGroup.ActiveToggles().FirstOrDefault();
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

            var activeGameToggle =
                gameToggleGroup.ActiveToggles().FirstOrDefault();
            var game = activeGameToggle?.name switch
            {
                "PongToggle" => (int)Scenes.Pong234,
                _ => (int)Scenes.Pong234
            };

            SceneManager.LoadSceneAsync(game, LoadSceneMode.Additive);
        }
    }
}