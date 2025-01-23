using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlip : MonoBehaviour
{
    
    // Heads - true; Tails - false;
    public bool HeadsOrTails;
    public GameObject TheCoinItself;
	[SerializeField] Rigidbody CoinRigidbody;

	public IEnumerator CoinIsFlip()
	{
		CoinRigidbody.AddForce(0f, 500f, 0f);

		yield return new WaitForSeconds(1f);

		int RandChance;
		RandChance = Random.Range(0, 100);
		float XAxis, YAxis, ZAxis;

		if (RandChance > 99)
		{
			XAxis = Random.Range(25f, 150f);
			YAxis = -90f;
			ZAxis = -90f;
			TheCoinItself.transform.rotation = Quaternion.Euler(XAxis, YAxis, ZAxis);
			HeadsOrTails = false;
		}
		else if (RandChance <= 99)
		{
			XAxis = Random.Range(220f, 325f);
			YAxis = -90f;
			ZAxis = -90f;
			TheCoinItself.transform.rotation = Quaternion.Euler(XAxis, YAxis, ZAxis);
			HeadsOrTails = true;
		}

		yield return new WaitForSeconds(5f);

		CoinRigidbody.AddForce(200f, 0f, 0f);
	}

}
