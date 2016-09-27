using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public bool grounded;
    public LayerMask ground;
    public float jumpTime;
    public Transform groundDetector;
    public float groundCheckRadius;
    public float speedMultiplier;
    public float speedIncreaseMilestone;



    private Rigidbody2D rigidBody;    
    private Animator animator;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    private float speedMilestoneCount;

    private float moveSpeedStore;
    private float speedMilestoneCountStore;
    private float speedIncreaseMilestoneStore;
    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();        
        animator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        stoppedJumping = true;
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundDetector.position, groundCheckRadius, ground);
        if (transform.position.x > speedMilestoneCount) {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !EventSystem.current.IsPointerOverGameObject()) {
            if (grounded) {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                stoppedJumping = false;
            }            
        }
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping) {
            if (jumpTimeCounter > 0) {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
        if (grounded) {
            jumpTimeCounter = jumpTime;
        }

        animator.SetFloat("Speed",rigidBody.velocity.x);
        animator.SetBool("Grounded", grounded);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "DeathZone") {            
            GameManager.instance.EndGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }
}
