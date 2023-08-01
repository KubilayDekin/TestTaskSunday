using Assets._myAssets.Scripts.Extensions;
using Assets._myAssets.Scripts.Gameplay.Elements;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._myAssets.Scripts.Engine
{
	public class LevelManager : SingletonMonoBehaviour<LevelManager>
	{
		public LevelList levelList;
		public int currentLevelIndex { get; private set; }

		private SceneObject oldScene;

		protected override void Awake()
		{
			base.Awake();

			currentLevelIndex = PlayerPrefs.GetInt(Constants.CURRENT_LEVEL, 0);
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

			if(oldScene != null)
				SceneManager.UnloadSceneAsync(oldScene);

			oldScene = levelList.levels[currentLevelIndex].levelScene;
			SceneManager.LoadSceneAsync(oldScene.SceneName, LoadSceneMode.Additive);
		}
	}
}