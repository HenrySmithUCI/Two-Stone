using UnityEngine;

public class Stone : MonoBehaviour, Disableable {

    public int x;
    public int y;
    
    public Animation anim;

    public void Disable()
    {
        Destroy(this.gameObject);
        GameSpace.instance.checkIfWonIncludingStoneJustRemoved(x, y);
    }

    public void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void init(int x, int y)
    {
        this.x = x;
        this.y = y;
        transform.localPosition = new Vector3(x, y, -1);
    }

    public void tryDuplicate()
    {
        if (GameSpace.instance.getStone(x + 1, y) == null && GameSpace.instance.getStone(x, y + 1) == null)
        {
            GameSpace.instance.makeStone(x + 1, y);
            GameSpace.instance.makeStone(x, y + 1);
            anim.Play("DestroyStone");
        }
        else
        {
            anim.Play("FailCreate");
        }
    }
}
