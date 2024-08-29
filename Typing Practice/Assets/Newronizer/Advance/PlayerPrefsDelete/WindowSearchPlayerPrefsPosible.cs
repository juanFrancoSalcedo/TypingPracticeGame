﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



namespace B_Extensions
{
#if UNITY_EDITOR

    public class WindowSearchPlayerPrefsPosible : EditorWindow
    {
        [MenuItem("B_Extensions/PlayerPrefs Elimination")]
        public static void ShowWindow()
        {
            //PlayerPrefs.SetString(KeyStorage.PlayersTest, "Hola Mundo");
            SearchPlayerPrefs();
            EditorWindow window = GetWindow(typeof(WindowSearchPlayerPrefsPosible));
            window.Show();
        }

        static List<string> bufferSearch = new List<string>();
        private void OnGUI()
        {

            if (GUILayout.Button("Delete All"))
            {
                PlayerPrefs.DeleteAll();
                SearchPlayerPrefs();
            }
            if (!ExistsSearch)
            {
                GUIStyle textStyle = EditorStyles.label;
                textStyle.wordWrap = true;
                Vector2 p = new Vector2(0, 30f);
                Vector2 s = new Vector2(position.width, 200f);
                var textRect = new Rect(p, s);
                string text = "Se busca dependiendo de los Player Prefs guardados como llaves en la clase \"KeyStorage\"";
                EditorGUI.LabelField(textRect, text, textStyle);
                return;
            }

            try
            {
                foreach (var item in bufferSearch)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(item);
                    if (GUILayout.Button("Delete"))
                    {
                        PlayerPrefs.DeleteKey(item);
                        SearchPlayerPrefs();
                    }

                    if (GUILayout.Button("Show"))
                    {
                        Debug.Log("Float:"+PlayerPrefs.GetFloat(item));
                        Debug.Log("Int:" + PlayerPrefs.GetInt(item));
                        Debug.Log("String:" + PlayerPrefs.GetString(item));

                    }
                    GUILayout.EndHorizontal();
                }
            }
            catch (System.Exception) { }

            this.Repaint();
        }

        public static void SearchPlayerPrefs()
        {
            bufferSearch.Clear();
            foreach (var item in typeof(KeyStorage).GetFields())
            {
                var valueItem = item.GetValue(item).ToString();
                if (PlayerPrefs.HasKey(valueItem))
                    bufferSearch.Add(valueItem);
            }
        }
        private static bool ExistsSearch => bufferSearch.Count > 0;
    }
#endif
}
