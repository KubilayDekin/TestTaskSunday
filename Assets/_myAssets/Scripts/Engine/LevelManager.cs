using Assets._myAssets.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._myAssets.Scripts.Engine
{
	public class LevelManager : SingletonMonoBehaviour<LevelManager>
	{
		public LevelList levelList;
		public int currentLevelIndex { get; private set; }

		protected override void Awake()
		{
			base.Awake();

			currentLevelIndex = PlayerPrefs.GetInt(Constants.CURRENT_LEVEL, 0);
		}

		private void OnEnable()
		{
			BusSystem.OnLevelCompleted += LoadNextLevel;
			BusSystem.OnLevelFailed += ReloadLevel;
		}

		private void OnDisable()
		{
			BusSystem.OnLevelCompleted -= LoadNextLevel;
			BusSystem.OnLevelFailed -= ReloadLevel;
		}

		void Start()
		{
			LoadCurrentLevel();
		}

		public void LoadNextLevel()
		{
			currentLevelIndex++;

			if (currentLevelIndex >= levelList.levels.Count)
			{
				currentLevelIndex = 0;
			}

			LoadCurrentLevel();
			PlayerPrefs.SetInt(Constants.CURRENT_LEVEL, currentLevelIndex);
		}

		public void ReloadLevel()
		{
			LoadCurrentLevel();
		}

		private void LoadCurrentLevel()
		{
			foreach(GameObject ball in BallPool.Instance.ballPool)
			{
				if (ball.activeSelf)
				{
					BallPool.Instance.ReturnObjectToPool(ball);
				}
			}

			SceneManager.LoadSceneAsync(levelList.levels[currentLevelIndex].levelScene.SceneName);
		}
	}
}