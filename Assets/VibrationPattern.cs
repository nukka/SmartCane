
using UnityEngine;
using System.Collections;
using Rewired;

[RequireComponent(typeof(CharacterController))]
public class VibrationPattern : MonoBehaviour {

	public int playerId = 0; // The Rewired player id of this character

	public float moveSpeed = 3.0f;
	public float bulletSpeed = 15.0f;
	public GameObject bulletPrefab;

	private Player player; // The Rewired Player
	private CharacterController cc;
	private Vector3 moveVector;


	void Awake() {
		// Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
		player = ReInput.players.GetPlayer(playerId);


	}

	public void Vibrate(int motorIndex, float motorLevel, float duration){
		player.SetVibration(motorIndex, motorLevel, duration);

	}
}