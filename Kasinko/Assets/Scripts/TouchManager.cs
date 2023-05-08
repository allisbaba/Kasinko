using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
   [SerializeField] private GameObject player;
   private PlayerInput _playerInput;
   private InputAction touchPositionAction;
   private InputAction touchPressAction;

   private void Awake()
   {
      _playerInput = GetComponent<PlayerInput>();
      touchPressAction = _playerInput.actions["TouchPress"];
      touchPositionAction = _playerInput.actions["TouchPosition"];
   }

   private void OnEnable()
   {
      touchPressAction.performed += TouchPressed;
   }

   private void OnDisable()
   {
      touchPressAction.performed -= TouchPressed;
   }

   private void TouchPressed(InputAction.CallbackContext context)
   {
      Vector3 position =Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
      position.z = player.transform.position.z;
      player.transform.position = position;
   }
}
