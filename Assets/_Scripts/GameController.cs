/* Game Title: Soul Seeker
 * File: GameController.cs
 * Students: Taera Kwon (300755802), Ali Saim (300759480)
 * Date Created: 2016-11-22
 * Date Last Modified: 2016-11-23
 * Last Modified By: Taera Kwon
 * Description: Game controller class for Soul Seeker
 * Revision History:
 *  Nov 23, 2016:
 * 					Added panel to increase visibility when game finishes
 * 					Added end condition
 * 					Added Main menu handler; add/remove cross at start/end
 * 					Added Spawn Methods, Spawn Logics, and Audio Listener
 * 					Added Initialise method, endGame Method
 * 					Added Game Headers for Labels, Ghosts, Player
 *  Nov 22, 2016:	
 * 					Created Game Controller Class
 * 	
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	[Header("Player")]
	public GameObject Player;

	[Header("Cross")]
	public Image CrossImage;

	[Header("Ghosts")]
	public GameObject RedGhost;
	public GameObject BlueGhost;
	public GameObject OrangeGhost;
	public GameObject PinkGhost;

	[Header("UI Labels")]
	public Text LivesLabel;
	public Text SoulsCollectedLabel;
	public Text TotalSoulsCollected;
	public Text GameOverLabel;
	public Text WonLabel;

	[Header("UI Buttons")]
	public Button ReplayButton;
	public Button MainMenuButton;

	[Header("UI Panel")]
	public GameObject Panel;

	[Header("Game Sounds")]
	public AudioSource GameStartSound;

	// PRIVATE INSTANCE VARIABLES
	private int _playerLives;
	private int _soulsCollected;
	private float _spawnCounter;
	private bool _bRespawnGhosts;

	// Use this for initialization
	void Start () 
	{
		this._initialise ();
	}

	// Update is called once per frame
	void Update () 
	{		
		if (this._bRespawnGhosts == true) {
			this._spawnCounter += Time.deltaTime;
			if (this._spawnCounter >= 4f) {
				this.RespawnGhosts ();
			}
		}

		// Set Text
		this.LivesLabel.text = "TOTAL LIVES: " + this._playerLives;
		this.SoulsCollectedLabel.text = "SOULS COLLECTED: " + this._soulsCollected;

		// When you win the game
		if (this._soulsCollected == 80) {
			this._endGame ();
		}
	}

	// ACCESSORS
	public int PlayerLives
	{
		get
		{
			return this._playerLives;			
		}
		set 
		{
			this._playerLives = value;
			// If player lives = 0, end game
			if (this._playerLives <= 0) 
			{
				this._endGame ();
			}
		}
	}

	public float SpawnCounter
	{
		get
		{
			return this._spawnCounter;			
		}
		set 
		{
			this._spawnCounter = value;
		}
	}

	public int SoulsCollected
	{
		get
		{
			return this._soulsCollected;
		}
		set 
		{
			this._soulsCollected = value;
		}
	}

	public bool BRespawnGhosts
	{
		get
		{
			return this._bRespawnGhosts;
		}
		set 
		{
			this._bRespawnGhosts = value;
		}
	}

	// To Replay
	public void ReplayGame()
	{
		SceneManager.LoadScene ("Main");
	}

	// To go back to main menu
	public void BackToMain()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void HideGhosts()
	{
		// Hide Ghosts
		RedGhost.gameObject.SetActive (false);
		BlueGhost.gameObject.SetActive (false);
		PinkGhost.gameObject.SetActive (false);
		OrangeGhost.gameObject.SetActive (false);
	}


	//
	// PRIVATE METHODS
	//

	// INITIALISE
	private void _initialise()
	{
		// Hides Cursor
		Cursor.visible = false;
		// Hides Ghosts
		this.HideGhosts ();
		// Hide Labels and Buttons
		this.CrossImage.gameObject.SetActive(true);
		this.GameOverLabel.gameObject.SetActive (false);
		this.TotalSoulsCollected.gameObject.SetActive (false);
		this.ReplayButton.gameObject.SetActive (false);
		this.MainMenuButton.gameObject.SetActive (false);
		this.WonLabel.gameObject.SetActive (false);
		this.Panel.gameObject.SetActive (false);
		// Show Labels
		this.SoulsCollectedLabel.gameObject.SetActive(true);
		this.LivesLabel.gameObject.SetActive (true);

		// Initialise Values
		this._playerLives = 3;
		this._soulsCollected = 0;
		this._spawnCounter = 0f;

		// Spawn Player
		this.Spawn (Player);
		this._bRespawnGhosts = true;
		this.GameStartSound.Play();
	}

	// Respawns All Ghosts
	public void RespawnGhosts()
	{		
		this.RedGhost.gameObject.SetActive (true);
		this.BlueGhost.gameObject.SetActive (true);
		this.PinkGhost.gameObject.SetActive (true);
		this.OrangeGhost.gameObject.SetActive (true);
		this.Spawn (RedGhost);
		this.Spawn (BlueGhost);
		this.Spawn (OrangeGhost);
		this.Spawn (PinkGhost);
		this._bRespawnGhosts = false;
	}

	// SPAWN SELECTED OBJECT
	public void Spawn(GameObject SpawnObject)
	{
		if (SpawnObject == RedGhost) {
			RedGhost.transform.position = new Vector3 (-1.75f, 0f, 1.2f);
		}
		if (SpawnObject == BlueGhost) {
			BlueGhost.transform.position = new Vector3 (1.75f, 0f, 1.2f);
		}
		if (SpawnObject == OrangeGhost) {
			OrangeGhost.transform.position = new Vector3 (3.5f, 0f, 1.2f);
		}
		if (SpawnObject == PinkGhost) {
			PinkGhost.transform.position = new Vector3 (-3.5f, 0f, 1.2f);
		}
		if (SpawnObject == Player) {
			Player.transform.position = new Vector3 (0f, 0.5f, -3.5f);
		}
	}

	// End game method
	private void _endGame()
	{
		// Shows cursor
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		// Disable 
		this.Player.gameObject.SetActive (false);
		this.RedGhost.gameObject.SetActive (false);
		this.BlueGhost.gameObject.SetActive (false);
		this.PinkGhost.gameObject.SetActive (false);
		this.OrangeGhost.gameObject.SetActive (false);
		this.LivesLabel.gameObject.SetActive(false);
		this.SoulsCollectedLabel.gameObject.SetActive (false);
		this.CrossImage.gameObject.SetActive(false);

		// Activate
		this.Panel.gameObject.SetActive (true);
		this.TotalSoulsCollected.text = "Total Souls Collected: " + this._soulsCollected;
		this.TotalSoulsCollected.gameObject.SetActive(true);
		this.TotalSoulsCollected.gameObject.SetActive (true);
		this.ReplayButton.gameObject.SetActive (true);
		this.MainMenuButton.gameObject.SetActive (true);

		// When you win
		if (this._soulsCollected == 80) {
			this.WonLabel.gameObject.SetActive (true);
		} else {
			this.GameOverLabel.gameObject.SetActive (true);
		}
	}


}
