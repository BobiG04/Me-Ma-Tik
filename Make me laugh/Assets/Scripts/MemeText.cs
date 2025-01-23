using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemeText : MonoBehaviour
{
    [SerializeField] string[] Memes;
	[SerializeField] TMP_Text Thememetext;

	private void Awake()
	{
		int RandNumb = Random.Range(0, Memes.Length);

		Thememetext.text = Memes[RandNumb];
	}
}
