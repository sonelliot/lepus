using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class GameController : MonoBehaviour
{		
		const float ROUND_LENGTH = 30.0f;
		const float COUNTDOWN_TIMER_LENGTH = 5.0f;
		const float ENDGAME_TIMER_LENGTH = 5.0f;

		public enum GameState
		{
				WAITING_FOR_PLAYER,
				COUNT_DOWN,
				PLAYING,
				CHASER_WON,
				CHASEE_WON
		}
		;
		
		public float countDownTimer = 0.0f;
		public float timeRemaining = 0.0f;

		public float gameEndTimer = 0.0f;

		public GameState state = GameState.WAITING_FOR_PLAYER;

		public int chaser_score = 0;
		public int chasee_score = 0;


		public bool InputEnabled {
				get {
						return state == GameState.PLAYING || state == GameState.WAITING_FOR_PLAYER;
				}
		}
	
		// Use this for initialization
		void Start ()
		{
				state = GameState.WAITING_FOR_PLAYER;
		}
	
		// Update is called once per frame
		void Update ()
		{
				// ONLY THE SERVER GETS TO DO THESE THINGS NO ONE ELSE JUST THE SERVER - ONLY THE SERVER
				if (Network.isServer) {
						if (state == GameState.COUNT_DOWN) {
								countDownTimer -= Time.deltaTime;

								if (countDownTimer < 0) {
										state = GameState.PLAYING;
								}
						} else if (state == GameState.PLAYING) {
								timeRemaining -= Time.deltaTime;

								if (timeRemaining < 0) {
										GameEnd ();
								}
						} else if (state == GameState.CHASEE_WON || state == GameState.CHASER_WON) {
								gameEndTimer -= Time.deltaTime;

								if (gameEndTimer < 0) {
										GameBegin ();
								}
						}
						
				}
		}

		public void NotifyJoined ()
		{
				networkView.RPC ("PlayerJoined", RPCMode.AllBuffered);
		}

		[RPC]
		public void PlayerJoined ()
		{
				if (Network.isServer) {
						// doesnt seem to include ourselveS?
						if (Network.connections.Length >= 1 && state == GameState.WAITING_FOR_PLAYER) {
								GameBegin ();
						}
				}

				// do stuff for all clients on player joined here
		}

		public void GameBegin ()
		{
				if (Network.isClient) {
						//throw new Exception ("OH SHIT game being called from client");
				}
				// TODO: Place players randomly

				state = GameState.COUNT_DOWN;
				timeRemaining = ROUND_LENGTH;
				countDownTimer = COUNTDOWN_TIMER_LENGTH;
				networkView.RPC ("OnGameHasBegun", RPCMode.AllBuffered);
		}

		[RPC]
		public void OnGameHasBegun ()
		{
				foreach (var projectile in FindObjectsOfType<GameObject>().Where(obj => obj.layer == LayerMask.NameToLayer("Bullets"))) {
						GameObject.Destroy (projectile);
				}

				RandomisePosition ();
		}

		public void GameEnd ()
		{
				if (Network.isClient) {
						throw new Exception ("OH SHIT game end called from client");
				}
				gameEndTimer = ENDGAME_TIMER_LENGTH;
				state = GameState.CHASEE_WON;
				networkView.RPC ("OnGameHasEnded", RPCMode.AllBuffered);
		}

	
		[RPC]
		public void OnGameHasEnded ()
		{

		}

		public void RandomisePosition ()
		{
				Transform playerTranny;
				if (GameProperties.Inst.Chasee) {
						playerTranny = GameObject.FindObjectOfType<UnitChasee> ().transform;
				} else {
						playerTranny = GameObject.FindObjectOfType<UnitChaser> ().transform;
				}

				playerTranny.position = new Vector3 (UnityEngine.Random.Range (-10.0f, 10.0f), UnityEngine.Random.Range (-10.0f, 10), playerTranny.position.z);
		}


		void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info)
		{
				int gameState = (int)state;

				stream.Serialize (ref timeRemaining);
				stream.Serialize (ref countDownTimer);
				stream.Serialize (ref gameEndTimer);
				stream.Serialize (ref gameState);

				state = (GameState)gameState;
		}
}
