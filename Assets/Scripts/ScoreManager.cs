using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //We got rid of Start and Update! This is a static class. Let's freaking go.
    public static ScoreManager instance;
   
    //not sure if I can do this, but I basically need to save the entry from NameEntry into this script
    public string playerName;
    public int highScore;
    public int m_points;
    
    public InputField nameEntry;

    private void Awake()
    {
        //this is necessary to make sure I don't make a bunch of Score Manager objects
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //this ensures other things can access this class, and that the object it's attached to persists between scenes
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void NameEntered()
    {
        playerName = nameEntry.text;
    }

    public void ScoreChecker()
    {
        if(m_points > highScore)
        {
            highScore = m_points;
            m_points = 0;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

        public void SaveScore()
        {
            SaveData data = new SaveData();
            data.playerName = playerName;
            data.highScore = highScore;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        public void LoadScore()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if(File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                playerName = data.playerName;
                highScore = data.highScore;
            }
        }

    }