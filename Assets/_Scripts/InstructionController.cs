/* Game Title: Soul Seeker
 * File: InstructionController.cs
 * Students: Taera Kwon (300755802), Ali Saim (300759480)
 * Date Created: 2016-11-23
 * Date Last Modified: 2016-11-23
 * Last Modified By: Taera Kwon
 * Description: Instruction class for Soul Seeker
 * Revision History:
 *  Nov 23, 2016:
 * 					Added Play and MainMenu methods
 * 					Created
 * 	
 */
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionController : MonoBehaviour {
	// PUBLIC INSTANCES
	[Header("Buttons")]
	public Button PlayButton;
	public Button MainMenuButton;

	// Play Game
	public void Play()
	{
		SceneManager.LoadScene ("Main");
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

}
