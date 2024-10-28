using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Pong234
{
    public class GameManager : MonoBehaviour
    {
        [Header("Ball")] public GameObject ball;

        [Header("Player 1")] public GameObject player1Paddle;

        [Header("Player 2")] public GameObject player2Paddle;

        [Header("Player 3")] public GameObject player3Paddle;

        [Header("Player 4")] public GameObject player4Paddle;

        [Header("Score UI")] public GameObject player1Text;

        public GameObject player2Text;
        public GameObject player3Text;
        public GameObject player4Text;

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
            player3Text.GetComponent<Text>().text =
                _player3Score.ToString();
            player4Text.GetComponent<Text>().text =
                _player4Score.ToString();
            player1Paddle.GetComponent<Paddle>().Reset();
            player2Paddle.GetComponent<Paddle>().Reset();
            player3Paddle.GetComponent<Paddle>().Reset();
            player4Paddle.GetComponent<Paddle>().Reset();
            ball.GetComponent<Ball>().Reset();
            LastHit = Player.None;
        }

        // Start is called before the first frame update
        private void Start()
        {
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