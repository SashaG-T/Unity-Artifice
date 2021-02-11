using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor.Tilemaps
{
    [CustomGridBrush(true, false, false, "Path Brush")]
    public class PathBrush : GridBrush
    {
        public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
        {
            base.Paint(grid, brushTarget, new Vector3Int(position.x, position.y, position.z));
        }
        [MenuItem("Assets/Create/Path Brush")]
        public static void CreateBrush()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Path Brush", "New Path Brush", "Asset", "Save Path Brush", "Assets");
            if (path == "")
                return;
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<PathBrush>(), path);
        }
    }
    
    [CustomEditor(typeof(PathBrush))]
    public class PathBrushEditor : GridBrushEditor
    {
        private PathBrush pathBrush { get { return target as PathBrush; } }

        public override void OnPaintSceneGUI(GridLayout grid, GameObject brushTarget, BoundsInt position, GridBrushBase.Tool tool, bool executing)
        {
            base.OnPaintSceneGUI(grid, brushTarget, position, tool, executing);
        }
    }
}