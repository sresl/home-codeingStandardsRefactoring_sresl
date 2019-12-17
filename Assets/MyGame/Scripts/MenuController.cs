using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour{

    private string mainScene = "MainScene";

    public void Play(){
        SceneManager.LoadScene(mainScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
