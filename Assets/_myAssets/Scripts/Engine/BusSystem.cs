using System;
using System.Collections;
using UnityEngine;

namespace Assets._myAssets.Scripts.Engine
{
	public class BusSystem : MonoBehaviour
	{
		#region Gameplay Actions
		public static Action OnBallEnterCup;
		public static void CallOnBallEnterCup() { OnBallEnterCup?.Invoke(); }
		#endregion
	}
}