using Assets._myAssets.Scripts.Engine;
using System.Collections;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class PressToContinueButton : MonoBehaviour
	{
		public void OnButtonPress() => LevelManager.Instance.LoadNextLevel();
	}
}