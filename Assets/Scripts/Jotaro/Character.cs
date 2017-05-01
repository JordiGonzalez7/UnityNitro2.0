using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	private SpriteRenderer mySpriteRenderer;


	private float oraCD = 2f;
	private float timeStamp;

	[SerializeField]
	private List<string> damageSources;

	public Animator ani { get; private set;}

	[SerializeField]
	private BoxCollider2D swordCollider;

	[SerializeField]
	protected float speed;

	[SerializeField]
	protected int health;

	public abstract bool IsDead { get;}

	protected bool facingRight;

	protected bool paredT;

	public bool ora { get; set;}

	public bool TakingDamage { get; set;}

	// Use this for initialization

	[SerializeField]
	protected GameObject starPre;

	public BoxCollider2D SwordCollider
	{

		get{ 
			return swordCollider;
		}
	}

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
		


		if (timeStamp <= Time.time)
		{
			if (facingRight) {

				GameObject tmp = (GameObject)Instantiate(starPre, new Vector2(transform.position.x+2,transform.position.y), Quaternion.identity);
				tmp.GetComponent<StarP> ().Initialize (Vector2.right);



			} else {

				GameObject tmp = (GameObject)Instantiate(starPre, new Vector2(transform.position.x-2,transform.position.y), Quaternion.Euler(new Vector3(0,180,0)));
				tmp.GetComponent<StarP> ().Initialize (Vector2.left);
			}
			timeStamp = Time.time + oraCD;
		}



	}

	public void AttackMelee(){

		swordCollider.enabled = true;
	}


	public abstract IEnumerator TakeDamege ();

	public abstract void Death ();

	public virtual void OnTriggerEnter2D(Collider2D other){
	
		if (!IsDead) {

			if (damageSources.Contains(other.tag)) {

				StartCoroutine (TakeDamege ());

			}
		}
	}
}
