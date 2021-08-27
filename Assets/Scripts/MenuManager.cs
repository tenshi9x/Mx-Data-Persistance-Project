using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string playerName;
    public string bestPlayerName;

    public int bestScore;

    public TMP_Text bestText;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadPlayerdata();
    }

    [System.Serializable]
    class PlayerData
    {
        public string name;
        public int score;
    }

    public void SavePlayerData(int _score)
    {
        PlayerData data = new PlayerData();
        data.name = playerName;
        data.score = _score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savePlayer.json", json);
    }

    public void LoadPlayerdata()
    {
        string path = Application.persistentDataPath + "/savePlayer.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            bestText.text = WriteBestScore(data.name, data.score);
            bestScore = data.score;
            bestPlayerName = data.name;
        }
        else
        {
            bestText.text = WriteBestScore(" --- ", 0);
            bestScore = 0;
            bestPlayerName = " --- ";
        }
    }

    public string WriteBestScore(string name, int score)
    {
        string bestScore = "Best Score : " + name + " = " + score.ToString();
        return bestScore;
    }
}
