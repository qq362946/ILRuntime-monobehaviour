using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(ILR_T1))]
public class Editor_ILR_T1 : Editor
{
    private int buttonHeight = 30;
    private int spaceHeight = 10;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ILR_T1 t = target as ILR_T1;
        GUILayout.Space(spaceHeight);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("保存数据",GUILayout.Height(buttonHeight)))
        {
            string MyJsonPath = Application.dataPath + "/Resources/AutoLoad/GameJsonData/[key].txt";
            string path = MyJsonPath.Replace("[key]", t.GetKey());
            string jsonStr = t.ToJson();
            File.WriteAllText(path, jsonStr);
			AssetDatabase.Refresh();
			//string assetPath = "Asset/Resources/AutoLoad/GameJsonData/[key]".Replace("[key]", t.GetKey());
            Debug.Log($"{t.gameObject.name} 数据保存成功");
            
        }
		if (GUILayout.Button("生效数据",GUILayout.Height(buttonHeight)))
		{
			t.SetDataValue();
		}
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("加载数据",GUILayout.Height(buttonHeight)))
		{
            t.LoadData();
        }
        if (GUILayout.Button("清除数据",GUILayout.Height(buttonHeight)))
		{
			string MyJsonPath = Application.dataPath + "/Resources/AutoLoad/GameJsonData/[key].txt";
            string path = MyJsonPath.Replace("[key]", t.GetKey());
            if(File.Exists(path))
            {
                File.Delete(path);
                AssetDatabase.Refresh();
                Debug.Log("清除成功");
            }
            else
            {
                Debug.Log("数据已经清除");
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(spaceHeight);
    }
}
