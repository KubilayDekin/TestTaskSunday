using Assets._myAssets.Scripts.Engine;
using Assets._myAssets.Scripts.LevelDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay.Elements
{
	public class Ball : MonoBehaviour
	{
		public GameSettings gameSettings;

		private Collider col;
		private Rigidbody rb;
		private MeshRenderer meshRenderer;
		private bool isInactive;

		private void Awake()
		{
			rb = GetComponent<Rigidbody>();
			col = GetComponent<Collider>();

			SetDefaultBallPhysics();

			meshRenderer = GetComponent<MeshRenderer>();	
		}

		private void OnEnable()
		{
			StartCoroutine(HandleOnEnable());
		}

		private void OnDisable()
		{
			SetDefaultBallPhysics();
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
				SetInCupBallPhysics();
				transform.parent = null;
			}
		}

		public void SetBallColor(Color ballColor)
		{
			meshRenderer.material.color = ballColor;
		}

		private IEnumerator HandleOnEnable()
		{
			rb.drag = 50;

			yield return new WaitForSeconds(0.1f);

			rb.drag = 0.05f;
		}

		private void SetDefaultBallPhysics()
		{
			PhysicMaterial physicsMaterial = new PhysicMaterial();

			float staticFriction = 1 - gameSettings.ballSlipperiness;
			float dynamicFriction = 1 - gameSettings.ballSlipperiness;
			float bouncieness = gameSettings.ballBounciness;
			PhysicMaterialCombine frictionCombine;
			PhysicMaterialCombine bouncinessCombine;

			if (gameSettings.ballSlipperiness < 0.25f)
			{
				frictionCombine = PhysicMaterialCombine.Maximum;
			}
			else if (gameSettings.ballSlipperiness>=0.25f && gameSettings.ballSlipperiness < 0.75f)
			{
				frictionCombine = PhysicMaterialCombine.Average;
			}
			else
			{
				frictionCombine = PhysicMaterialCombine.Minimum;
			}

			if (gameSettings.ballBounciness < 0.25f)
			{
				bouncinessCombine = PhysicMaterialCombine.Minimum;
			}
			else if (gameSettings.ballBounciness >= 0.25f && gameSettings.ballBounciness < 0.75f)
			{
				bouncinessCombine = PhysicMaterialCombine.Average;
			}
			else
			{
				bouncinessCombine = PhysicMaterialCombine.Maximum;
			}

			physicsMaterial.staticFriction = staticFriction;
			physicsMaterial.dynamicFriction = dynamicFriction;
			physicsMaterial.bounciness = bouncieness;

			physicsMaterial.frictionCombine = frictionCombine;
			physicsMaterial.bounceCombine = bouncinessCombine;

			col.material = physicsMaterial;
		}

		private void SetInCupBallPhysics()
		{
			PhysicMaterial physicsMaterial = new PhysicMaterial();

			physicsMaterial.staticFriction = 0.25f;
			physicsMaterial.dynamicFriction = 0.25f;
			physicsMaterial.bounciness = 0;

			physicsMaterial.frictionCombine = PhysicMaterialCombine.Maximum;
			physicsMaterial.bounceCombine = PhysicMaterialCombine.Minimum;

			col.material = physicsMaterial;
		}
	}
}

