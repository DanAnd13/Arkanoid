using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NextLevel
{
    public class NextLevel : MonoBehaviour
    {
        public void LoadLevel(string name)
        {
            SceneManager.LoadScene(name);
        }
        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}
