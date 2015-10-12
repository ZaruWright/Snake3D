using UnityEngine;
using System.Collections.Generic;

public class DefaultOptions : MonoBehaviour {

    public static Dictionary<Direction, Vector3> defaultVelocities;

	// Use this for initialization
	void Start () {
        defaultVelocities = new Dictionary<Direction, Vector3>();
        defaultVelocities.Add(Direction.Up, new Vector3(0f, 1f, 0f));
        defaultVelocities.Add(Direction.Down, new Vector3(0f, -1f, 0f));
        defaultVelocities.Add(Direction.Left, new Vector3(-1f, 0f, 0f));
        defaultVelocities.Add(Direction.Right, new Vector3(1f, 0f, 0f));
        defaultVelocities.Add(Direction.Ahead, new Vector3(0f, 0f, -1f));
        defaultVelocities.Add(Direction.Behind, new Vector3(0f, 0f, 1f));
	}
}
