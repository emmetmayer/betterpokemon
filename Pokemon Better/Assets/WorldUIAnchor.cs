using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldUIAnchor : MonoBehaviour
{
    public RectTransform uiElement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 elementPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        uiElement.position = elementPosition;
    }
}
