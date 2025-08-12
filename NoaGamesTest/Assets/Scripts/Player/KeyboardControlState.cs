using UnityEngine;

public class KeyboardControlState : IControlState
{
    public void HandleInput(PlayerController player)
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.Move(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.Move(1);
        }
    }
}