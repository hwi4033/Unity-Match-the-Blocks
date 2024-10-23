using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCastManager : MonoBehaviour
{
    [SerializeField] GameObject firstCube = null;

    private void Update()
    {
        OnClick();
    }

    public void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedCube = hit.collider.gameObject;

                if (firstCube == null)
                {
                    firstCube = clickedCube;
                }
                else
                {
                    if (firstCube != clickedCube)
                    {
                        Color firstColor = firstCube.GetComponent<Renderer>().material.color;
                        Color secondColor = clickedCube.GetComponent<Renderer>().material.color;

                        if (firstColor == secondColor)
                        {
                            Destroy(firstCube);
                            Destroy(clickedCube);
                        }

                        firstCube = null;
                    }
                }
            }
        }
    }
}