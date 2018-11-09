using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour {

	public Animator animator;



	// Update is called once per frame
	void Update () {
		 
	}

	public void FadeToEnd (){

		animator.SetTrigger ("endGame");

	}

	public void onFadeComplete(){
		SceneManager.LoadScene("a-fork-in-the-road");
	}
}
