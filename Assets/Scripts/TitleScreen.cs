using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private string SceneName = "The_Rift";  // The scene it loads up, okay!?!?!

    public void NewGame()
    {
        SceneManager.LoadScene(SceneName);
    }
}