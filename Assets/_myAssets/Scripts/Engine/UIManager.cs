using System;
using System.Collections;
using UnityEngine;

namespace Assets._myAssets.Scripts.Engine
{
	public class UIManager : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private Canvas youWinCanvas;
		[SerializeField] private Canvas youLostCanvas;

		private void OnEnable()
		{
			BusSystem.OnLevelCompleted += HandleOnLevelCompleted;
			BusSystem.OnLevelFailed += HandleOnLevelFailed;
		}

		private void OnDisable()
		{
			BusSystem.OnLevelCompleted -= HandleOnLevelCompleted;
			BusSystem.OnLevelFailed -= HandleOnLevelFailed;
		}

		private void HandleOnLevelCompleted()
		{
			youWinCanvas.enabled = true;
		}

		private void HandleOnLevelFailed()
		{
			youLostCanvas.enabled = true;
		}
	}
}