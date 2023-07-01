using System.IO;
using System.Linq;
using RectTest;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ScrollViewReplacer
    {
        [MenuItem("Tools/Replace All Scroll Rects")]
        public static void ReplaceAllScrollRects()
        {
            var dataPath = Application.dataPath;
            var guid = AssetDatabase.FindAssets($"{nameof(ObservedScrollRect)} t:script").First();
            foreach (var scenePath in Directory.EnumerateFiles(dataPath, "*.unity", SearchOption.AllDirectories))
            {
                var sceneContent = File.ReadAllText(scenePath);
                sceneContent = sceneContent.Replace("guid: 1aa08ab6e0800fa44ae55d278d1423e3", $"guid: {guid}");
                File.WriteAllText(scenePath, sceneContent);
            }

            AssetDatabase.Refresh();
        }
    }
}