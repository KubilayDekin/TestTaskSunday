using Assets._myAssets.Scripts.LevelDesign;
using UnityEngine;

public class TubeSwipeController : MonoBehaviour
{
	public GameSettings gameSettings;

	private float previousAngle;
	private float rotationSpeed;
	private bool isFirstClick;

	private void Start()
	{
		rotationSpeed = gameSettings.tubeRotationSpeed;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			isFirstClick = true;
		}

		if (Input.GetMouseButton(0))
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = -Camera.main.transform.position.z; // Convert to World coordinates
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

			Vector3 direction = worldPosition - transform.position;
			float currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			if (currentAngle < 0f)
			{
				currentAngle += 360f;
			}

			float deltaAngle = currentAngle - previousAngle;
			if (deltaAngle < 0f)
			{
				deltaAngle += 360f;
			}

			previousAngle = currentAngle;

			if (isFirstClick)
			{
				isFirstClick = false;
				return;
			}

			if (deltaAngle != 0)
			{
				transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * (deltaAngle > 180 ? -(360 - deltaAngle) : deltaAngle));
			}
		}
	}
}
