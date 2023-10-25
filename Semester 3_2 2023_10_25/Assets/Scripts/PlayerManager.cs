using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerManager
{
    private static MoverBase playerMover;
    private static MoverBase emptyMover;

    public static void SetPlayerMover(MoverBase newMover)
    {
        playerMover = newMover;
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
