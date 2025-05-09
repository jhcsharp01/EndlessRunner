using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestComponent))]
public class CustomEditorTest : Editor
{  
    public override void OnInspectorGUI()
    {
        
        TestComponent testComponent = (TestComponent) target;

        testComponent.value = EditorGUILayout.IntField("A", testComponent.value);

        EditorGUILayout.BeginHorizontal();

        if(GUILayout.Button("�ּ� ������ �����մϴ�."))
        {
            testComponent.value = int.MinValue;
        }

        if (GUILayout.Button("�ִ� ������ �����մϴ�."))
        {
            testComponent.value = int.MaxValue;
        }
        EditorGUILayout.EndHorizontal();

        if(GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }

}
