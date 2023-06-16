using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Mirror;

public class Character_Control : NetworkBehaviour {
    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;
    [SerializeField] float      scale = 2f;


    public int damage = 10;
    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = true;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        maxHealth = 100;
        currentHealth = maxHealth;
        // healthBar.SetMaxHealth(maxHealth);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public void SetCharacterId(int id) {
      // empty
      Debug.Log("Id " + id);
    }

	// Update is called once per frame
	void Update () {
        if (healthBar) {
          healthBar.SetMaxHealth(maxHealth);
          healthBar.SetHealth(currentHealth);
        }
        if (!isLocalPlayer) {
          return;
        }
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("isGrounded", m_grounded);
        }

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("isGrounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-scale, scale, scale);
        else if (inputX < 0)
            transform.localScale = new Vector3(scale, scale, scale);

        //Move
        if (inputX != 0){
            m_body2d.velocity = new Vector2((inputX * m_speed), m_body2d.velocity.y);
            m_animator.SetFloat("speed", Mathf.Abs(inputX * m_speed));
        }
        else {
            m_animator.SetFloat("speed", 0);
        }

        //Set AirSpeed in animator
        // m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death
        // if (Input.GetKeyDown("e")) {
        //     m_animator.SetTrigger("Death");
        // }

        //Hurt
        if (Input.GetKeyDown("q")){
            TakeDamage(20);
        }

        //Attack
        if(Input.GetMouseButtonDown(0)) {
            int i  = Random.Range(1, 4);
            m_animator.SetTrigger("Attack" + i);
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
            foreach(Collider2D player in hitPlayers){
                player.GetComponent<Character_Control>().TakeDamage(damage);
            }
        }
        // block
        else if (Input.GetMouseButton(1)){
            m_animator.SetTrigger("Block");
        }

        //Jump
        else if (Input.GetKeyDown(KeyCode.Space) && m_grounded) {
            m_animator.SetTrigger("Jump");
            m_grounded = true;
            m_animator.SetBool("isGrounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }
    }


    void OnDrawGizmosSelected(){
        if (attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
      if (!isLocalPlayer) {
        NetworkClient.Send(new DamageCharacterMessage {
            damage = AltCharacterDisplay.chosenCharacter,
            isCharHosting = !GlobalNetState.isHosting
        });
        return;
      }
        m_animator.SetTrigger("Hurt");
        currentHealth -= damage;

        if (currentHealth <= 0){
            m_animator.SetTrigger("Death");
            this.enabled = false;
        }
    }
}
