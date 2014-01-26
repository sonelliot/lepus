using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Options : MonoBehaviour
{
    public bool showLevels = false;
    public bool disableCheckpoints = false;
    public float volume = 0.5f;

    private static Options instance = null;
    public static Options Instance
    {
        get { return instance; }
    }
        
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}