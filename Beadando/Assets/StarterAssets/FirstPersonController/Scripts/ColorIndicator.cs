using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIndicator : MonoBehaviour
{

    [SerializeField] private Vector3 rotationVector = new Vector3(10, 10, 10);
    [SerializeField] private Color selectedColor;
    private void Start()
    {
        selectedColor = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotationVector * Time.deltaTime);
    }
    public void setColor(Color color)
    {
        selectedColor = color;
        this.GetComponent<MeshRenderer>().material.SetColor("_Color", selectedColor);
    }
}
