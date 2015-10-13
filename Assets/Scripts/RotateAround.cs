using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	private Vector3 center;
	private Vector3 pole;
	private float radius;

	// 0 < theta < 2pi
	public float theta;
	// 0 < fi < pi
	public float fi;

	public GameObject objectToRotateAround;

	// Use this for initialization
	void Start () {
		center = objectToRotateAround.transform.position;
		pole = transform.position;
		Debug.Log (center);
		Debug.Log (pole);

		radius = Mathf.Sqrt( 
					Mathf.Pow (pole.x - center.x, 2) + 
					Mathf.Pow (pole.y - center.y, 2) + 
					Mathf.Pow (pole.z - center.z, 2));
		Debug.Log ("Center " + center);
		Debug.Log ("Pole" + pole);
		Debug.Log ("Radius" + radius);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 parametricEcuation = new Vector3(center.x + radius * Mathf.cos(theta) * Mathf.sin(fi),
												 center.y + radius * Mathf.sin(theta) * Mathf.sin(fi),
												 center.z + radius * Mathf.cos(fi));
		if (Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(DefaultsOptions.defaultVelocities[Direction.Up] + parametricEcuation);
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
			transform.Translate(DefaultsOptions.defaultVelocities[Direction.Down] + parametricEcuation);
		}
		else if (Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(DefaultsOptions.defaultVelocities[Direction.Left] + parametricEcuation);
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(DefaultsOptions.defaultVelocities[Direction.Right] + parametricEcuation);
		}
	}
}
