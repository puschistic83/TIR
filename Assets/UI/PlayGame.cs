using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField]
    private int scene;

    public void Play()
    {
        SceneManager.LoadScene(scene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
