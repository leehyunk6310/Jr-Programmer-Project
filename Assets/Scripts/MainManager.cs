using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor;

    private void Awake() {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }



    [System.Serializable]
    class SavaData
    {
        public Color TeamColor;
    }

    public void SaveColor(){
        SavaData data = new SavaData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + 
        "/savefile.json", json);
    }

    public void LoadColor(){
        string path = Application.persistentDataPath +
        "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SavaData data = JsonUtility.FromJson<SavaData>(json);

            TeamColor = data.TeamColor;
        }
    }

    public void SaveColorClicked(){
        MainManager.Instance.SaveColor();
    }
    
}


