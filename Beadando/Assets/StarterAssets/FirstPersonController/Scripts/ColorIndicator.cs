using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIndicator : MonoBehaviour
{

    [SerializeField] private Vector3 rotationVector = new Vector3(10, 10, 10);
    [SerializeField] private Color selectedColor;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
        this.GetComponent<MeshRenderer>().material.SetColor("_Color", selectedColor);

    }
    public void setColor(Color color)
    {
        selectedColor = color;
    }
}
