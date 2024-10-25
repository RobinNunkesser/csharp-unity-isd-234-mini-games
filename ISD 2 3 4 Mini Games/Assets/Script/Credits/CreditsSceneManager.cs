using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Credits
{
    public class CreditsSceneManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void BackToMenu()
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}