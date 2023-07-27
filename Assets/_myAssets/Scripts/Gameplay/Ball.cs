using Assets._myAssets.Scripts.Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class Ball : MonoBehaviour
	{
		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer(Constants.TUBE_DETECTOR_LAYER))
			{
				transform.parent = null;
				Debug.Log("ball is freeee");
			}
		}
	}
}

