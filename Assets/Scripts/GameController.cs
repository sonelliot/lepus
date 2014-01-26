using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{		

		public enum GameState
		{
				WAITING_FOR_PLAYER,
				COUNT_DOWN,
				PLAYING,
				CHASER_WON,
				CHASEE_WON
		}
		;
		
		public float countDownTimer = 3.0f;
		public float timeRemaining = 30;
		public GameState state = GameState.WAITING_FOR_PLAYER;

		public bool InputEnabled {
				get {
						return state == GameState.PLAYING || state == GameState.WAITING_FOR_PLAYER;
				}
		}
	
		// Use this for initialization
		void Start ()
		{
				timeRemaining = 30;
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
						}
						if (state == GameState.PLAYING) {
								timeRemaining -= Time.deltaTime;

								if (timeRemaining < 0) {
										GameEnd ();
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
						if (Network.connections.Length >= 1) {
								GameBegin ();
						}
				}
		}

		public void GameBegin ()
		{
				state = GameState.COUNT_DOWN;
				networkView.RPC ("OnGameHasBegun", RPCMode.AllBuffered);
		}

		[RPC]
		public void OnGameHasBegun ()
		{

		}

		public void GameEnd ()
		{
				state = GameState.CHASEE_WON;
				networkView.RPC ("OnGameHasEnded", RPCMode.AllBuffered);
		}

	
		[RPC]
		public void OnGameHasEnded ()
		{

		}


		void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info)
		{
				int gameState = (int)state;

				stream.Serialize (ref timeRemaining);
				stream.Serialize (ref gameState);

				state = (GameState)gameState;
		}
}
