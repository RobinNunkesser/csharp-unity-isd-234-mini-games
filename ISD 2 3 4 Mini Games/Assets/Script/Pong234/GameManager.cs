using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Pong234
{
    public class GameManager : MonoBehaviour
    {
        [Header("Ball")] public GameObject ball;

        [Header("Player 1")] public GameObject player1Paddle;
        public GameObject player1Button;
        public GameObject player1Text;

        [Header("Player 2")] public GameObject player2Paddle;
        public GameObject player2Button;
        public GameObject player2Text;

        [Header("Player 3")] [CanBeNull] public GameObject player3Paddle;

        [CanBeNull] public GameObject player3Button;
        [CanBeNull] public GameObject player3Text;
        [CanBeNull] public GameObject player3Wall;

        [Header("Player 4")] [CanBeNull] public GameObject player4Paddle;

        [CanBeNull] public GameObject player4Button;
        [CanBeNull] public GameObject player4Text;
        [CanBeNull] public GameObject player4Wall;


        private int _player1Score;
        private int _player2Score;
        private int _player3Score;
        private int _player4Score;

        public Player LastHit { get; set; } = Player.None;

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

        private void Reset()
        {
            player1Text.GetComponent<Text>().text =
                _player1Score.ToString();
            player2Text.GetComponent<Text>().text =
                _player2Score.ToString();
            if (player3Text != null)
                player3Text.GetComponent<Text>().text =
                    _player3Score.ToString();
            if (player4Text != null)
                player4Text.GetComponent<Text>().text =
                    _player4Score.ToString();
            player1Paddle.GetComponent<Paddle>().Reset();
            player2Paddle.GetComponent<Paddle>().Reset();
            if (player3Paddle != null)
                player3Paddle.GetComponent<Paddle>().Reset();
            if (player4Paddle != null)
                player4Paddle.GetComponent<Paddle>().Reset();
            ball.GetComponent<Ball>().Reset();
            LastHit = Player.None;
        }

        // Start is called before the first frame update
        private void Start()
        {
            Debug.Log("Pong Game Manager Start");

            Timer.Instance.TimerEndAction =
                () => SceneManager.UnloadSceneAsync((int)Scenes.Pong234);

            var players = Script.GameManager.Instance?.Players;
            var playTime = Script.GameManager.Instance?.PlayTime;
            Debug.Log("Configuring for " + players + " players");
            switch (players)
            {
                case 2:
                    Destroy(player3Paddle);
                    Destroy(player3Button);
                    Destroy(player4Paddle);
                    Destroy(player4Button);
                    break;
                case 3:
                    Destroy(player3Wall);
                    Destroy(player4Paddle);
                    Destroy(player4Button);
                    break;
                case 4:
                    Destroy(player3Wall);
                    Destroy(player4Wall);
                    break;
            }

            Debug.Log("Configuring for a play time of " + playTime +
                      " seconds");
            Timer.Instance.timeRemaining = (float)playTime;
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void Goal(Player player)
        {
            switch (player)
            {
                case Player.P1:
                    _player1Score--;
                    break;
                case Player.P2:
                    _player2Score--;
                    break;
                case Player.P3:
                    _player3Score--;
                    break;
                case Player.P4:
                    _player4Score--;
                    break;
                case Player.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(player),
                        player, null);
            }

            if (player == LastHit)
            {
                Reset();
                return;
            }

            switch (LastHit)
            {
                case Player.P1:
                    _player1Score++;
                    break;
                case Player.P2:
                    _player2Score++;
                    break;
                case Player.P3:
                    _player3Score++;
                    break;
                case Player.P4:
                    _player4Score++;
                    break;
                case Player.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Reset();
        }
    }
}