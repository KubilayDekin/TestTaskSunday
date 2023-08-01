using Assets._myAssets.Scripts.Engine;
using Assets._myAssets.Scripts.LevelDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class BallPool : SingletonMonoBehaviour<BallPool>
	{
		public GameSettings gameSettings;

		public GameObject ballPrefab;           // The prefab you want to pool
		public int poolSize = 100;           // Number of objects to create in the pool initially
		[HideInInspector]
		public List<GameObject> ballPool;       // The list that holds the pooled objects

		protected override void Awake()
		{
			base.Awake();

			ballPool = new List<GameObject>();

			for (int i = 0; i < poolSize; i++)
			{
				CreatePooledObject();
			}
		}

		private void CreatePooledObject()
		{
			GameObject obj = Instantiate(ballPrefab);
			obj.GetComponent<Ball>().SetBallColor(gameSettings.ballColors[Random.Range(0, gameSettings.ballColors.Count)]);
			obj.transform.parent = transform;
			obj.SetActive(false);
			ballPool.Add(obj);
		}

		public GameObject GetObjectFromPool()
		{
			for (int i = 0; i < ballPool.Count; i++)
			{
				if (!ballPool[i].activeInHierarchy)
				{
					return ballPool[i];
				}
			}

			return null;
		}

		public void ReturnObjectToPool(GameObject obj)
		{
			obj.SetActive(false);
			obj.transform.parent = transform;
		}
	}
}