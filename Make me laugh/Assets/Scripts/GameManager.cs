using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] float Spacing = 0.065f;

	#region Veriables

	[SerializeField] Animator DeckAnimator;
	public int CurrentPhaseIndex = 0;

	Phase[] phases = new Phase[] { Phase.DrawPhase, Phase.PlayPhase, Phase.AttackPhase, Phase.EndPhase };

	int TotalDMG;

	public Phase CurrentPhase
	{
		get { return phases[CurrentPhaseIndex]; }
	}

	public CoinFlip CoinFlipScript;

	public GameObject CurrentSelectedCard;
	public GameObject[] CardSlot;
	public GameObject Empty;

	[SerializeField] int DobbyProbab;

	[SerializeField] CardList CardListScript;
	[SerializeField] GameObject PlaceholderShowCard;
	[SerializeField] GameObject Inventory;
	[SerializeField] CardDetails cardDetailsScript;

	[SerializeField] Animator ShowCardAnim;

	//[SerializeField] Animator CamAnim;

	int Probability;
	#endregion

	// Draw Phase

	private void Awake()
	{
		DobbyProbab = Random.Range(0, 1000000);
	}

	private void Start()
	{
		StartCoroutine(FlipTheCoin());

		StartCoroutine(BeginDraw());
	}

	IEnumerator BeginDraw()
	{
		yield return new WaitForSeconds(10f);

		StartCoroutine(DrawCoroutine(false));

		for (int i = 0; i < 4; i++)
        {
			yield return new WaitForSeconds(5f);

			StartCoroutine(DrawCoroutine(false));
		}

		NextPhase();
    }

	IEnumerator FlipTheCoin()
	{
		yield return new WaitForSeconds(10f);

		Debug.Log("Coin is flip");

		StartCoroutine(CoinFlipScript.CoinIsFlip());
	}

	public void DrawCard()
    {

        Debug.Log("DrawingCard");

        StartCoroutine(DrawCoroutine(true));

    }

    IEnumerator DrawCoroutine(bool nextPhase)
	{
		DeckAnimator.SetTrigger("DrawCard");

		yield return new WaitForSeconds(1f);

		DeckAnimator.SetTrigger("ReturnState");
		Probability = GetProbability();

		if (Probability == 31)
		{
			if (DobbyProbab >= 999989)
			{
				// Spawn Dobby Card
				Debug.Log("Dobby card!");
			}
		}
		else if (Probability < 31)
		{

			StartCoroutine(InitialThrow());

		}

		if (nextPhase)
			NextPhase();

		Debug.Log(CurrentPhase);

		// "Show" Generate the card
		// Activate card trigger
	}

	private int GetProbability()
	{

		// show card at random

		return Random.Range(0, CardListScript.Cards.Length);
	}

	IEnumerator InitialThrow()
	{

		ShowCardAnim.SetTrigger("ShowCard");

		var previewCard = Instantiate(CardListScript.Cards[Probability], PlaceholderShowCard.transform);
		cardDetailsScript = previewCard.GetComponent<CardDetails>();
		cardDetailsScript.enabled = false;

		yield return new WaitForSeconds(3f);

	

		ShowCardAnim.SetTrigger("HideCard");

		var NewCard = Instantiate(CardListScript.Cards[Probability], Inventory.transform);
		CardDetails CardScript = CardListScript.Cards[Probability].GetComponent<CardDetails>();
		CardScript.gameManagerScript = this;

		float offcet = Inventory.GetComponentsInChildren<CardDetails>().Length;
		offcet *= Spacing;

		NewCard.transform.Translate(offcet,0,0);

		Destroy(previewCard);
	}

	public void NextPhase()
	{
		CurrentPhaseIndex = (CurrentPhaseIndex + 1) % phases.Length;
	}

	public void ATKPhase ()
	{
        // Get the cards that are on the field.

        

    }

	// End Phase

	// AI Phase
	// Make Cam look at AI

}