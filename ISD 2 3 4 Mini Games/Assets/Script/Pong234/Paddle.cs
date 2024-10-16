using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Pong234
{
    public class Paddle : MonoBehaviour
    {
        public bool isPlayer1;

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

            if ((UIInputSystem.ME.GetButton(ButtonAction.Player1Fire) &&
                 isPlayer1) ||
                (UIInputSystem.ME.GetButton(ButtonAction.Player2Fire) &&
                 !isPlayer1))
            {
                Debug.Log(isPlayer1 ? "Moving Player1" : "Moving Player2");
                up = !up;
                rb.velocity = new Vector3(speed * (!up ? 1 : -1),
                    speed * (up ? 1 : -1), 0);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Collision");
            rb.velocity = new Vector3(0, 0, 0);
        }

        private void Launch()
        {
            Debug.Log("Launching paddle");
            up = Random.Range(0, 2) == 0 ? true : false;
            rb.velocity =
                new Vector3(speed * (!up ? 1 : -1), speed * (up ? 1 : -1), 0);
            Debug.Log("Current velocity: " + rb.velocity);
        }
    }
}