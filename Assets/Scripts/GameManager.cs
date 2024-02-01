using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    // Define a Singleton Property
    public static GameManager instance { get; private set; }

    // Referances to the main game objects in game.
    public GameObject player {  get; private set; }
    public GameObject market1 { get; private set; }
    public GameObject market2 { get; private set; }
    public GameObject atm { get; private set; }

    public Market ActiveMarket { get; set; }

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
        market1 = GameObject.Find("Market 1");
        market2 = GameObject.Find("Market 2");
        atm = GameObject.Find("ATM");

        UIManager.instance.InitializeGameGUI();
    }

    public void PlayerSlept()
    {
        UIManager.instance.ShowSleepingTimerWindow();
    }

    public void PlayerWake_UpTime()
    {
        player.GetComponent<Bank>().Amount += player.GetComponent<Bank>().Amount * 0.1f;
        UIManager.instance.CloseAllWindows();
    }

    // This method generates new unique id for each item awakened in the world.
    public int GenerateItemId()
    {
        _itemIds++;

        return _itemIds;
    }
}
