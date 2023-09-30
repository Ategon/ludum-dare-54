namespace Auboreal {

	using UnityEditor;
	using System.IO;
	using System.Collections.Generic;
	using UnityEngine;

	public class BuildManager : MonoBehaviour {

		private static string GetProjectPath() {
			return Path.GetFullPath(Path.Combine(Application.dataPath, "../"));
		}

		[MenuItem("Build/Build All")]
		public static void BuildAll() {
			BuildWindows();
			BuildWebGL();
			BuildMac();
			BuildLinux();
		}

		[MenuItem("Build/Build Windows")]
		public static void BuildWindows() {
			var outputPath = Path.Combine(GetProjectPath(), "Builds/Windows/");
			var scenes = GetScenes();

			Directory.CreateDirectory(outputPath);
			var gameName = PlayerSettings.productName;

			BuildPipeline.BuildPlayer(scenes, Path.Combine(outputPath, $"{gameName}.exe"),
				BuildTarget.StandaloneWindows64, BuildOptions.None);
		}

		[MenuItem("Build/Build WebGL")]
		public static void BuildWebGL() {
			var outputPath = Path.Combine(GetProjectPath(), "Builds/WebGL/");
			var scenes = GetScenes();

			Directory.CreateDirectory(outputPath);
			BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.WebGL, BuildOptions.None);
		}

		[MenuItem("Build/Build Mac")]
		public static void BuildMac() {
			var outputPath = Path.Combine(GetProjectPath(), "Builds/Mac/");
			var scenes = GetScenes();

			Directory.CreateDirectory(outputPath);
			var gameName = PlayerSettings.productName;

			BuildPipeline.BuildPlayer(scenes, Path.Combine(outputPath, $"{gameName}.app"),
				BuildTarget.StandaloneOSX, BuildOptions.None);
		}

		[MenuItem("Build/Build Linux")]
		public static void BuildLinux() {
			var outputPath = Path.Combine(GetProjectPath(), "Builds/Linux/");
			var scenes = GetScenes();

			Directory.CreateDirectory(outputPath);
			var gameName = PlayerSettings.productName;

			BuildPipeline.BuildPlayer(scenes, Path.Combine(outputPath, gameName),
				BuildTarget.StandaloneLinux64, BuildOptions.None);
		}

		private static string[] GetScenes() {
			List<string> scenes = new List<string>();

			foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
				if (scene.enabled) {
					scenes.Add(scene.path);
				}
			}

			return scenes.ToArray();
		}

	}

}