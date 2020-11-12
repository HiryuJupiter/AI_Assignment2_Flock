using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class SpawningManager : MonoBehaviour
{
    const float ClickAndHoldSpawnInterval = 0.1f;

    [SerializeField] Flock Flock_TinyFish;
    [SerializeField] Flock Flock_SmallFish;
    [SerializeField] Flock Flock_MediumFish;
    [SerializeField] Flock Flock_BigFish;

    //Status
    SpawningMode mode;

    //Reference
    Camera camera;
    UIManager ui;

    //Cache
    float spawnTimer;

    #region Monobehavior
    void Start()
    {
        camera = Camera.main;
        ui = UIManager.instance;
    }

    void Update()
    {
        TickSpawnTimer();
        SpawningInputUpdate();
    }
    #endregion

    #region Public
    public void SetSpawnMode_TinyFish() => SetSpawnMode(SpawningMode.TinyFish);
    public void SetSpawnMode_SmallFish ()=> SetSpawnMode(SpawningMode.SmallFish);
    public void SetSpawnMode_MediumFish ()=> SetSpawnMode(SpawningMode.MediumFish);
    public void SetSpawnMode_BigFish ()=> SetSpawnMode(SpawningMode.BigFish);
    #endregion

    #region Private
    void SpawningInputUpdate ()
    {
        if (PlayerClicksSpawn() && IsSpawnTimerReady())
        {
            SpawnFish();
        }
        else if (PlayerExitsSpawningMode())
        {
            mode = SpawningMode.None;
            ui.ExitSpawningMode();
            SetSpawnTimerToReady();
        }
    }

    void SetSpawnMode(SpawningMode mode)
    {
        this.mode = mode;
        ui.EnterSpawningMode(mode);
    }

    Vector3 MousePosition()
    {
        Vector3 pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 1f;
        return pos;
    }

    void SpawnFish ()
    {
        switch (mode)
        {
            case SpawningMode.TinyFish:
                Flock_TinyFish.Spawn(MousePosition());
                break;
            case SpawningMode.SmallFish:
                Flock_SmallFish.Spawn(MousePosition());
                break;
            case SpawningMode.MediumFish:
                Flock_MediumFish.Spawn(MousePosition());
                break;
            case SpawningMode.BigFish:
                Flock_BigFish.Spawn(MousePosition());
                break;
        }
        ResetSpawnTimer();
    }

    void TickSpawnTimer()
    {
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    void ResetSpawnTimer () => spawnTimer = ClickAndHoldSpawnInterval;
    void SetSpawnTimerToReady () => spawnTimer = 0f;

    bool PlayerExitsSpawningMode () => Input.GetKeyDown(KeyCode.Escape);

    bool PlayerClicksSpawn () => Input.GetMouseButton(0);
    bool IsSpawnTimerReady () => spawnTimer <= 0f;
    #endregion
}