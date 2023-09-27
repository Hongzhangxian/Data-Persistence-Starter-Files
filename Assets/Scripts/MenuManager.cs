using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    public string inputName;

    public string bestScoreName;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI inputText;
    public TextMeshProUGUI menuBestScoreText;

    public TextMeshProUGUI Placeholder;
    public int bestScore = 0;
    
    
    private void Awake() {
    if(Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);

    LoadNameBestScore();

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
            Placeholder.SetText(inputName);
            Placeholder.alpha = 255;
        }

        menuBestScoreText.SetText("Best Score :"+bestScoreName+" :"+bestScore);
    }

    // Update is called once per frame
    void Update()
    {

        displayName.SetText("Welcome :"+ inputText.text);
        inputName = inputText.text;
        
    }


    public void StartGame()
    {
        SaveNameScore();
        SceneManager.LoadSceneAsync(1);
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
        inputName =null;
        bestScore = 0;
        bestScoreName = null;
        Placeholder.SetText("Enter name");
        Placeholder.alpha = 125;
        menuBestScoreText.SetText("Best Score : Nobody");


        //string filePath = Path.Combine(Application.persistentDataPath, "/savefile.json");
        string filePath = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(filePath)) // 检查文件是否存在
        {
            File.Delete(filePath); // 删除文件
        }
    }
}
