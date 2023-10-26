using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerManager
{
    private static MoverBase playerMover;
    private static MoverBase emptyMover;

    private static PlayerAxisController playerController;
    
    public static void SetPlayerMover(MoverBase newMover)
    {
        playerMover = newMover;
    }

    public static void SetPlayerController(PlayerAxisController controller)
    {
        playerController = controller;
    }

    public static PlayerAxisController GetPlayerController()
    {
        return playerController;
    }
    
    
    public static MoverBase GetPlayerMover()
    {
        if (playerMover != null)
            return playerMover;

        if (emptyMover == null)
        {
            emptyMover = new GameObject("Empty Mover").AddComponent<MoverBase>();
        }

        return emptyMover;
    }
}
