using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetLevels();
    }

    public void ResetLevels()
    {
        int totalLevels = 5;
        for (int i = 0; i < totalLevels; i++)
        {
            PlayerPrefs.SetInt("Level_" + i, 0);
        }
        PlayerPrefs.Save();
    }
}
