using Assets._myAssets.Scripts.Extensions;
using Assets._myAssets.Scripts.LevelDesign;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.Engine
{
	[Serializable]
	[CreateAssetMenu(fileName = "LevelList", menuName = "Data/Level List")]
	public class LevelList : ScriptableObject
	{
		public List<LevelData> levels;
	}
}