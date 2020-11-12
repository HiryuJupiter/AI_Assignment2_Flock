using UnityEngine;

namespace FlockPrototype
{
    //Require component to minimize the mistake of forgetting to add it
    [RequireComponent(typeof(Collider2D))]
    //Use an abstract class to reuse code
    public abstract class FishBase : MonoBehaviour
    {
        //State classes
        protected FishStateBase escapeState;
        protected FishStateBase huntState;
        protected FishStateBase passiveState;

        //Status
        Vector2 moveDir;
        float steering;

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
        //Virtual method that child classes can override
        protected virtual void FixedUpdate()
        {
            //First detect and sort all neighbors, then use a if else statement as a 
            //simple state machine to execute different states
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
        //Use an Initialize method to tell this fish which flock it belongs to
        public virtual void Initialize(Flock flock)
        {
            //Cache
            Flock = flock;
            FishType = flock.FishType;
            layerMask_Hide = Settings.instance.Layer_HideSpot;
            steering = flock.Steering;

            //Reference
            Collider = GetComponent<Collider2D>();
            Renderer = GetComponent<SpriteRenderer>();

            //Initialize 
            neighbors = new FishNeighbors(this);

            //Debug.Log("spawned fish of type :" + FishType +   ", number: " + (int)FishType);
        }

        public void Move(Vector2 newDir)
        {
            //Execute movement by modifying transform.position
            moveDir = Vector2.Lerp(moveDir, newDir.normalized * MoveSpeed, steering);
            transform.up = moveDir;
            transform.position += (Vector3)moveDir * Time.deltaTime;
        }

        public void GetsEaten()
        {
            //Tell the flock to despawn this fish when it is eaten
            Flock.Despawn(this);
        }
        #endregion

        void OnTriggerEnter2D(Collider2D collision)
        {
            //When the fish enters a hiding-zone, change the boolean to true
            if (IsColliderHideLayer(collision))
            {
                IsHiding = true;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            //When the fish exits a hiding-zone, change this boolean to false
            if (IsColliderHideLayer(collision))
            {
                IsHiding = false;
            }
        }

        //See if the collided object is a hide layer
        bool IsColliderHideLayer(Collider2D collision) => layerMask_Hide == (layerMask_Hide | 1 << collision.gameObject.layer);
    }
}