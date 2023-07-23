using BepInEx;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using WalrusLib.UI.IMGUI;

namespace WalrusLib
{
	[BepInPlugin(MOD_ID, MOD_NAME, MOD_VERSION)]
	public class Main : BaseMod
	{
		public const string MOD_ID = "walruslib";
		public const string MOD_NAME = "WalrusLib";
		public const string MOD_VERSION = "0.1.0";
		public const string MOD_BETA_VERSION = "";

		public Main() : base(MOD_ID, MOD_NAME, MOD_VERSION, MOD_BETA_VERSION, Assembly.GetExecutingAssembly()) { }

		void Awake()
		{
			SceneManager.activeSceneChanged += ChangedActiveScene;
			//RegisterMenu<DebugMenu>();
		}

		private void ChangedActiveScene(Scene current, Scene next)
		{
			GameObject gameObject = new GameObject(MOD_NAME);
			gameObject.AddComponent<WalrusLib>();
		}
	}

	public class WalrusLib : MonoBehaviour
	{
		private static bool isFirstLoad = true;

		void Start()
		{
			if (isFirstLoad)
			{
				isFirstLoad = false;
			}

			if (gameObject.GetComponent<DevUIController>() == null)
			{
				gameObject.AddComponent<DevUIController>();
			}
		}
	}
}