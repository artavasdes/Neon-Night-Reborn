using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


{

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

    public InputActions controls;
    // Start is called before the first frame update
    void Awake() {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        maxHealth = 100;
        currentHealth = maxHealth;
        // healthBar.SetMaxHealth(maxHealth);
        transform.localScale = new Vector3(scale, scale, scale);
        controls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    void Move(Vector2 input) {
        Debug.Log("Move");

        if (input.x > 0)
            transform.localScale = new Vector3(-scale, scale, scale);
        else if (input.x < 0)
            transform.localScale = new Vector3(scale, scale, scale);

        if (input.x != 0){
            m_body2d.velocity = new Vector2((input.x * m_speed), m_body2d.velocity.y);
            m_animator.SetFloat("speed", Mathf.Abs(input.x * m_speed));
        }
        else {
            m_animator.SetFloat("speed", 0);
        }
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }


}
