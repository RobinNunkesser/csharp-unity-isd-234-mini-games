using UnityEngine;

namespace Script.Pong
{
    public class Goal : MonoBehaviour
    {
        public bool isPlayer1Goal;

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            GameManager.Instance.PlayerScored(isPlayer1Goal
                ? "Player 2"
                : "Player 1");
        }
    }
}