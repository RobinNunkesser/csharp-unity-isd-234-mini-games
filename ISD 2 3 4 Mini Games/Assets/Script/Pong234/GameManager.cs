using UnityEngine;
using UnityEngine.UI;

namespace Script.Pong234
{
    public class GameManager : MonoBehaviour
    {
        [Header("Ball")] public GameObject ball;

        [Header("Player 1")] public GameObject player1Paddle;

        public GameObject player1Goal;

        [Header("Player 2")] public GameObject player2Paddle;

        public GameObject player2Goal;

        [Header("Score UI")] public GameObject player1Text;

        public GameObject player2Text;

        private int _player1Score;
        private int _player2Score;

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
            player1Paddle.GetComponent<Paddle>().Reset();
            player2Paddle.GetComponent<Paddle>().Reset();
            ball.GetComponent<Ball>().Reset();
        }

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void PlayerScored(string player)
        {
            if (player == "Player 1")
            {
                _player1Score++;
                Debug.Log("Player 1 Scored");
                player1Text.GetComponent<Text>().text =
                    _player1Score.ToString();
            }
            else
            {
                _player2Score++;
                Debug.Log("Player 2 Scored");
                player2Text.GetComponent<Text>().text =
                    _player2Score.ToString();
            }

            Reset();
        }
    }
}