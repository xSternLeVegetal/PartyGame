using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;

namespace AssetInventory
{
    public sealed class VersionSelectionUI : PopupWindowContent
    {
        private AssetInfo _assetInfo;
        private PackageInfo _packageInfo;
        private Vector2 _scrollPos;
        private Action<string> _callback;

        public void Init(AssetInfo info, Action<string> callback)
        {
            _assetInfo = info;
            _callback = callback;
        }

        public override Vector2 GetWindowSize()
        {
            return new Vector2(400, 300);
        }

        public override void OnGUI(Rect rect)
        {
            if (_assetInfo == null) return;
            if (!AssetStore.IsMetadataAvailable())
            {
                EditorGUILayout.HelpBox("Loading package metadata...", MessageType.Info);
                return;
            }
            if (_packageInfo == null) _packageInfo = AssetStore.GetPackageInfo(_assetInfo.SafeName);
            if (_packageInfo == null)
            {
                EditorGUILayout.HelpBox("Could not find matching package metadata.", MessageType.Warning);
                EditorGUILayout.Space();
                if (!string.IsNullOrWhiteSpace(_assetInfo.LatestVersion))
                {
                    if (GUILayout.Button(UIStyles.Content($"Install indexed {_assetInfo.LatestVersion}"), GUILayout.Width(140)))
                    {
                        _callback?.Invoke(_assetInfo.LatestVersion);
                        editorWindow.Close();
                    }
                }
                return;
            }
            if (_packageInfo.versions.all.Length == 0)
            {
                if (_packageInfo.source == PackageSource.Embedded)
                {
                    EditorGUILayout.HelpBox("This is an embedded package with no other versions available.", MessageType.Info);
                }
                else
                {
                    EditorGUILayout.HelpBox("Could not find any other versions.", MessageType.Info);
                }
                return;
            }

            _scrollPos = GUILayout.BeginScrollView(_scrollPos, false, false);
            List<string> attributes = new List<string>();
            Color oldCol = GUI.backgroundColor;
            foreach (string version in _packageInfo.versions.all.Reverse())
            {
                bool compatible = false;
                bool isCurrent = false;

                attributes.Clear();
                if (_packageInfo.versions.compatible.Contains(version))
                {
                    attributes.Add("compatible");
                    compatible = true;
                }
                else
                {
                    GUI.backgroundColor = Color.yellow;
                }
#if UNITY_2022_2_OR_NEWER
                if (version == _packageInfo.versions.recommended)
#else
                if (version == _packageInfo.versions.verified)
#endif
                {
                    GUI.backgroundColor = Color.green;
                    attributes.Add("recommended");
                }
                if (AssetStore.IsInstalled(_packageInfo.name, version))
                {
                    attributes.Add("installed");
                    isCurrent = true;
                }

                GUILayout.BeginHorizontal();
                EditorGUI.BeginDisabledGroup(!compatible || isCurrent);
                if (GUILayout.Button(UIStyles.Content(version, "Install this version"), GUILayout.Width(140)))
                {
                    _callback?.Invoke(version);
                    editorWindow.Close();
                }
                EditorGUI.EndDisabledGroup();
                EditorGUI.BeginDisabledGroup(_assetInfo.GetChangeLogURL(version) == null);
                if (GUILayout.Button(UIStyles.Content("?", "Changelog"), GUILayout.Width(20)))
                {
                    Application.OpenURL(_assetInfo.GetChangeLogURL(version));
                }
                EditorGUI.EndDisabledGroup();
                if (attributes.Count > 0) GUILayout.Label(string.Join(", ", attributes));
                GUILayout.EndHorizontal();

                GUI.backgroundColor = oldCol;
            }
            GUILayout.EndScrollView();
        }
    }
}
