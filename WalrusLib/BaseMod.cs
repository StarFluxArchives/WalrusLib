using BepInEx;
using HarmonyLib;
using System.Reflection;
using WalrusLib.UI.IMGUI;

namespace WalrusLib
{
	public abstract class BaseMod : BaseUnityPlugin
	{
		private Harmony harmonyInstance = null;
		public string MOD_ID = "";
		public string MOD_NAME = "";
		public string MOD_VERSION = "";
		public string MOD_BETA_VERSION = "";
		public Assembly MOD_ASSEMBLY = null;
		public static BaseMod instance;

		public BaseMod(string MOD_ID, string MOD_NAME, string MOD_VERSION, string MOD_BETA_VERSION, Assembly MOD_ASSEMBLY)
		{
			SetupMod(MOD_ID, MOD_NAME, MOD_VERSION, MOD_BETA_VERSION, MOD_ASSEMBLY);
		}

		private void SetupMod(string MOD_ID, string MOD_NAME, string MOD_VERSION, string MOD_BETA_VERSION, Assembly MOD_ASSEMBLY)
		{
			this.MOD_ID = MOD_ID;
			this.MOD_NAME = MOD_NAME;
			this.MOD_VERSION = MOD_VERSION;
			if (!string.IsNullOrEmpty(MOD_BETA_VERSION))
				this.MOD_BETA_VERSION = " b" + MOD_BETA_VERSION;
			this.MOD_ASSEMBLY = MOD_ASSEMBLY;

			if (harmonyInstance == null)
				harmonyInstance = new Harmony(MOD_ID);

			harmonyInstance.PatchAll(MOD_ASSEMBLY);
		}

		public void RegisterMenu<T>() where T : BaseUI, new()
		{
			T menu = new T();
			DevUIController._uiList.Add(menu);
		}
	}
}
