using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    public string inputName;

    public string bestScoreName;
    public TextMeshProUGUI inputText;
    public TextMeshProUGUI menuBestScoreText;
    public int bestScore = 0;

    public TMPro.TMP_InputField tmpInputField;
    
    
    private void Awake() {
    if(Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);

    LoadNameBestScore();
    Debug.Log("LoadMenu!");

    }

    [System.Serializable] class SaveData
    {
        public string persistentSaveInputName;
        public string persistentSaveBestScoreName;
        public int persistentSaveScore;
    }



    void Start()
    {
        if(inputName != null)
        {
            tmpInputField.text = inputName;
        }
        else
        {
            tmpInputField.text = null;
        }

        menuBestScoreText.SetText("Best Score :"+bestScoreName+" :"+bestScore);

    }

    // Update is called once per frame
    void Update()
    {
        inputName = inputText.text;
        
    }


    public void StartGame()
    {
        SaveNameScore();
        Debug.Log("Save Successfully");
        SceneManager.LoadScene(1);
    } 

    public void SaveNameScore()
    {
        SaveData data = new SaveData();
        data.persistentSaveInputName = inputName;
        data.persistentSaveBestScoreName = bestScoreName;
        data.persistentSaveScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadNameBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json =File.ReadAllText(path);
            SaveData data =JsonUtility.FromJson<SaveData>(json);

            inputName = data.persistentSaveInputName;
            bestScoreName =data.persistentSaveBestScoreName;
            bestScore = data.persistentSaveScore;
        }
    }

    public void ClearHistory()
    {
        inputName = null;
        bestScore = 0;
        bestScoreName = null;
        tmpInputField.text = null;
        menuBestScoreText.SetText("Best Score : Nobody");

        //delete the svefile
        string filePath = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(filePath))
        {
            File.Delete(filePath); 
        }
        return;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}