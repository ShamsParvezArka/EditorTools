using UnityEngine;
using UnityEditor;

public class GridArranger : EditorWindow
{
    private static int m_windowWidth  = 250;
    private static int m_windowHeight = 100;

    private int m_offsetValue = 3;
    private int m_columns;

    [MenuItem("Tools/Grid Arranger")]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow<GridArranger>();
        window.minSize = new Vector2Int(m_windowWidth, m_windowHeight);
        window.maxSize = new Vector2Int(m_windowWidth, m_windowHeight);
    }

    private void OnGUI()
    {
        m_offsetValue  = EditorGUILayout.IntField("Offset", m_offsetValue);
        m_columns = EditorGUILayout.IntField("Object Per Row", m_columns);

        if (GUILayout.Button("Rearrange"))
        {
            GameObject[] entities = Selection.gameObjects;
            Vector3 startingPosition = entities[0].transform.position;
            int rows = Mathf.CeilToInt((float)entities.Length / (float)m_columns);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < m_columns; col++)
                {
                    int idx = row * m_columns + col;
                    if (idx >= entities.Length)
                    {
                        break;
                    }

                    Vector3 newPosition = startingPosition + new Vector3(
                        col * m_offsetValue,
                        0f,
                        row * m_offsetValue
                    );
                    entities[idx].transform.position = newPosition;
                }
            }
        }
    }
}