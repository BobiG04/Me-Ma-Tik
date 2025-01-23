using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckOnClick : MonoBehaviour
{

    [SerializeField] GameManager gameManagerScript;

    void OnMouseOver()
    {
        if (gameManagerScript.CurrentPhase == Phase.DrawPhase)
        {
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				gameManagerScript.DrawCard();
			}
		} else
        {
            // Debug.Log("The card is already drawn.");
        }
        
    }

}
