using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public Button continueButton;
    public int levelIndex;

    private void Start()
    {
        continueButton.onClick.AddListener(OnContinueClick);
    }

    private void OnContinueClick()
    {
        PlayerPrefs.SetInt("Level_" + levelIndex, 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LevelMenu");
    }
}

