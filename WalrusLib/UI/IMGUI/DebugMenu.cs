using System;
using UnityEngine;

namespace WalrusLib.UI.IMGUI
{
	public class DebugMenu : BaseUI
	{
		public GameObject MaterialDisplay = null;
		public DebugMenu()
		{
			ButtonName = "Debug";
		}

		public override void OnInit()
		{
		}
		public override void Setup()
		{
			GUILayout.Label("Just an empty debug");
		}

		public override void Disable()
		{
		}
	}
}
