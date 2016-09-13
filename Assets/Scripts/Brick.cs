using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    private int timesHit;
    private LevelManager levelManager;
    public Sprite[] HitSprites;
    public static int breakableCount;
    private bool isBreakable;

    public AudioClip glassBreak;
    public GameObject smoke;

    // Use this for initialization
    void Start ()
	{
	    timesHit = 0;
        isBreakable = tag == "Breakable";

        if (isBreakable)
        {
            breakableCount++;
        }
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if(isBreakable)
                HandleHits();
        }
    }

    public void HandleHits()
    {
        timesHit++;
        int maxHits = HitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.bricksDestroyed();
            AudioSource.PlayClipAtPoint(glassBreak, transform.position, 0.5f);
            puffSmoke();
            Destroy(gameObject);
            
        }
        else
        {
            LoadSprites();
        }
    }

    public void puffSmoke()
    {
        GameObject puff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        if (puff != null) puff.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
    }

    public void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (HitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("There are no sprites to load.");
        }
    }
}
