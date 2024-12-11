using UnityEngine;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelStatus = PlayerPrefs.GetInt("Level_" + i, 0);

            if (levelStatus == 1)
            {
                ColorBlock colorBlock = levelButtons[i].colors;
                colorBlock.normalColor = Color.green;
                levelButtons[i].colors = colorBlock;
            }
        }
    }
}
