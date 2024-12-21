using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject StartGamePanel;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement= FindObjectOfType<PlayerMovement>();    
    }

    public void BeginGame()
    {
        playerMovement.PlayerCanMove();
        if (StartGamePanel != null)
            StartGamePanel.SetActive(false);
    }
}
