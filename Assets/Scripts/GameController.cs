using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{		
		public enum GameState
		{
				WAITING_FOR_PLAYER,
				PLAYING,
				CHASER_WON,
				CHASEE_WON
	}
		;

		public float timeRemaining = 30;
		public GameState state = GameState.WAITING_FOR_PLAYER;



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
						timeRemaining -= Time.deltaTime;

					
				}
		}

		[RPC]
		public void PlayerJoined ()
		{

		}

		[RPC]
		public void GameBegin ()
		{
		
		}
	
		[RPC]
		public void GameEnd ()
		{
		
		}

		void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info)
		{
				stream.Serialize (ref timeRemaining);
		}
}
