using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Platformer
{
    public class MenuControl : MonoBehaviour
    {
        
        void Start()
        {
           
        }
        
        public void StartFistLvl()
        {
            SceneManager.LoadScene("FirstLevel");
        }
        public void ExitGame()
        {
            Application.Quit();
        }
        void Update()
        {

        }
    }
}
