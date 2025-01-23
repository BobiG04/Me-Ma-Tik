using UnityEngine;

public class CardOutline : MonoBehaviour
{

	[SerializeField] GameManager gameManagerScript;
	Vector3 SlotPos;
	Quaternion SlotRot;
	[SerializeField] int SlotIndex = 0;
	[SerializeField] CardDetails cardDetailsScript;
	[SerializeField] GameObject cardOutlineGO;

	public void OnMouseOver()
	{
		if (gameManagerScript.CurrentPhase == Phase.PlayPhase)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				//Debug.Log("Pressed");

				if (gameManagerScript.CurrentSelectedCard != null)
				{

					SlotPos = gameManagerScript.CardSlot[SlotIndex].transform.position;
					SlotRot = Quaternion.Euler(0, 90, 0);

				} else
				{
					Debug.Log("Tuka nieshto nqma karta.");
					gameManagerScript.CurrentSelectedCard = gameManagerScript.Empty;
				}
			}

		}
		// Check the card itself that is selected.
		// Put on the field

	}

	void OnMouseUp()
	{
		cardDetailsScript = gameManagerScript.CurrentSelectedCard.GetComponent<CardDetails>();

		Debug.Log("UnPressed");
		if (gameManagerScript.CurrentPhase == Phase.PlayPhase)
		{

			cardDetailsScript.UnSelectCard();

			cardDetailsScript.enabled = false;
			gameManagerScript.CurrentSelectedCard.transform.SetParent(null);
			gameManagerScript.CurrentSelectedCard.transform.position = SlotPos;
			gameManagerScript.CurrentSelectedCard.transform.rotation = SlotRot;
			gameManagerScript.CurrentSelectedCard = null;

			cardOutlineGO.SetActive(false);


		}
	}

}