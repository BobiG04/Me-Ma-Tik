using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDetails : MonoBehaviour
{

	public GameManager gameManagerScript;
	public GameObject GameManObj;

	[SerializeField] GameObject TheCard;
	[SerializeField] GameObject TheCardParent;
	[SerializeField] Material CardBorderMaterialAfter;
	[SerializeField] Material CardBorderMaterialBefore;

	[SerializeField] Animator CardAnim;

	public string CardDesc;

	[SerializeField] public bool isSelected = false;

	public int CardATK;
	public int CardHealth;
	public int CardHealing;
	public int CardATKBoost;
	public int CardTurnDur;

	void OnMouseOver()
	{

		GameManObj = GameObject.FindGameObjectWithTag("GameManager");

		gameManagerScript = GameManObj.GetComponent<GameManager>();

		if (gameManagerScript.CurrentPhase == Phase.PlayPhase)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (!isSelected)
				{
					SelectTheCard();
				}
				else
				{
					UnSelectCard();
				}
			} else if (Input.GetKeyDown(KeyCode.Mouse1))
			{

				// Show the description of the card on the UI

				// CardAnim.SetTrigger("ShowCardFromInv");

			}

		} else
		{
			//Debug.Log("Not Play Phase.");
		}

	}

	private void OnMouseExit()
	{
		CardAnim.SetTrigger("ReturnCardToInv");
	}

	public void SelectTheCard()
	{
		Renderer rend = TheCard.GetComponent<Renderer>();
		Material[] mats = rend.materials;
		mats[0] = CardBorderMaterialAfter;
		rend.materials = mats;
		isSelected = true;
		gameManagerScript.CurrentSelectedCard = TheCardParent;
	}

	public void UnSelectCard()
	{
		Renderer rend = TheCard.GetComponent<Renderer>();
		Material[] mats = rend.materials;
		mats[0] = CardBorderMaterialBefore;
		rend.materials = mats;
		isSelected = false;
	}
}