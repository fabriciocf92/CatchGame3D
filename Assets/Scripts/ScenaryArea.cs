using UnityEngine;

public class ScenaryArea : Singleton<ScenaryArea>
{

    private float MinX;
    private float MaxX;
    private float MinY;
    private float MaxY;
    private float MinZ;
    private float MaxZ;

    public Vector3 getRandomPoint(Collider collider) {
        var size = collider.bounds.size/2;
        return new Vector3(Random.Range(MinX + size[0], MaxX - size[0]), 
            Random.Range(MinY + size[1], MaxY - size[1]), 
            Random.Range(MinZ + size[2], MaxZ - size[2]));
    }


    //public static ScenaryArea Instance { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        //if (Instance != null && Instance != this)
        //{
        //    Destroy(this);
        //}
        //else
        //{
        //    Instance = this;
        //}

        Vector3 LeftWall = GameObject.Find("Left Wall").transform.position;
        var RightWall = GameObject.Find("Right Wall").transform.position;
        var ForwardWall = GameObject.Find("Forward Wall").transform.position;
        var BackwardWall = GameObject.Find("Backward Wall").transform.position;
        float[] XValues = { LeftWall[0], RightWall[0], ForwardWall[0], BackwardWall[0] };
        float[] ZValues = { LeftWall[2], RightWall[2], ForwardWall[2], BackwardWall[2] };
        float[] YValues = { 1.0f, 3.5f };

        MinX = Mathf.Min(XValues) + 0.1f;
        MaxX = Mathf.Max(XValues) - 0.1f;
        MinY = Mathf.Min(YValues);
        MaxY = Mathf.Max(YValues);
        MinZ = Mathf.Min(ZValues) + 0.1f;
        MaxZ = Mathf.Max(ZValues) - 0.1f;
    }

}
