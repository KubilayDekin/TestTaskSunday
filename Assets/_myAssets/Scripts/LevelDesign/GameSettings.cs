using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.LevelDesign
{
	[CreateAssetMenu(fileName = "GameSettings", menuName = "LevelDesign/Game Settings")]
	public class GameSettings : ScriptableObject
	{
		[Header("Ball Physics")]
		[Range(0f,1f)]
		public float ballSlipperiness;
		[Range(0f, 1f)]
		public float ballBounciness;

		[Header("Tube Settings")]
		public float tubeRotationSpeed;

		[Header("Ball Settings")]
		public List<Color> ballColors;
	}
}