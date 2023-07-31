using Assets._myAssets.Scripts.Engine;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class BallCountCanvas : MonoBehaviour
	{
		private TextMeshProUGUI ballCountText;

		private int targetBallCount;

		private void OnEnable()
		{
			BusSystem.OnUpdateBallCountText += HandleOnBallEnterCup;
		}

		private void OnDisable()
		{
			BusSystem.OnUpdateBallCountText -= HandleOnBallEnterCup;
		}

		private void Start()
		{
			targetBallCount = LevelManager.Instance.levelList.levels[LevelManager.Instance.currentLevelIndex].levelAttributes.TargetBallCount;
			ballCountText = GetComponentInChildren<TextMeshProUGUI>();
			HandleOnBallEnterCup(0);
		}

		private void HandleOnBallEnterCup(int ballCount)
		{
			ballCountText.text = ballCount.ToString() + "/" + targetBallCount.ToString();
		}
	}
}