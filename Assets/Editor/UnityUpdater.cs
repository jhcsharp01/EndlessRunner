using System;
using UnityEditor;
using UnityEngine;


public class UnityUpdater
{
    [InitializeOnLoadMethod]
    static void ProjectLoadedInEditor()
    {
        Debug.Log("Project loaded in Unity");

    }
}
