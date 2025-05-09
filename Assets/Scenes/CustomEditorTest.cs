using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestComponent))]
public class CustomEditorTest : Editor
{  
    public override void OnInspectorGUI()
    {
        
        TestComponent testComponent = (TestComponent) target;

        testComponent.value = EditorGUILayout.IntField("A", testComponent.value);

        EditorGUILayout.BeginVertical();

        if(GUILayout.Button("�ּ� ������ �����մϴ�."))
        {
            testComponent.value = int.MinValue;
        }

        if (GUILayout.Button("�ִ� ������ �����մϴ�."))
        {
            testComponent.value = int.MaxValue;
        }
        EditorGUILayout.EndVertical();

        if(GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }

}
