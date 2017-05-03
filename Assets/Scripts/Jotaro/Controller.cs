using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public delegate void DeadEventHandle ();


public class Controller : Character
{




	private static Controller instance;

	public event DeadEventHandle Dead;

	public static Controller Instance {
		get { 

			if (instance == null) {
			
				instance = GameObject.FindObjectOfType<Controller> ();

			}
			return instance;
		}



	}





	//private bool ora;

	public Text healthTxt;

	public Text contadorVidas;

	[SerializeField]
	public int vidas;

	public Image DIE;

	public Image End;

	private SpriteRenderer spr;

	private bool inmortal = false;

	[SerializeField]
	private float inmortalTime;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	//private bool isG;
	//private bool jump;
	[SerializeField]
	private bool airControl;

	[SerializeField]
	private float jumpForce;

	private Vector3 startPos;







	public Rigidbody2D myRB  { get; set; }



	public bool Jump { get; set; }

	public bool OnGround { get; set; }





	public override void  Start ()
	{

		base.Start ();
		startPos = transform.position;
		myRB = GetComponent<Rigidbody2D> ();
		spr = GetComponent<SpriteRenderer> ();
		SetText ();
		

	}

	void Update ()
	{

		if (!TakingDamage && !IsDead) {
			HandleInput ();
		}
	
	}



	void  FixedUpdate ()
	{

		if (!TakingDamage && !IsDead) {
			float horizontal = Input.GetAxis ("Horizontal");


			OnGround = IsGrounded ();
			HandleMovement (horizontal);

			flip (horizontal);

			//HandleOraOra ();

			HandleLayers ();

			//resetValues ();
		}

	}

	private void HandleMovement (float horizontal)
	{
		
		if (myRB.velocity.y < 0) {
			ani.SetBool ("land", true);

		}

		if (!this.ani.GetCurrentAnimatorStateInfo (0).IsTag ("Ora") && (OnGround || airControl)) {
			myRB.velocity = new Vector2 (horizontal * speed, myRB.velocity.y);

		}

		if (Jump && myRB.velocity.y == 0) {

			myRB.AddForce (new Vector2 (0, jumpForce));
		}

		ani.SetFloat ("speed", Mathf.Abs (horizontal));



	}
     

	//metodo pulsa botones
	private void HandleInput ()
	{


		if (Input.GetKeyDown (KeyCode.LeftShift) && OnGround) {

			ani.SetTrigger ("Ora");
			//ora = true;
		}

		if (Input.GetKeyDown (KeyCode.Space) && OnGround) {

			ani.SetTrigger ("jump");

			//jump = true;
		}

		if (Input.GetKeyDown (KeyCode.L) && OnGround) {
		
			ani.SetTrigger ("lanzar");
			Lanzar (0);
		}

	}


	//metodo ataque
	private void HandleOraOra ()
	{

		if (ora && !this.ani.GetCurrentAnimatorStateInfo (0).IsTag ("Ora") && OnGround) {
			ani.SetTrigger ("Ora");
			myRB.velocity = Vector2.zero;
		}
	}



	//metodo para girar
	private void flip (float horizontal)
	{

		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight && (!this.ani.GetCurrentAnimatorStateInfo (0).IsTag ("Ora"))) {

			ChangeDirc ();



		}
	}



	private bool IsGrounded ()
	{
		if (myRB.velocity.y <= 0) {

			foreach (Transform point in groundPoints) {

				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {


						return true;

					}

				}

			}

		}
		return false;
	}

	private void HandleLayers ()
	{

		if (!OnGround) {
			ani.SetLayerWeight (1, 1);

		} else {
			ani.SetLayerWeight (1, 0);
		}

	}

	public override void Lanzar (int value)
	{
        


		if (!OnGround && value == 1 || OnGround && value == 0) {
			base.Lanzar (value);
		}


	}

	public override bool IsDead { 

		get { 

			if (health <= 0) {
				OnDead ();
			}
			return health <= 0;
		}


	}

	private IEnumerator IndicateInmortal ()
	{
	
		while (inmortal) {
		
			spr.enabled = false;
			yield return new WaitForSeconds (.1f);
			spr.enabled = true;
			yield return new WaitForSeconds (.1f);
		}
		
	}

	public override IEnumerator TakeDamege ()
	{


		if (!inmortal) {
			health -= 10;
			SetText ();

			if (!IsDead) {
			
				ani.SetTrigger ("hit");
				inmortal = true;
				StartCoroutine (IndicateInmortal ());
				yield return new WaitForSeconds (inmortalTime);

				inmortal = false;

			} else {
				ani.SetLayerWeight (1, 0);
				ani.SetTrigger ("muerto");

			}
		}
	}



	public override void Death ()
	{
		End.enabled = false;
		DIE.enabled = false;
		myRB.velocity = Vector2.zero;
		ani.SetTrigger ("idle");
		health = 100;
		transform.position = startPos;

		SetText ();


	}





	public void OnDead ()
	{
	
		if (Dead != null) {

			Dead ();
		}
	
	}

	void SetText ()
	{
	
		healthTxt.text = "Health: " + health.ToString ();
		contadorVidas.text = "Vidas: " + vidas.ToString ();
		if (health <= 0) {
			vidas = vidas - 1;
			DIE.enabled = true;

			if (vidas < 0) {

				DIE.enabled = false;
				End.enabled = true;

			}
			
		
		

		
		}
	
	}




}
