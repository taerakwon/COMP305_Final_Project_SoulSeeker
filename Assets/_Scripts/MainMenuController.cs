/* Game Title: Soul Seeker
 * File: MainMenuController.cs
 * Students: Taera Kwon (300755802), Ali Saim (300759480)
 * Date Created: 2016-11-23
 * Date Last Modified: 2016-11-23
 * Last Modified By: Taera Kwon
 * Description: Main Menu class for Soul Seeker
 * Revision History:
 *  Nov 23, 2016:
 * 					Added Background Music and methods for Play and Instruction buttons.
 * 					Created
 * 	
 */
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour{
	// PUBLIC INSTANCES
	[Header("Buttons")]
	public Button PlayButton;
	public Button InstructionButton;

	[Header("Background Music")]
	public AudioSource Background;

	// Use this for initialization
	void Start () {	
		this.Background.Play ();
	}

	// Play Game
	public void Play()
	{
		SceneManager.LoadScene ("Main");
	}

	public void Instruction()
	{
		SceneManager.LoadScene ("Instruction");
	}

}
