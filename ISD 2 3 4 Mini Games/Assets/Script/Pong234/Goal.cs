using UnityEngine;

namespace Script.Pong234
{
    public class Goal : MonoBehaviour
    {
        public Player player;

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
            GameManager.Instance.Goal(player);
        }
    }
}