using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;


public class JsonManager : MonoBehaviour
{
    string json;
    string path;
    GameObjectInScene gameObjectInScene;
    public List<GameObjectInScene> gameObjectList;
    public bool save = true;
    GameObject[] saveobjects;

    void Awake()
    {
        path = Application.persistentDataPath + "/state.json";
    }

    void Start()
    {
        gameObjectList = new List<GameObjectInScene>();
        SaveJson(); 
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Load();
            Debug.Log("Fire1");
        }
    }
    void SaveJson()
    {
        StreamWriter f = new StreamWriter(path);
        saveobjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject gObject in saveobjects)
        {

            gameObjectInScene = new GameObjectInScene(gObject.name, gObject.transform.localScale, gObject.transform.position, gObject.transform.rotation);
            gameObjectList.Add(gameObjectInScene);

        }
        for (int i = 0; i < gameObjectList.Count; i++)
        {
            json = JsonUtility.ToJson(gameObjectList[i]);
            f.WriteLine(json);
            f.Flush();
        }
        f.Close();
    }
    void Load()
    {
        StreamReader r = new StreamReader(path);
        for (int i = 0; i < gameObjectList.Count; i++)
        {
            string line = r.ReadLine();
            GameObjectInScene game = JsonUtility.FromJson<GameObjectInScene>(line);
            saveobjects[i].transform.position = game.position;
            saveobjects[i].transform.rotation = game.rotation;
            saveobjects[i].transform.localScale = game.scale;
        }
        r.Close();
    }

}
[Serializable]
public class GameObjectInScene
{
    public string name;
    public Vector3 scale;
    public Vector3 position;
    public Quaternion rotation;

    public GameObjectInScene(string name, Vector3 scale, Vector3 position, Quaternion rotation)
    {
        this.name = name;
        this.scale = scale;
        this.position = position;
        this.rotation = rotation;
    }
}