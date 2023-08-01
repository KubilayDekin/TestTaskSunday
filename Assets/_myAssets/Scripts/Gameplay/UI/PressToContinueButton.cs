using Assets._myAssets.Scripts.Engine;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay.UI
{
	public class PressToContinueButton : MonoBehaviour
	{
		public void OnButtonPress() => LevelManager.Instance.LoadNextLevel();
	}
}