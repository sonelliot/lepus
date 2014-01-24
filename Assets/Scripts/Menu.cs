using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    private bool JoinServer = false;

    void OnGUI ()
    {


        // FIRST MENU: Create or join
        if (!JoinServer)
        {
            GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 110));
            GUI.Box (new Rect (0, 0, 200, 100), "LEPUS");

            // CREATE SERVER
            if (GUI.Button (new Rect (10, 25, 180, 30), "Create Server"))
            {
                NetworkManager.CreateServer ();
            }
            
            // JOIN SERVER
            if (GUI.Button (new Rect (10, 65, 180, 30), "Join Server"))
            {
                JoinServer = true;
            }
            GUI.EndGroup ();
        } else
        {
            // JOIN server menu
            var availableGames = NetworkManager.GetAvailableGames ();

            if (availableGames.Count > 0)
            {
                int boxHeight = 30 * availableGames.Count;
                GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 200, boxHeight + 20));
                GUI.Box (new Rect (0, 0, 200, boxHeight + 20), "");

                for (int gameNum = 0; gameNum < availableGames.Count; gameNum++)
                {
                    if (GUI.Button (new Rect (10, 10 + (30 * gameNum), 180, 30), availableGames [gameNum].gameName))
                    {
                        NetworkManager.JoinGame (availableGames [gameNum]);
                    }                     
                }
                GUI.EndGroup ();
            }
        }
    }
    void GoToGameScene ()
    {

    }
}
