using System;
using UnityEngine;

public class MouseInput : GameInput {

    public float camSpeed = 4;

    public override CameraMove? moveCamera()
    {
        float v = Input.GetAxisRaw("Vertical") * camSpeed;
        float h = Input.GetAxisRaw("Horizontal") * camSpeed;
        if(!(v == 0 && h == 0))
        {
            return new CameraMove() { xChange = h, yChange = v };
        }
        return null;
    }

    public override Vector2? screenActionPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return Input.mousePosition;
        }
        return null;
    }
}
