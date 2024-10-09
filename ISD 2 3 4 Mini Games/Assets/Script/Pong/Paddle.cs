using UnityEngine;

namespace Script.Pong
{
    public class Paddle : MonoBehaviour
    {
        public bool isPlayer1;

        public float speed;
        public Rigidbody rb;
        public Vector3 startPosition;

        private float movement;

        public void Reset()
        {
            rb.velocity = Vector3.zero;
            transform.position = startPosition;
        }

        // Start is called before the first frame update
        private void Start()
        {
            startPosition = transform.position;
        }

        // Update is called once per frame
        private void Update()
        {
            if (isPlayer1)
                movement = Input.GetAxisRaw("Vertical");
            else
                movement = Input.GetAxisRaw("Vertical2");

            rb.velocity = new Vector3(0, movement * speed, 0);
        }
    }
}