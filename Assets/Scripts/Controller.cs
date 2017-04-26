using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {




	private static Controller instance;

	public static Controller Instance
	{
		get 
		{ 

			if (instance == null) {
			
				instance = GameObject.FindObjectOfType<Controller> ();

			}
			return instance;
		}



	}

	private Animator ani;


	[SerializeField]
	private float speed;
	//private bool ora;
	private bool facingRight;

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

	[SerializeField]
	private GameObject starPre;


	public Rigidbody2D myRB  { get; set;}

	public bool ora { get; set;}

	public bool Jump { get; set;}

	public bool OnGround { get; set;}





	void  Start (){

		facingRight = true;
		myRB = GetComponent<Rigidbody2D>();
		ani = GetComponent<Animator>();

	}

	void Update(){
	
		HandleInput ();
	
	}



	void  FixedUpdate (){

		float horizontal = Input.GetAxis("Horizontal");


		OnGround = IsGrounded();
		HandleMovement(horizontal);

		flip (horizontal);

		//HandleOraOra ();

		HandleLayers ();

		//resetValues ();

	}





	//metodo movimiento
	private void HandleMovement(float horizontal)
	{
		
		if (myRB.velocity.y < 0) {
			ani.SetBool ("land", true);

		}

		if (!this.ani.GetCurrentAnimatorStateInfo(0).IsTag("Ora") && (OnGround || airControl)) {
			myRB.velocity = new Vector2 (horizontal * speed, myRB.velocity.y);

		}

		if (Jump && myRB.velocity.y == 0){

			myRB.AddForce (new Vector2 (0, jumpForce));
		}

		ani.SetFloat ("speed", Mathf.Abs (horizontal));


		/*
		if (myRB.velocity.y < 0) {
			ani.SetBool ("land", true);
		}


		if (!this.ani.GetCurrentAnimatorStateInfo(0).IsTag("Ora") && (IsGrounded() || airControl))
			{

			myRB.velocity = new Vector2 (horizontal * speed, myRB.velocity.y);


			}

		if (IsGrounded() && jump)

		{
			isG = false; 
			myRB.AddForce(new Vector2 (0, jumpForce));
			ani.SetTrigger ("jump");



		}

		ani.SetFloat("speed",Mathf.Abs(horizontal));




			*/
	}
     

	//metodo pulsa botones
	private void HandleInput(){


		if (Input.GetKeyDown (KeyCode.LeftShift) && OnGround) {

			ani.SetTrigger ("Ora");
			//ora = true;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {

			ani.SetTrigger ("jump");

			//jump = true;
		}

		if (Input.GetKeyDown (KeyCode.L) && OnGround) {
		
			ani.SetTrigger("lanzar");
			lanzar(0);
		}

	} 


	//metodo ataque
	private void HandleOraOra(){

		if (ora && !this.ani.GetCurrentAnimatorStateInfo(0).IsTag("Ora") && OnGround) {
			ani.SetTrigger ("Ora");
			myRB.velocity = Vector2.zero;
		}
	}



	//metodo para girar
	private void flip(float horizontal){

		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight && (!this.ani.GetCurrentAnimatorStateInfo(0).IsTag("Ora"))) {

			facingRight = !facingRight;
			Vector3 SCALE = transform.localScale;

			SCALE.x *= -1;

			transform.localScale = SCALE;



		}
	}

	/*
	private void resetValues()
	{
		ora = false;
        jump = false;


	}
	*/

	private bool IsGrounded()
	{
		if (myRB.velocity.y <= 0) {

			foreach (Transform point in groundPoints) {

				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if(colliders[i].gameObject !=gameObject){

						//ani.ResetTrigger("jump");
						//ani.SetBool ("land", false);
						return true;

					}

				}

			}

		}
		return false;
	}

    private void HandleLayers() {

		if (!OnGround) {
			ani.SetLayerWeight (1, 1);

		} else {
			ani.SetLayerWeight(1,0);
		}

    }

	public void lanzar(int value){
        

        if (facingRight && OnGround) {
			
			GameObject tmp = (GameObject)Instantiate(starPre, transform.position, Quaternion.identity);
			tmp.GetComponent<StarP> ().Initialize (Vector2.right);


		} else if (!facingRight && OnGround) {
			
			GameObject tmp = (GameObject)Instantiate(starPre, transform.position, Quaternion.Euler(new Vector3(0,180,0)));
			tmp.GetComponent<StarP> ().Initialize (Vector2.left);
		}
	}

}
