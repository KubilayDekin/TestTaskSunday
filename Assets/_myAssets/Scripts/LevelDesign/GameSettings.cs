using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.LevelDesign
{
	[CreateAssetMenu(fileName = "GameSettings", menuName = "LevelDesign/Game Settings")]
	public class GameSettings : ScriptableObject
	{
		[Header("Ball Physics")]
		public float dynamicFriction;
		public float staticFriction;
		public float bounciness;

		public PhysicMaterialCombine frictionCombine;
		public PhysicMaterialCombine bouncinessCombine;

		[Header("Tube Settings")]
		public float tubeRotationSpeed;

		[Header("Ball Settings")]
		public List<Color> ballColors;
	}
}