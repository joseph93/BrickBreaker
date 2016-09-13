using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    private static SoundManager instance = null;

	// Use this for initialization
	void Awake () {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
	
	}

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
