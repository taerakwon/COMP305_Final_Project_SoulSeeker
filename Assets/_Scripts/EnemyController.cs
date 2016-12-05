/* Game Title: Soul Seeker
 * File: EnemyController.cs
 * Students: Taera Kwon (300755802), Ali Saim (300759480)
 * Date Created: 2016-11-23
 * Date Last Modified: 2016-11-23
 * Last Modified By: Ali Saim
 * Description: Game controller class for Soul Seeker
 * Revision History:
 *  Nov 23, 2016:
 * 					Created Enemy Controller Class
 * 	
 */

using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public UnityEngine.AI.NavMeshAgent Agent;


	//PRIVATE INSTANCE VARIABLES
	private Transform Player;

	// Use this for initialization
	void Start () {
		this.Player = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		this.Agent.SetDestination (this.Player.position);
	}
}
