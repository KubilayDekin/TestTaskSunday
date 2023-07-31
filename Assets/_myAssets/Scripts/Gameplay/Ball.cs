using Assets._myAssets.Scripts.Engine;
using Assets._myAssets.Scripts.LevelDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay
{
	public class Ball : MonoBehaviour
	{
		public GameSettings gameSettings;

		private Collider col;
		private MeshRenderer meshRenderer;
		private bool isInactive;

		private void Awake()
		{
			PhysicMaterial physicsMaterial = new PhysicMaterial();

			physicsMaterial.staticFriction = gameSettings.staticFriction;
			physicsMaterial.dynamicFriction = gameSettings.dynamicFriction;
			physicsMaterial.bounciness = gameSettings.bounciness;

			physicsMaterial.frictionCombine = gameSettings.frictionCombine;
			physicsMaterial.bounceCombine = gameSettings.bouncinessCombine;

			col=GetComponent<Collider>();
			col.material = physicsMaterial;

			meshRenderer = GetComponent<MeshRenderer>();	
		}

		private void OnDisable()
		{
			isInactive = false;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (isInactive)
				return;

			if (other.gameObject.layer == LayerMask.NameToLayer(Constants.CUP_LAYER))
			{
				isInactive = true;
				BusSystem.CallBallEnterCup();
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (isInactive)
				return;

			if (collision.gameObject.layer == LayerMask.NameToLayer(Constants.GROUND_LAYER))
			{
				isInactive = true;
				BusSystem.CallBallLost();
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

