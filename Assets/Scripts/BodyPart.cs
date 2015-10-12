using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {

	public Direction currentDirection;
	public int idPart;
	public bool updated;
	private Vector3 v3;


	// Use this for initialization
	void Start () {
		v3 = DefaultOptions.defaultVelocities[currentDirection];
		updated = false;
	}
	
	// Move a part of the snake
	void FixedUpdate () {
		if (Snake.s_snake.amountTime >= Snake.s_snake.followTime && !updated){	
			v3 = DefaultOptions.defaultVelocities[currentDirection];
			transform.Translate(v3);
			updated = true;
		}
	}
}
