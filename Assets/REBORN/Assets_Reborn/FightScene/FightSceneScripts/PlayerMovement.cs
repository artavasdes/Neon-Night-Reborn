using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] 
    private float speed = 5f;
    private PlayerInputs _playerInputs;
    private Rigidbody2D _rbody;
    private Vector2 _moveInput;

    void Awake() {
        _playerInputs = new PlayerInputs();

        _rbody = GetComponent<Rigidbody2D>();
        if (_rbody is null) {
            Debug.LogError("Rigidbody2D is null!");
        }
    }

    private void OnEnable() {
        _playerInputs.InGame.Enable();
    }

    private void OnDisable() {
        _playerInputs.InGame.Disable();
    }

    void FixedUpdate() {
        _moveInput = _playerInputs.InGame.Movement.ReadValue<Vector2>();
        _moveInput.y = 0f;
        _rbody.velocity = _moveInput * speed;
    }

    
}
