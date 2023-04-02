using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsMenuButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button exitButton;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeButton(){
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SettingsMenuButton(){

    }

    public void RetryButton(){
        SceneManager.LoadScene("SampleScene");
        Player.XP = 0;
        Time.timeScale = 1f;
    }

    public void ExitButton(){
        SceneManager.LoadScene("MainMenu");
    }
    public void OnApplicationQuit() {
        Application.Quit();
    }
}
