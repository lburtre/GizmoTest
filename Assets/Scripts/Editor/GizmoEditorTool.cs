using UnityEditor;
using UnityEngine;

public class ShowGizmos: EditorWindow
{
    string myString = "TestDisplayString";

    [MenuItem("Window/Custom/Show Gizmos")] //Path to find the window
    public static void ShowGismosWindow()
    {
        EditorWindow.GetWindow<ShowGizmos>("Gizmo Editor"); //Name of the window
    }

    private void OnGUI()
    {
        GUILayout.Label("Test Title Label");

        myString = EditorGUILayout.TextField("Test Text 1", myString);

        if (GUILayout.Button("TestButton"))
        {
            Debug.Log(22);
        }

        //Selection.gameObjects => Return all the gameObjects selected in the scene

    }
}
