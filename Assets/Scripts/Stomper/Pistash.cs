using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Pistash : MonoBehaviour
{
    private Collider2D _collider2DactionCollider;
    private Transform _triangleTransform;
    private Transform _pistonTransform;
    private Transform _goalTransform;
    
    private Transform _initialSpot;
    
    public TMPro.TextMeshProUGUI timerText;
    public float timerAfterClick;
    
    private Time _oneShotTime;
    
    // Update is called once per frame
    void Update()
    {
        if (IsMouseClickedOnCollider())
        {
            timerAfterClick += Time.deltaTime;
            timerText.text = timerAfterClick.ToString("F2");
        }
        else
        {
            ReturnBackToInitials();
        }
    
}

    private bool IsMouseClickedOnCollider()
    {
        if (Input.GetMouseButton(0))
        {        
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return Physics2D.OverlapPoint(mouseWorldPosition) != null;
        }
        
        timerText.SetText("None");
        timerAfterClick = 0;
        return false;
    }
    
    void ReturnBackToInitials()
    {
        
    }
    
    void MovePiston()
    {
        
    }
}