using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingObject : MonoBehaviour
{
    private bool isVisible = false;

    public void SetVisible(bool isVisible) 
    {
        this.isVisible = isVisible;
        gameObject.SetActive(isVisible);
    }
}
