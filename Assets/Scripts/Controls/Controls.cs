using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private static InputActions _inputActions;

    public static void Init(Player player)
    {
        _inputActions = new InputActions();

        _inputActions.Movement.Move.performed += ctx =>
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
        _inputActions.Game.HeavyAttack.performed += ctx =>
        {
            player.HeavyAttack();
        };


        _inputActions.MenuControls.Menu.performed += ctx =>
        {
            player.InventoryMenu();
        };

        _inputActions.Game.TwoHandToggle.performed += ctx =>
        {
            player.ToggleTwoHanded();
        };

        EnableGame();
    }

    public static void EnableGame()
    {
        _inputActions.Game.Enable();
        _inputActions.Movement.Enable();
        _inputActions.MenuControls.Enable();
    }

    public static void MenuMode()
    {
        _inputActions.Game.Disable();
    }

    
}
