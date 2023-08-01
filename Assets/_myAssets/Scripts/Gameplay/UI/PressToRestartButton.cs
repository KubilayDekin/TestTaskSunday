using Assets._myAssets.Scripts.Engine;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay.UI
{
	public class PressToRestartButton : MonoBehaviour
	{
		public void OnButtonPress() => LevelManager.Instance.ReloadLevel();
	}
}