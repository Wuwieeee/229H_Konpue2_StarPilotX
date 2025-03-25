using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }//PlayGame

    public void QuitGame()
    {
        Application.Quit();
    }

}//Class
