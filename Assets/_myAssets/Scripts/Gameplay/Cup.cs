using Assets._myAssets.Scripts.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class Cup : MonoBehaviour
	{
		private int currentCountBallInsideCup;
		private int totalDroppedBallCount;
		private int totalBallCount;
		private int targetBallCount;
		private bool isWin;

		private void OnEnable()
		{
			BusSystem.OnBallEnterCup += HandleBallEnterCup;
			BusSystem.OnBallLost += HandleBallLost;
		}

		private void OnDisable()
		{
			BusSystem.OnBallEnterCup -= HandleBallEnterCup;
			BusSystem.OnBallLost -= HandleBallLost;
		}

		private void Start()
		{
			targetBallCount = LevelManager.Instance.levelList.levels[LevelManager.Instance.currentLevelIndex].levelAttributes.TargetBallCount;
			totalBallCount = LevelManager.Instance.levelList.levels[LevelManager.Instance.currentLevelIndex].levelAttributes.BallSpawnCount;
		}

		private void HandleBallLost()
		{
			totalDroppedBallCount++;

			CheckTotalBallCount();
		}

		private void HandleBallEnterCup()
		{
			currentCountBallInsideCup++;
			totalDroppedBallCount++;

			if (currentCountBallInsideCup >= targetBallCount)
				isWin = true;

			CheckTotalBallCount();
		}

		private void CheckTotalBallCount()
		{
			if(totalDroppedBallCount >= totalBallCount)
			{
				if (isWin)
					BusSystem.CallOnLevelCompleted();
				else
					BusSystem.CallOnLevelFailed();
			}

			BusSystem.CallUpdateBallCountText(currentCountBallInsideCup);
		}
	}
}

