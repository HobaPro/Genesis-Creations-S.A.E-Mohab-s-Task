using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Define a Singleton Property
    public static GameManager instance { get; private set; }

    // Referances to the main game objects in game.
    public GameObject player {  get; private set; }
    public GameObject market { get; private set; }
    public GameObject atm { get; private set; }

    private int _itemIds { get; set; }

    private void Awake()
    {
        // Intialize Singleton
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        Loader.Load(Loader.Scene.GAME);
    }

    public void OnGameSceneLoaded()
    {
        player = GameObject.Find("Player");
        market = GameObject.Find("Market");
        atm = GameObject.Find("ATM");

        foreach (Item item in FindObjectsOfType<Item>())
        {
            market.GetComponent<MarketInventory>().AddItem(item.GetComponent<Item>());
        }

        UIManager.instance.InitializeGameGUI();
    }

    public void PlayerSlept()
    {
        UIManager.instance.ShowSleepingTimerWindow();
    }

    public void PlayerWake_UpTime()
    {
        UIManager.instance.CloseAllWindows();
    }

    // This method generates new unique id for each item awakened in the world.
    public int GenerateItemId()
    {
        _itemIds++;

        return _itemIds;
    }
}
