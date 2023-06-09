using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ball : MonoBehaviour
{
	public Rigidbody2D rb;
	public Rigidbody2D hook;

	public float releaseTime = .5f;
	public float maxDragDistance = 2f;

	public GameObject nextBall;

	private bool isPressed = false;

	public AudioClip jump;

	public AudioClip CollectSound;
	
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (isPressed)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			if (Vector3.Distance(mousePos, hook.position) > maxDragDistance) { 
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
				

			}
			else
				rb.position = mousePos;


             
		}
		
	}

	void OnMouseDown()
	{
		isPressed = true;
		rb.isKinematic = true;

		GetComponent<AudioSource>().PlayOneShot(jump);
	}

	void OnMouseUp()
	{
		isPressed = false;
		rb.isKinematic = false;

		StartCoroutine(Release());
	}

	IEnumerator Release()
	{
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;

		yield return new WaitForSeconds(2f);

		if (nextBall != null)
		{
			nextBall.SetActive(true);
			
		}
		else
		{
			Enemy.EnemiesAlive = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			
		}
		GetComponent<AudioSource>().PlayOneShot(CollectSound);
	}

}




