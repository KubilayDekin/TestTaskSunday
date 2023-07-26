using Assets._myAssets.Scripts.Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class BallPool : SingletonMonoBehaviour<BallPool>
	{
		public GameObject prefab;           // The prefab you want to pool
		public int poolSize = 100;           // Number of objects to create in the pool initially
		public bool expandable = true;      // Allow the pool to expand if needed
		public List<GameObject> pool;       // The list that holds the pooled objects

		private void Start()
		{
			pool = new List<GameObject>();

			for (int i = 0; i < poolSize; i++)
			{
				CreatePooledObject();
			}
		}

		private void CreatePooledObject()
		{
			GameObject obj = Instantiate(prefab);
			obj.SetActive(false);
			pool.Add(obj);
		}

		public GameObject GetObjectFromPool()
		{
			for (int i = 0; i < pool.Count; i++)
			{
				if (!pool[i].activeInHierarchy)
				{
					return pool[i];
				}
			}

			if (expandable)
			{
				GameObject obj = Instantiate(prefab);
				obj.SetActive(false);
				pool.Add(obj);
				return obj;
			}

			return null;
		}

		public void ReturnObjectToPool(GameObject obj)
		{
			obj.SetActive(false);
		}
	}
}