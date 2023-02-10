using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private static string CurrentScene = "mode_spikes";
    public void PlayGame()
    {
        SceneManager.LoadScene(CurrentScene);
        PauseMenu.AbleToPause = true;
    }
    public void Quit()
    {
        Debug.Log("quited");
        Application.Quit();
    }
    public void SpikeMode()
    {
        CurrentScene = "mode_spikes";
    }
    public void CoinsMode()
    {
        CurrentScene = "mode_coins";
    }
    public void SampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Shop()
    {
        SceneManager.LoadScene("Wardrobe");
    }
}
