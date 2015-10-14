using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	private Vector3 center;
	private Vector3 pole;
	private float radius;
    private GameObject sphere;
    public float rotationVelocity;

	public GameObject objectToRotateAround;

	// Use this for initialization
	void Start () {
		center = objectToRotateAround.transform.position;
		pole = transform.position;
		radius = Mathf.Sqrt( 
					Mathf.Pow (pole.x - center.x, 2) + 
					Mathf.Pow (pole.y - center.y, 2) + 
					Mathf.Pow (pole.z - center.z, 2));
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.name = "RotateAround";
        sphere.transform.position = center;
        sphere.GetComponent<SphereCollider>().radius = radius;
        Destroy(sphere.GetComponent<MeshRenderer>());
        transform.parent = sphere.transform;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.UpArrow)){
            sphere.transform.Rotate(new Vector3(1f,0f,0f) * Time.deltaTime * rotationVelocity);
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
            sphere.transform.Rotate(new Vector3(-1f, 0f, 0f) * Time.deltaTime * rotationVelocity);
        }
		else if (Input.GetKey(KeyCode.LeftArrow)){
            sphere.transform.Rotate(new Vector3(0f, 1f, 0f) * Time.deltaTime * rotationVelocity);
        }
		else if (Input.GetKey(KeyCode.RightArrow)){
            sphere.transform.Rotate(new Vector3(0f, -1f, 0f) * Time.deltaTime * rotationVelocity);
        }
	}
}
