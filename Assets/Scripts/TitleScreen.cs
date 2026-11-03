using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private string SceneName = "The_Rift";  

    public void NewGame()
    {
        SceneManager.LoadScene(SceneName);
    }
}