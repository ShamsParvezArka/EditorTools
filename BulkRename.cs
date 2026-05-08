using UnityEngine;
using UnityEditor;

public class BulkRename : EditorWindow
{
    private static int m_windowWidth  = 250;
    private static int m_windowHeight = 100;
    
    private string m_prefix;
    private int m_startingIndex;

    [MenuItem("Tools/Bulk Rename")]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow<BulkRename>();
        window.minSize = new Vector2Int(m_windowWidth, m_windowHeight);
        window.maxSize = new Vector2Int(m_windowWidth, m_windowHeight);
    }

    private void OnGUI()
    {
        m_prefix = EditorGUILayout.TextField("Prefix", m_prefix);
        m_startingIndex = EditorGUILayout.IntField("Start index", m_startingIndex);

        if (GUILayout.Button("Rename Children"))
        {
            GameObject[] entities = Selection.gameObjects;
            for (int entity = 0, idx = m_startingIndex; entity < entities.Length; entity++, idx++)
            {
                // NOTE(arka): idx:D3 means formating idx as 3 digit number padded with leading zeros if necessary
                entities[entity].name = $"{m_prefix}.{idx:D3}";

            }
        }
    }
}
