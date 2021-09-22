using UnityEngine;
using UnityEditor;

public class PrefabUtilityWindow : EditorWindow
{
	protected const string PREFABUTILITYSWINDOW_PATH = "Prefabs/Windows/PrefabUtilityWindow";    

	public static PrefabUtilityWindow prefabWindow;                                        

	[SerializeField] private GameObject prefab;                                        
	private Vector2 _scrollPos;                                                         


	[MenuItem(PREFABUTILITYSWINDOW_PATH)]
	public static PrefabUtilityWindow CreatePrefabUtilitysWindow()
	{
		prefabWindow = GetWindow<PrefabUtilityWindow>("Prefab Changer");

		return prefabWindow;
	}

    [System.Obsolete]
    private void OnGUI()
	{
		CreateLabel("Prefab");
		EditorGUILayout.BeginHorizontal();

		prefab = EditorGUILayout.ObjectField(prefab, typeof(GameObject), false) as GameObject;

		if (prefab != null && Selection.gameObjects.Length > 0)
		{
			if (GUILayout.Button("Change Objets to Prefabs"))
			{
				SubstituteGameObjectsForPrefabs();
			}
		}
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.Space();

		CreateLabel("Selected GameObjects");
		_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
		ShowSeletedGameObjects();

		EditorGUILayout.EndScrollView();
	}


	void CreateLabel(string _text)
	{
		GUILayout.Label(_text, EditorStyles.boldLabel);

	}
	
	void CreateContentLabel(string _text)
	{
		GUILayout.Label(_text);
	}
	
	void ShowSeletedGameObjects()
	{

		for (int i = 0; i < Selection.gameObjects.Length; i++)
		{

			CreateContentLabel(Selection.gameObjects[i].name);

		}

	}

    [System.Obsolete]
    void SubstituteGameObjectsForPrefabs()
	{

		int i = 0;
		int initialObjectsAmount = Selection.gameObjects.Length;
		float progressAmount = 0;

		while (Selection.gameObjects.Length != i)
		{
			progressAmount += 1;
			EditorUtility.DisplayProgressBar("Prefabs Subtitution", "Working on it...", progressAmount / initialObjectsAmount);
			Vector3 recycledPosition = Selection.gameObjects[i].transform.position;
			Quaternion recycledRotation = Selection.gameObjects[i].transform.rotation;

			GameObject obj = PrefabUtility.ConnectGameObjectToPrefab(Selection.gameObjects[i], prefab);
			obj.transform.position = recycledPosition;
			obj.transform.rotation = recycledRotation;

		}
		EditorUtility.ClearProgressBar();
	}

}