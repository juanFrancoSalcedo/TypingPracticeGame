using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace B_Extensions.SceneLoader
{ 
    public class ShortCutScenes
    {
        #if UNITY_EDITOR
    
        [MenuItem("B_Extensions/SceneLoader/Previous Scene #%LEFT")]
        public static void DisplayTwo()
        {
            EditorSceneManager.OpenScene(WindowSceneSelection.previousScenePath);
        }
        #endif
    }
}
