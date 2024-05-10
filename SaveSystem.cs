using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SaveGameData (int tree, int ground, int flying, bool final, int saveFile, SaveTracker saveTracker, string lastLevel){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data" + saveFile.ToString() + ".soph";
        saveTracker.ChangeSaveFile(path);
        if(saveTracker.GetTreeLevel() < tree){
            saveTracker.ChangeTreeLevel(tree);
        }
        if(saveTracker.GetGroundLevel() < ground){
            saveTracker.ChangeGroundLevel(ground);
        }
        if(saveTracker.GetFlyLevel() < flying){
            saveTracker.ChangeFlyLevel(flying);
        }
        saveTracker.ChangeLastLevel(lastLevel);
        saveTracker.ChangeFileNum(saveFile);
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(tree, ground, flying, final, lastLevel);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadGameOne(){
        string path = Application.persistentDataPath + "/data1.soph";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else{
            return null;
        }
    }

    public static SaveData LoadGameTwo(){
        string path = Application.persistentDataPath + "/data2.soph";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else{
            return null;
        }
    }

    public static SaveData LoadGameThree(){
        string path = Application.persistentDataPath + "/data3.soph";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else{
            return null;
        }
    }
}
