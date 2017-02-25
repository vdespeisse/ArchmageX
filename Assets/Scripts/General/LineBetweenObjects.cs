using UnityEngine;
using System.Collections;

public class LineBetweenObjects : MonoBehaviour
{
	public LineRenderer lineRenderer;
	public Transform object1;
	public Transform object2;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		lineRenderer.SetPosition (0, object1.position);
		lineRenderer.SetPosition (1, object2.position);

	}
}

