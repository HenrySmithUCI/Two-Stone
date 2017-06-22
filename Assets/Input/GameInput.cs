using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameInput : MonoBehaviour {

    void Update()
    {
        Vector2? sap = screenActionPos();
        if(sap.HasValue)
        {
            Stone s = getStoneUnderPoint(sap.Value);
            if(s != null)
            {
                s.tryDuplicate();
            }
        }
        CameraMove? cm = moveCamera();
        if (cm.HasValue)
        {
            HandleCamera(cm.Value);
        }
    }

    public void HandleCamera(CameraMove cm)
    {
        Transform main = Camera.main.transform;
        Vector3 newPosition = main.position;
        newPosition += new Vector3(cm.xChange, cm.yChange, 0) * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, GameSpace.instance.cameraPos.x, GameSpace.instance.RightMost + GameSpace.instance.cameraPos.x);
        newPosition.y = Mathf.Clamp(newPosition.y, GameSpace.instance.cameraPos.y, GameSpace.instance.TopMost + GameSpace.instance.cameraPos.y);
        main.position = newPosition;
    }

    public Stone getStoneUnderPoint(Vector2 ScreenPos)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(ScreenPos);
        Collider2D hitObject = Physics2D.OverlapPoint(worldPos);
        if (hitObject != null) {
            return hitObject.gameObject.GetComponent<Stone>();
        }
        return null;
    }

    public abstract Vector2? screenActionPos();
    public abstract CameraMove? moveCamera();
}

public struct CameraMove
{
    public float xChange;
    public float yChange;
}
