using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    private Paddle paddle;
    private bool gameStarted;

    private Vector3 paddleToBallVector;

    private AudioSource[] sounds;
    private AudioClip metalClang;
	// Use this for initialization
	void Start ()
	{
	    paddle = FindObjectOfType<Paddle>();
	    paddleToBallVector = transform.position - paddle.transform.position;
	    sounds = GetComponents<AudioSource>();
	    metalClang = sounds[1].clip;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(!gameStarted)
	        transform.position = paddle.transform.position + paddleToBallVector;

	    if (Input.GetMouseButtonDown(0))
	    {
	        GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
	        gameStarted = true;
	    }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        GetComponent<Rigidbody2D>().velocity += tweak;

        if (other.gameObject.CompareTag("Breakable"))
        {
            sounds[0].Play();
        }
        else if (other.gameObject.CompareTag("Unbreakable"))
        {
            sounds[1].PlayOneShot(metalClang, 0.3f);
        }
    }
}
