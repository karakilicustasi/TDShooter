using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    Vector2 bulletDirection;
	public float bulletSpeed;
	private Rigidbody2D rb;
	TargetScript target;
	Vector2 lastVelocity;
	bool playerHit;
	bool targetHit;
	public CameraShake camera;
	//GameManager game;
	// Start is called before the first frame update
	void Awake(){
		rb=GetComponent<Rigidbody2D>();
	}

	void Update(){
		lastVelocity = rb.velocity;
	}
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("Block")){
			var speed = lastVelocity.magnitude;
			var direction = Vector2.Reflect(lastVelocity.normalized,other.contacts[0].normal);
			
			rb.velocity = direction * bulletSpeed;
		}
		else if(other.gameObject.CompareTag(tag="Player")){
			playerHit=true;
			//game.EndGame();
			FindObjectOfType<GameManager>().EndGame();

		}
		else if(other.gameObject.CompareTag(tag="Target")){
			targetHit=true;
			var speed = lastVelocity.magnitude;
			var direction = Vector2.Reflect(lastVelocity.normalized,other.contacts[0].normal);

			rb.velocity = direction * bulletSpeed;
			target = other.gameObject.GetComponent<TargetScript>();
			target.Dead();


		}


	}
}
