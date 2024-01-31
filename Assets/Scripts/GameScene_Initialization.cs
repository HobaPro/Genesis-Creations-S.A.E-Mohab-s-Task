using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene_Initialization : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameManager.instance.OnGameSceneLoaded();
    }
}
