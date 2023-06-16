using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Character_Controller_2 : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;
    [SerializeField] float      scale = 2f;



    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // New Input System
    Vector2 inputMove = Vector2.zero;


    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

	// Update is called once per frame
	void Update () {
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        // float inputX = Input.GetAxis("Horizontal");
        float inputX = inputMove.x;

        if (!m_isDead) {
            // Swap direction of sprite depending on walk direction
            if (inputX > 0) {
                transform.localScale = new Vector3(-scale, scale, scale);
                m_animator.SetInteger("AnimState", 2);
            }

            else if (inputX < 0) {
                transform.localScale = new Vector3(scale, scale, scale);
                m_animator.SetInteger("AnimState", 2);
            }

            else if (m_combatIdle)
                m_animator.SetInteger("AnimState", 1);

            //Idle
            else
                m_animator.SetInteger("AnimState", 0);



            // Move
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        }


        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death



    }

    public void OnMove(InputAction.CallbackContext value) {
      // Debug.Log
        if (!m_isDead) {
            inputMove = value.ReadValue<Vector2>();
        }


    }

    public void OnJump(InputAction.CallbackContext value) {
        if (m_grounded && !m_isDead) {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }
    }

    public void OnAttack(InputAction.CallbackContext value) {
        if (!m_isDead) {
            m_animator.SetTrigger("Attack");
        }
    }

    public void OnHurt(InputAction.CallbackContext value) {
        if (!m_isDead) {
            TakeDamage(20);
            if (currentHealth <= 0) {
                m_animator.SetTrigger("Death");
                m_isDead = true;
            }
            else {
                m_animator.SetTrigger("Hurt");
            }

        }

    }

    public void OnDeath(InputAction.CallbackContext value) {
        if (!m_isDead) {
            m_animator.SetTrigger("Death");
            m_isDead = true;
        }

        else {
            m_animator.SetTrigger("Recover");
            currentHealth = maxHealth;
            m_isDead = false;
        }


    }

    public void OnChangeIdle(InputAction.CallbackContext value) {
        m_combatIdle = !m_combatIdle;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0){
            m_animator.SetTrigger("Death");
        }
    }
}
