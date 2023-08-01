using Assets._myAssets.Scripts.Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay.Elements
{
	public class BallSpawner : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private GameObject ballPrefab;

		private int ballCountToSpawn;

		private void Start()
		{
			ballCountToSpawn = LevelManager.Instance.levelList.levels[LevelManager.Instance.currentLevelIndex].levelAttributes.BallSpawnCount;

			SpawnBalls();
		}

		private void SpawnBalls()
		{
			List<Vector3> points = GenerateSpherePoints(ballCountToSpawn);

			for(int i = 0; i < ballCountToSpawn; i++)
			{
				GameObject ball = BallPool.Instance.GetObjectFromPool();
				ball.transform.position = points[i];
				ball.transform.parent = transform;
				ball.SetActive(true);
			}
		}

		private List<Vector3> GenerateSpherePoints(int numberOfPoints)
		{
			float goldenRatio = (1 + Mathf.Sqrt(5)) / 2;

			List<Vector3> points = new List<Vector3>();

			for (int i = 0; i < numberOfPoints; i++)
			{
				float latitude = Mathf.Acos(1 - 2 * i / (float)(numberOfPoints - 1));
				float longitude = 2 * Mathf.PI * i * goldenRatio;

				float x = .5f * Mathf.Sin(latitude) * Mathf.Cos(longitude);
				float y = .5f * Mathf.Cos(latitude);
				float z = .5f * Mathf.Sin(latitude) * Mathf.Sin(longitude);

				points.Add(new Vector3(x, y, z) + transform.position);
			}

			return points;
		}
	}
}