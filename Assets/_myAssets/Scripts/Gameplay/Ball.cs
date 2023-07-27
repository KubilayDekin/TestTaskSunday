using Assets._myAssets.Scripts.Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class Ball : MonoBehaviour
	{
		private MeshRenderer meshRenderer;

		private void Awake()
		{
			meshRenderer = GetComponent<MeshRenderer>();	
		}

		private void OnDestroy()
		{
			BallPool.Instance.ReturnObjectToPool(gameObject);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer(Constants.CUP_LAYER))
			{
				BusSystem.CallOnBallEnterCup();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer(Constants.TUBE_DETECTOR_LAYER))
			{
				transform.parent = null;
			}
		}

		public void SetBallColor(Color ballColor)
		{
			meshRenderer.material.color = ballColor;
		}
	}
}

