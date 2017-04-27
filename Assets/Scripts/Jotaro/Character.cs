using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	private SpriteRenderer mySpriteRenderer;

	private float oraStart = 0f;
	private float oraCD = 1f;


	public Animator ani { get; private set;}

	[SerializeField]
	protected float speed;


	protected bool facingRight;

	protected bool paredT;

	public bool ora { get; set;}

	// Use this for initialization

	[SerializeField]
	protected GameObject starPre;

	public virtual void Start () {

		mySpriteRenderer = GetComponent<SpriteRenderer>();
		facingRight = !mySpriteRenderer.flipX;
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}









	public void ChangeDirc() {
        facingRight = !facingRight;

		transform.localScale = new Vector3 (transform.localScale.x *-1,5,1);
        
    }

	public virtual void Lanzar(int value)
	{
		oraCD -= Time.deltaTime;

		if(Time.time > oraStart + oraCD){
		if (facingRight) {

			GameObject tmp = (GameObject)Instantiate(starPre, transform.position, Quaternion.identity);
			tmp.GetComponent<StarP> ().Initialize (Vector2.right);



		} else {

			GameObject tmp = (GameObject)Instantiate(starPre, transform.position, Quaternion.Euler(new Vector3(0,180,0)));
			tmp.GetComponent<StarP> ().Initialize (Vector2.left);
			}
			oraStart = Time.time;
		}
	}
}
