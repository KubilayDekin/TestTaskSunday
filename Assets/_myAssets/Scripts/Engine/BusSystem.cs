using System;
using System.Collections;
using UnityEngine;

namespace Assets._myAssets.Scripts.Engine
{
	public class BusSystem : MonoBehaviour
	{
		#region Gameplay Actions
		public static Action OnBallEnterCup;
		public static void CallBallEnterCup() { OnBallEnterCup?.Invoke(); }

		public static Action OnBallLost;
		public static void CallBallLost() { OnBallLost?.Invoke(); }

		public static Action<int> OnUpdateBallCountText;
		public static void CallUpdateBallCountText(int ballCountInCup) { OnUpdateBallCountText?.Invoke(ballCountInCup); }
		#endregion

		#region Level Actions

		public static Action OnLevelCompleted;
		public static void CallOnLevelCompleted() { OnLevelCompleted?.Invoke(); }

		public static Action OnLevelFailed;
		public static void CallOnLevelFailed() { OnLevelFailed?.Invoke(); }

		#endregion
	}
}