using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginATKPhase : MonoBehaviour
{

	[SerializeField] GameManager gameManagerScript;

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			gameManagerScript.NextPhase();
		}
	}

}
