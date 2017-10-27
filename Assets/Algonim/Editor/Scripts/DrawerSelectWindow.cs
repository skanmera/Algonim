using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using Algonim;

namespace Algonim.Editor
{
    public class DrawerSelectWindow : EditorWindow
    {
        private Vector2 scrollPos;

        [MenuItem("Algonim/Clear")]
        private static void Clear()
        {
            DrawerManager.Instance.Clear();
        }

        [MenuItem("Algonim/Select Drawer")]
        private static void Open()
        {
            GetWindow<DrawerSelectWindow>();
        }

        [MenuItem("Algonim/Select Drawer", true)]
        private static bool CanOpen()
        {
            return DrawerManager.Instance.AnyDrawer();
        }

        private void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            EditorGUILayout.BeginHorizontal();

            EditorGUI.BeginChangeCheck();
            var names = DrawerManager.Instance.GetDrawerNames();
            var fontStyle = new GUIStyle(GUI.skin.button);
            fontStyle.alignment = TextAnchor.MiddleLeft;
            var selectedIndex = GUILayout.SelectionGrid(DrawerManager.Instance.GetSelectedIndex(), names, 1, fontStyle);
            if (EditorGUI.EndChangeCheck())
            {
                DrawerManager.Instance.Stop();
                DrawerManager.Instance.SetDrawer(selectedIndex);
                DrawerManager.Instance.Play();
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space();

            var stateStrings = DrawerManager.Instance.IsPlaying ? new string[] { "■", "||" } : new string[] { "▶", "||" };
            var currentState = -1;
            if (DrawerManager.Instance.IsPausing)
            {
                currentState = 1;
            }

            EditorGUI.BeginChangeCheck();
            selectedIndex = GUILayout.SelectionGrid(currentState, stateStrings, 3);
            if (EditorGUI.EndChangeCheck())
            {
                if (selectedIndex == 0)
                {
                    if (DrawerManager.Instance.IsPlaying)
                        DrawerManager.Instance.Stop();
                    else
                        DrawerManager.Instance.Play();
                }
                else if (selectedIndex == 1)
                {
                    DrawerManager.Instance.Pause();
                }
            }

            EditorGUILayout.Space();
        }

        private void OnDestroy()
        {
            DrawerManager.Instance.Stop();
        }
    }
}
