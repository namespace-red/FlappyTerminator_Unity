using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const int LeftMouseButton = 0;
	
    public event Action SpacePressed;
    public event Action LeftMousePressed;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpacePressed?.Invoke();
		
        if (Input.GetMouseButton(LeftMouseButton))
            LeftMousePressed?.Invoke();
    }
}
