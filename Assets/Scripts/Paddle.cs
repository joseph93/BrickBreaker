using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    public bool autoPlay = false;
    private Ball ball;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (!autoPlay)
	        moveWithMouse();

	    else
	        AutoPlay();
	}

    public void moveWithMouse()
    {
        float mousePosInBlocks = Input.mousePosition.x/Screen.width*16;

        Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        transform.position = paddlePos;
    }

    public void AutoPlay()
    {

        Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
        transform.position = paddlePos;
    }
}
