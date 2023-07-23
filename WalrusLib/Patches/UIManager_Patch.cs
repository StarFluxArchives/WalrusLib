using HarmonyLib;
using WalrusLib.UI.IMGUI;

namespace WalrusLib.Patches
{
	[HarmonyPatch(typeof(UIManager), "get_anyMenuOpen")]
	internal class UIManager_Patch
	{
		static void Postfix(ref bool __result)
		{
			__result = __result || DevUIController.isOpen;
		}
	}
}
