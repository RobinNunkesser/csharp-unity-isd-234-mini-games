using UnityEngine;

namespace Script.Pong234
{
    public class Paddle : MonoBehaviour
    {
        public bool isPlayer1;

        public float speed;
        public Rigidbody rb;

        private Vector3 _startPosition;
        private float movement;

        public void Reset()
        {
            rb.velocity = Vector3.zero;
            transform.position = _startPosition;
        }

        // Start is called before the first frame update
        private void Start()
        {
            _startPosition = transform.position;
        }

        // Update is called once per frame
        private void Update()
        {
            movement = Input.GetAxisRaw(isPlayer1 ? "Vertical" : "Vertical2");
            rb.velocity = new Vector3(0, movement * speed, 0);
        }
    }
}