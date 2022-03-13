using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
public float Speed = 5f;
public float rotationspeed= 280f;

public float turnSmoothTime = 0.1f;
float turnSmoothVelocity;


float horizontal;
float vertical;

private void Update()
{
    Vector3 Direction = Vector3.forward * vertical + Vector3.right * horizontal;

   

    

    

     if (Direction.magnitude >= 0.1f)
     {
         float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg -90f;
         float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
         transform.rotation = Quaternion.Euler(0f, angle, 0f);

        

          transform.position += Direction * Speed * Time.deltaTime;
     }
}
   
public void OnMoveInput( float horizontal, float vertical)
{
    this.vertical = vertical;
    this.horizontal = horizontal;

}


}
