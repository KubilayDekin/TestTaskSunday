using Assets._myAssets.Scripts.Extensions;
using UnityEngine;

namespace Assets._myAssets.Scripts.LevelDesign
{
	[CreateAssetMenu(fileName = "LevelData", menuName = "LevelDesign/LevelData")]
	public class LevelData : ScriptableObject
	{
		public SceneObject levelScene;
		public LevelAttributes levelAttributes;
	}
}