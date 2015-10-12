using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour {

    public int velocity;
    public float followTime;
	public int defaultBodyParts;
	public GameObject bodyPartPrefab;
	public float amountTime;

	private Direction defaultDirection;
    public List<GameObject> body;
    public static Snake s_snake;

	// Use this for initialization
	void Start () {
        s_snake = this;
		defaultDirection = Direction.Left;
		body = new List<GameObject> ();
		for (int i = 0; i < defaultBodyParts; ++i) {
			createPart(i, defaultDirection, new Vector3(i,0,0));
		}
	}

	/*void OnTriggerStay(){
		Debug.Log ("Snake Stay");
	}*/

    void OnTriggerEnter(Collider col)
    {
		Debug.Log ("Snake Enter");
		Destroy (col.gameObject);
		int newIndex = body.Count;
		BodyPart lastPart = body [newIndex - 1].GetComponent<BodyPart> ();
		Debug.Log (lastPart.transform.position);
		Debug.Log (lastPart.currentDirection);
		Debug.Log (lastPart.transform.position - DefaultOptions.defaultVelocities[lastPart.currentDirection]);
		createPart (newIndex, 
		            lastPart.currentDirection,
		            lastPart.transform.position - DefaultOptions.defaultVelocities[lastPart.currentDirection]);
    }

	/*void OnTriggerExit(Collider col)
	{
		Debug.Log ("Snake Exit");

	}*/

	void FixedUpdate(){
		// Increase the global time for the movement of the snake.
		amountTime += Time.fixedDeltaTime;
	}

    void Update() {
		// Update the body
		if (amountTime >= followTime){
			for (int i = body.Count; i > 1; --i){
				body[i - 1].GetComponent<BodyPart>().currentDirection = body[i - 2].GetComponent<BodyPart>().currentDirection;
				body[i - 1].GetComponent<BodyPart>().updated = false;

			}
			amountTime = 0;
		}

		Direction currentHeadDirection = body [0].GetComponent<BodyPart> ().currentDirection;
		body[0].GetComponent<BodyPart>().updated = false;
        //Update the head
        if (Input.GetKey(KeyCode.W) && currentHeadDirection != Direction.Down)
        {
            body[0].GetComponent<BodyPart>().currentDirection = Direction.Up;
        }
		else if (Input.GetKey(KeyCode.A) && currentHeadDirection != Direction.Right)
        {
			body[0].GetComponent<BodyPart>().currentDirection = Direction.Left;
        }
		else if (Input.GetKey(KeyCode.S) && currentHeadDirection != Direction.Up)
        {
			body[0].GetComponent<BodyPart>().currentDirection = Direction.Down;
        }
		else if (Input.GetKey(KeyCode.D) && currentHeadDirection != Direction.Left)
        {
			body[0].GetComponent<BodyPart>().currentDirection = Direction.Right;
        }
		else if (Input.GetKey(KeyCode.Q) && currentHeadDirection != Direction.Ahead)
        {
			body[0].GetComponent<BodyPart>().currentDirection = Direction.Behind;
        }
		else if (Input.GetKey(KeyCode.E) && currentHeadDirection != Direction.Behind)
        {
			body[0].GetComponent<BodyPart>().currentDirection = Direction.Ahead;
        }
    }

	void createPart(int index, Direction dir, Vector3 position){
		GameObject go = (GameObject) Instantiate(bodyPartPrefab, position, Quaternion.identity);
		go.transform.parent = transform;
		go.GetComponent<BodyPart>().currentDirection = dir;
		go.GetComponent<BodyPart>().idPart = index;
		go.GetComponent<BodyPart>().updated = false;
		body.Add(go);
	}
}
