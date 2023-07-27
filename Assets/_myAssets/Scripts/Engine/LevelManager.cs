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
		private int currentLevelIndex = 0;

		void Start()
		{
			LoadCurrentLevel();
		}

		public void LoadNextLevel()
		{
			currentLevelIndex++;
			if (currentLevelIndex >= levelList.levels.Count)
			{
				return;
			}

			LoadCurrentLevel();
		}

		public void ReloadLevel()
		{
			LoadCurrentLevel();
		}

		private void LoadCurrentLevel()
		{
			SceneManager.LoadSceneAsync(levelList.levels[currentLevelIndex].SceneName);
		}
	}
}