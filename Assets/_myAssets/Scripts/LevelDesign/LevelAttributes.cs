using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.LevelDesign
{
	[CreateAssetMenu(fileName = "LevelAttributes", menuName = "LevelDesign/Level Attributes")]
	public class LevelAttributes : ScriptableObject
	{
		public int BallSpawnCount;
		public int TargetBallCount;
	}
}

