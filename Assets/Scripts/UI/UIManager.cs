using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    // GUI Windows
    [SerializeField] private GameObject _mainWindow;
    [SerializeField] private GameObject _shopkeeperInventoryWindow;
    [SerializeField] private GameObject _playerInventoryWindow;
    [SerializeField] private GameObject _atmWindow;
    [SerializeField] private GameObject _sleepingTimerWindow;

    // GUI Buttons
    [SerializeField] private Button _marketBtn;
    [SerializeField] private Button _playerInventoryBtn;
    [SerializeField] private Button _atmBtn;
    [SerializeField] private Button _sleepingBtn;
    [SerializeField] private Button _closeWindowsBtn;

    [SerializeField] private Button _depositBtn;
    [SerializeField] private Button _withdrawBtn;

    // GUI Texts
    [SerializeField] private Text _playerCashTxt;
    [SerializeField] private Text _playerBankTxt;
    [SerializeField] private Text _alertMessage;

    // GUI Input Fields
    [SerializeField] private InputField _atmAmountInput;

    private void Awake()
    {
        // Intialize Singleton
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;

        DontDestroyOnLoad(this.gameObject);

        _marketBtn.onClick.AddListener(ShowShopkeeperInventoryWindow);
        _playerInventoryBtn.onClick.AddListener(ShowPlayerInventoryWindow);
        _atmBtn.onClick.AddListener(ShowATMWinddow);
        _sleepingBtn.onClick.AddListener(ShowSleepingTimerWindow);
        _closeWindowsBtn.onClick.AddListener(CloseAllWindows);

        _depositBtn.onClick.AddListener(HandleDeposit);
        _withdrawBtn.onClick.AddListener(HandleWithdraw);
    }


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public void InitializeGameGUI()
    {
        _playerCashTxt.text = $"{GameManager.instance.player.GetComponent<Cash>().Amount}$";
        _playerBankTxt.text = $"{GameManager.instance.player.GetComponent<Bank>().Amount}$";

        ShowMainWindow();

        Cash.OnCashChanged += OnPlayerChashChanged;
        Bank.OnBankChanged += OnPlayerBankChanged;
    }

    public void ShowMainWindow()
    {
        _mainWindow.SetActive(true);
    }

    public void ShowPlayerInventoryWindow()
    {
        ActivateSpecificWindow(_playerInventoryWindow);
    }

    public void ShowShopkeeperInventoryWindow()
    {
        ActivateSpecificWindow(_shopkeeperInventoryWindow);
    }

    public void ShowATMWinddow()
    {
        ActivateSpecificWindow(_atmWindow);
    }

    public void ShowSleepingTimerWindow()
    {
        ActivateSpecificWindow(_sleepingTimerWindow);
    }

    public void CloseAllWindows()
    {
        // Disable all windows
        _shopkeeperInventoryWindow.SetActive(false);
        _playerInventoryWindow.SetActive(false);
        _atmWindow.SetActive(false);
        _sleepingTimerWindow.SetActive(false);

        _alertMessage.gameObject.SetActive(false);
    }

    private void ActivateSpecificWindow(GameObject window)
    {
        // Disable all windows
        _shopkeeperInventoryWindow.SetActive(false);
        _playerInventoryWindow.SetActive(false);
        _atmWindow.SetActive(false);
        _sleepingTimerWindow.SetActive(false);

        // Enable the specified window
        window.SetActive(true);
    }

    private void HandleDeposit()
    {
        float amount;
        if (_atmAmountInput.text == "") amount = 0;
        else amount = float.Parse(_atmAmountInput.text);

        GameManager.instance.atm.GetComponent<ATM>().Deposit(GameManager.instance.player.GetComponent<Bank>(), amount);
    }

    private void HandleWithdraw()
    {
        float amount;
        if (_atmAmountInput.text == "") amount = 0;
        else amount = float.Parse(_atmAmountInput.text);

        GameManager.instance.atm.GetComponent<ATM>().Withdraw(GameManager.instance.player.GetComponent<Bank>(), amount);
    }

    public void AlertMessage(string message, bool isError = false)
    {
        if (isError) _alertMessage.color = Color.red;
        else _alertMessage.color = Color.green;

        _alertMessage.text = message;

        _alertMessage.gameObject.SetActive(true);
    }

    public void EmptyAmountInput()
    {
        _atmAmountInput.text = "";
    }

    private void OnPlayerChashChanged(float amount)
    {
        _playerCashTxt.text = $"{amount}$";
    }

    private void OnPlayerBankChanged(float amount)
    {
        _playerBankTxt.text = $"{amount}$";
    }

    private void OnDestroy()
    {
        Cash.OnCashChanged -= OnPlayerChashChanged;
        Bank.OnBankChanged -= OnPlayerBankChanged;
    }
}
