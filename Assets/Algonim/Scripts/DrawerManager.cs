using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Algonim.Drawers;

namespace Algonim
{
    [ExecuteInEditMode]
    public class DrawerManager : SingletonMonoBehaviour<DrawerManager>
    {
        public int ElapsedFrameCount { get; private set; }
        public bool IsPlaying { get; private set; }
        public bool IsPausing { get; private set; }
        public bool IsStopped { get { return !IsPlaying && !IsPausing; } }
        public Dictionary<string, Drawer> DrawerMap { get; private set; }
        public Drawer SelectedDrawer { get; private set; }

        private DrawerManager()
        {
            DrawerMap = new Dictionary<string, Drawer>();
        }

        public bool AddDrawer(string name, Drawer drawer)
        {
            if (DrawerMap.ContainsKey(name))
                return false;

            DrawerMap.Add(name, drawer);

            return true;
        }

        public void SetDrawer(string name)
        {
            Drawer drawer;
            if (DrawerMap.TryGetValue(name, out drawer))
            {
                Stop();
                SelectedDrawer = drawer;
                SelectedDrawer.Initialize();
                ElapsedFrameCount = 0;
            }
        }

        public void SetDrawer(int index)
        {
            var i = 0;
            foreach (var d in DrawerMap)
            {
                if (i == index)
                    SetDrawer(d.Key);

                i++;
            }
        }

        public bool AnyDrawer()
        {
            return DrawerMap.Any();
        }

        public int GetSelectedIndex()
        {
            var index = 0;
            foreach (var d in DrawerMap)
            {
                if (d.Value == SelectedDrawer)
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public string[] GetDrawerNames()
        {
            return DrawerMap.Keys.ToArray();
        }

        public void Play()
        {
            if (SelectedDrawer == null)
                return;

            EditorApplication.update += EditorUpdate;

            IsPlaying = true;
            IsPausing = false;
        }

        public void Stop()
        {
            EditorApplication.update -= EditorUpdate;

            if(SelectedDrawer != null)
                SelectedDrawer.Initialize();

            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();

            ElapsedFrameCount = 0;
            IsPlaying = false;
            IsPausing = false;
        }

        public void Pause()
        {
            IsPlaying = false;
            IsPausing = true;
        }

        public void Clear()
        {
            DrawerMap.Clear();
        }

        private void OnEnable()
        {
            ElapsedFrameCount = 0;
            DrawerMap.Clear();
        }

        private void OnDisable()
        {
            ElapsedFrameCount = 0;
            EditorApplication.update -= EditorUpdate;
            DrawerMap.Clear();
        }

        protected override void OnRenderObject()
        {
            if (IsStopped)
                return;

            Draw();
        }

        private void Draw()
        {
            if(SelectedDrawer != null)
                SelectedDrawer.Draw();
        }

        private bool UpdateDrawers()
        {
            if (IsPausing)
                return true;

            if (SelectedDrawer != null)
                return SelectedDrawer.Update(ElapsedFrameCount);

            return false;
        }

        private bool ShouldRepaint()
        {
            return UpdateDrawers();
        }

        private void EditorUpdate()
        {
            if (ShouldRepaint())
                UnityEditorInternal.InternalEditorUtility.RepaintAllViews();

            ElapsedFrameCount++;
        }
    }
}
