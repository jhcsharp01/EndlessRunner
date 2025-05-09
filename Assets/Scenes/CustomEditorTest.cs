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

        if(GUILayout.Button("최소 값으로 설정합니다."))
        {
            testComponent.value = int.MinValue;
        }

        if (GUILayout.Button("최대 값으로 설정합니다."))
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
