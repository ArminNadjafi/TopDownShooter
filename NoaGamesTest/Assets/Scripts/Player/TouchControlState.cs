using UnityEngine;

public class TouchControlState : IControlState
{
    private Vector2 startTouchPos;
    private bool isDragging = false;
    private float sensivity = 150;
    public void HandleInput(PlayerController player)
    {
      
        if (Input.GetMouseButtonDown(0)) 
        {
            startTouchPos = Input.mousePosition;
            isDragging = true;
            player.Shoot();
        }
        else if (Input.GetMouseButton(0) && isDragging)  
        {
            float deltaX = Input.mousePosition.x - startTouchPos.x;

            if (Mathf.Abs(deltaX) > sensivity)
            {
                if (deltaX > 0)
                    player.Move(1);
                else
                    player.Move(-1);

                startTouchPos = Input.mousePosition;
            }

            player.Shoot();
        }
        else if (Input.GetMouseButtonUp(0))  
        {
            isDragging = false;
        }
    }
}