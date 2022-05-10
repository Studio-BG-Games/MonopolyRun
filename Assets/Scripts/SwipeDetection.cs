using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static event OnSwipeEvent SwipeEvent;
    public delegate void OnSwipeEvent(Vector3 direction);

    private Vector2 tapPosition;
    private Vector3 swipeDelta;

    private bool isSwiping;
    private bool isMobile;
    void Start()
    {
        isMobile = Application.isMobilePlatform;
    }

    void Update()
    {
        if (!isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
                ResetSwipe();
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    isSwiping = true;
                    tapPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled ||
                    Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }
        }
        CheckSwipe();
    }
    private void CheckSwipe()
    {
        swipeDelta = Vector2.zero;
        if (isSwiping)
        {
            if (!isMobile && Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - tapPosition;
                tapPosition = Input.mousePosition;
                //Debug.Log($"{swipeDelta.magnitude}");
            }
            else if (Input.touchCount > 0)
            {
                swipeDelta = Input.GetTouch(0).position - tapPosition;
               
            }
              
        }

        SwipeEvent?.Invoke(swipeDelta);
       
    }
    private void ResetSwipe()
    {
        isSwiping = false;
        tapPosition = Vector2.zero;
        swipeDelta = Vector2.zero;

    }
}
