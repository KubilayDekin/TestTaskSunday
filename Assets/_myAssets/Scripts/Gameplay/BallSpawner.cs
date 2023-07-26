using System.Collections;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class BallSpawner : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private GameObject ballPrefab;
		[SerializeField] private int num;

		private void Start()
		{
			SpawnBalls();
		}

		private void SpawnBalls()
		{
			for(int i = 0; i < num; i++)
			{
				GameObject ball = BallPool.Instance.GetObjectFromPool();
				ball.SetActive(true);
			}
		}
	}
}