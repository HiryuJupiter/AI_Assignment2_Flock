using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Collider2D))]
public abstract class FishBase : MonoBehaviour
{
    float steering;

    //State classes
    protected FishStateBase escapeState;
    protected FishStateBase huntState;
    protected FishStateBase passiveState;

    //Status
    Vector2 moveDir;

    //Cache
    int layerMask_Hide;


    //Properties
    public Flock Flock { get; private set; }
    public bool IsHiding { get; private set; }
    public Collider2D Collider { get; private set; }
    public SpriteRenderer Renderer { get; private set; }
    public FishTypes FishType { get; private set; }
    public FishNeighbors neighbors { get; private set; }
    float MoveSpeed => IsHiding ? 0.1f : Flock.MoveSpeed;


    #region MonoBehavior
    protected virtual void FixedUpdate()
    {
        neighbors.DetectNeighbors();
        if (neighbors.HasPredator())
        {
            escapeState.StateFixedUpdate();
        }
        else if (neighbors.HasPrey())
        {
            huntState.StateFixedUpdate();
        }
        else
        {
            passiveState.StateFixedUpdate();
        }
    }
    #endregion

    #region Public
    public virtual void Initialize(Flock flock)
    {
        //Cache
        Flock = flock;
        FishType =  flock.FishType;
        layerMask_Hide = Settings.instance.Layer_HideSpot;
        steering = flock.Steering;

        //Reference
        Collider = GetComponent<Collider2D>();
        Renderer = GetComponent<SpriteRenderer>();

        //Initialize 
        neighbors   = new FishNeighbors(this);

        //Debug.Log("spawned fish of type :" + FishType +   ", number: " + (int)FishType);
    }

    public void Move(Vector2 newDir)
    {
        moveDir = Vector2.Lerp(moveDir, newDir.normalized * MoveSpeed, steering);
        transform.up = moveDir;
        transform.position += (Vector3)moveDir * Time.deltaTime;
    }

    public void GetsEaten ()
    {
        Flock.Despawn(this);
    }
    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsColliderHideLayer(collision))
        {
            IsHiding = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (IsColliderHideLayer(collision))
        {
            IsHiding = false;
        }
    }

    bool IsColliderHideLayer (Collider2D collision) => layerMask_Hide == (layerMask_Hide | 1 << collision.gameObject.layer);
}