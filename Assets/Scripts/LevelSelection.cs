using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Platformer
{
    public class LevelSelection : MonoBehaviour
    {
        [SerializeField] private int _lvlnumber;
        void Start()
        {

        }
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Hero")
            {
                if (_lvlnumber == 1)  SceneManager.LoadScene("2Level");
                if (_lvlnumber == 2) SceneManager.LoadScene("3Level");
            }
            
        }
        public void Restart()
        {
            SceneManager.LoadScene("MainMenu");
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}