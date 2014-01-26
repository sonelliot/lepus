using UnityEngine;
using System.Collections;

public class GameMusicManager : MonoBehaviour
{
    private static GameMusicManager instance = null;
    public static GameMusicManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    public float VolumeMultiplier = 1f;
    public AudioClip[] music;

	protected AudioClip _currentlyPlaying;
	protected AudioClip _nextPlaying;
	protected GameController gameController;

    void Start()
    {
		audio.loop = true;
		var gameControllerObject = GameObject.Find ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();

		if(Network.isServer)
		{
			_currentlyPlaying = music[0];
		}
		else
		{
			_currentlyPlaying = music[3];
		}
		audio.clip = _currentlyPlaying;
		audio.Play();
    }

	private void UpdateAudio(int i)
	{
		_currentlyPlaying = music[i];
		audio.loop = false;
	}

	void Update()
	{
		if(!audio.isPlaying)
		{
			audio.clip = _currentlyPlaying;
			audio.Play();
		}

		if(gameController.timeRemaining >= 20)
		{
			if(Network.isServer)
			{
				if(_currentlyPlaying != music[0])
					UpdateAudio(0);
			}
			else if(_currentlyPlaying != music[3])
			{
				UpdateAudio(3);
			} 
		}
		else if(gameController.timeRemaining < 20 &&
		        gameController.timeRemaining >= 10)
		{
			if(Network.isServer)
			{
				if(_currentlyPlaying != music[1])
					UpdateAudio(1);
			}
			else if(_currentlyPlaying != music[4])
			{
				UpdateAudio(4);
			}
		}
		else if(gameController.timeRemaining < 10)
		{
			if(Network.isServer)
			{
				if(_currentlyPlaying != music[2])
					UpdateAudio(2);
			}
			else if(_currentlyPlaying != music[5])
			{
				UpdateAudio(5);
			}
		}
	}
}
