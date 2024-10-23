using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Pong234
{
    public class Paddle : MonoBehaviour
    {
        public Player player;

        public float speed;
        public Rigidbody rb;

        private Vector3 _startPosition;

        private bool up;
        //private float movement;

        public void Reset()
        {
            rb.velocity = Vector3.zero;
            transform.position = _startPosition;
            Launch();
        }

        // Start is called before the first frame update
        private void Start()
        {
            _startPosition = transform.position;
            Launch();
        }

        // Update is called once per frame
        private void Update()
        {
            /*movement = Input.GetAxisRaw(isPlayer1 ? "Vertical" : "Vertical2");
            rb.velocity = new Vector3(0, movement * speed, 0);*/

            if (!UIInputSystem.ME.GetButton(ButtonAction.Player1Fire) &&
                !UIInputSystem.ME.GetButton(ButtonAction.Player2Fire) &&
                !UIInputSystem.ME.GetButton(ButtonAction.Player3Fire)
                && !UIInputSystem.ME.GetButton(ButtonAction.Player4Fire))
                return;
            up = !up;
            SetVelocity();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag.Equals("Ball"))
            {
                Debug.Log($"Collision of player {player} with ball");
                GameManager.Instance.LastHit = player;
            }
            else
            {
                Debug.Log($"Collision of player {player} with wall");
                up = !up;
                SetVelocity();
            }
        }

        private void SetVelocity()
        {
            var x = 0;
            var y = 0;
            switch (player)
            {
                case Player.P1:
                    x = -1;
                    y = 1;
                    break;
                case Player.P2:
                    x = 1;
                    y = -1;
                    break;
                case Player.P3:
                    x = 1;
                    y = 1;
                    break;
                case Player.P4:
                    x = -1;
                    y = -1;
                    break;
            }

            rb.velocity =
                new Vector3(speed * (up ? x : -1 * x),
                    speed * (up ? y : -1 * y), 0);
        }

        private void Launch()
        {
            Debug.Log("Launching paddle");
            up = Random.Range(0, 2) == 0 ? true : false;
            SetVelocity();
            Debug.Log("Current velocity: " + rb.velocity);
        }
    }
}