using UnityEngine;

namespace Assets._myAssets.Scripts.LevelDesign
{
	[CreateAssetMenu(fileName = "LevelAttributes", menuName = "LevelDesign/Level Attributes")]
	public class LevelAttributes : ScriptableObject
	{
		[Range(1,100)]
		public int BallSpawnCount;
		public int TargetBallCount;
	}
}

