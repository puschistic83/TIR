using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private int scene;
    private void Start()
    {
        StartCoroutine(ScreenActive());
    }
    IEnumerator ScreenActive()
    {
        yield return new WaitForSeconds(9);
       
        SceneManager.LoadScene(scene);
    }
}
