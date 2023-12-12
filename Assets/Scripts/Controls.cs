using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private static InputActions _inputActions;

    public static void Init(Player player)
    {
        _inputActions = new InputActions();

        _inputActions.Game.Move.performed += ctx =>
        {
            player.SetMovmentDirection(ctx.ReadValue<Vector2>());
        };
        _inputActions.Game.Dodge.performed += ctx =>
        {
            player.Dodge();
        };

        _inputActions.Game.LightAttack.performed += ctx =>
        {
            player.LightAttack();
        };

        EnableGame();
    }

    private static void EnableGame()
    {
        _inputActions.Game.Enable();
    }
}
