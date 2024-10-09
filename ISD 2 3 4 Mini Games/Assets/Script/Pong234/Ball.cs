using UnityEngine;

namespace Script.Pong234
{
    public class Ball : MonoBehaviour
    {
        public Rigidbody rb;

        // Start is called before the first frame update
        private void Start()
        {
            Launch();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void Launch()
        {
            var x = Random.Range(0, 2) == 0 ? -1 : 1;
            var y = Random.Range(0, 2) == 0 ? -1 : 1;
            GetComponent<Rigidbody>().velocity = new Vector3(10 * x, 10 * y, 0);
        }
    }
}