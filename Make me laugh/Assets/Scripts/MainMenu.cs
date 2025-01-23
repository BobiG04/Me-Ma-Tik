using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator MMAnim;
	[SerializeField] Animator ChovecheAnim;

	public void QuitApp()
    {
        Application.Quit();

        Debug.Log("Quitted!");
    }

    public void LoadNextScene()
    {
        StartCoroutine(WaitForWalk());
    }

    IEnumerator WaitForWalk ()
    {

        MMAnim.SetTrigger("Hidemenu");
        ChovecheAnim.SetTrigger("StartWalk");

        yield return new WaitForSeconds(7.5f);

        SceneManager.LoadSceneAsync(1);

    }
}
