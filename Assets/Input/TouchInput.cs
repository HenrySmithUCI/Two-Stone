using UnityEngine;

public class TouchInput : GameInput {
    public override CameraMove? moveCamera()
    {
        return null;
    }

    public override Vector2? screenActionPos()
    {
        if(Input.touchCount > 0)
        {
            return Input.GetTouch(0).position;
        }
        else
        {
            return null;
        }
    }
}
