using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class AppInitializer : MonoBehaviour
	{
		private void Awake()
		{
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 60;

			SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
		}
	}
}

