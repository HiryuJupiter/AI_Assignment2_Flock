using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UIElements;

[RequireComponent(typeof(HUDSpawnButtons))]
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] Text debugText;

    HUDSpawnButtons spawnButtons;
    SpawningMode currentMode;

    void Awake()
    {
        instance = this;
        spawnButtons = GetComponent<HUDSpawnButtons>();
        ExitSpawningMode();
    }

    public void EnterSpawningMode (SpawningMode mode)
    {
        Debug.Log("EnterSpawningMode :" + mode);
        spawnButtons.RevealButtonBorder(mode);
        DisplayDebugText("Click and hold left-mouse-button to spawn fish!");
    }

    public void ExitSpawningMode ()
    {
        spawnButtons.HideButtonBorder();
        DisplayDebugText("");
    }

    void DisplayDebugText(string text)
    {
        debugText.text = text;
    }
}
