using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedState : PlayerState
{
    public PlayerDamagedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
}
