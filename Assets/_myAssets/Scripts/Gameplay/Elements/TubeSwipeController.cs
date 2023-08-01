using Assets._myAssets.Scripts.LevelDesign;
using UnityEngine;

namespace Assets._myAssets.Scripts.Gameplay.Elements
{
	public class TubeSwipeController : MonoBehaviour
	{
		public GameSettings gameSettings;

		private Vector3 lastMousePosition;
		private bool isDragging = false;

		void Update()
		{
#if !UNITY_EDITOR
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);

				if (touch.phase == TouchPhase.Began)
				{
					lastMousePosition = touch.position;
					isDragging = true;
				}
				else if (touch.phase == TouchPhase.Moved)
				{
					float rotationValue = (touch.position.x - lastMousePosition.x) * gameSettings.tubeRotationSpeed * Time.deltaTime;
					RotateObject(rotationValue);
					lastMousePosition = touch.position;
				}
				else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
				{
					isDragging = false;
				}
			}

#else
			if (Input.GetMouseButtonDown(0))
			{
				lastMousePosition = Input.mousePosition;
				isDragging = true;
			}
			else if (Input.GetMouseButton(0) && isDragging)
			{
				float rotationValue = (Input.mousePosition.x - lastMousePosition.x) * gameSettings.tubeRotationSpeed * Time.deltaTime;
				RotateObject(rotationValue);
				lastMousePosition = Input.mousePosition;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				isDragging = false;
			}
#endif
		}

		private void RotateObject(float rotationValue)
		{
			rotationValue = rotationValue >= 25 ? 25 : rotationValue;
			rotationValue = rotationValue <= -25 ? -25 : rotationValue;

			transform.Rotate(Vector3.forward, rotationValue, Space.World);
		}
	}
}