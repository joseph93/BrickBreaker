using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    private LevelManager levelManager;
	// Use this for initialization
	void Start ()
	{
	    levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Ball"))
        {
            levelManager.loadLevel("Game_Over");
        }
            
    }
}
