using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

 [Serializable]
 public class MoveInputEvent : UnityEvent<float, float> { }


public class CharacterMovement : MonoBehaviour
{
    Controls controls;
    public MoveInputEvent MoveInputEvent;

    private void Awake()
    {
        controls= new Controls();
    }

    private void OnEnable()
        {
           controls.Gameplay.Enable();
           controls.Gameplay.Move.performed += OnMoveDone;
           controls.Gameplay.Move.canceled += OnMoveDone;
        }
      private void OnMoveDone(InputAction.CallbackContext context)
      {
          Vector2 moveInput= context.ReadValue<Vector2>();
          MoveInputEvent.Invoke(moveInput.x, moveInput.y);
          //Debug.Log($"Move Input:{moveInput}");
      }

   
}
