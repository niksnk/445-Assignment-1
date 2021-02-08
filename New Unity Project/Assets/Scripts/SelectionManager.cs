using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    //create serialized field for materials and tags
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material Highlighted;
    [SerializeField] private Material WoodenTable;
    [SerializeField] private Material WoodenChair;

    private Transform _selection;


    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (_selection.gameObject.name == "CoffeeTable")
            {
                selectionRenderer.material = WoodenTable;
                _selection = null;
            }
            else
            {
                selectionRenderer.material = WoodenChair;
                _selection = null;
            }
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag)) 
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = Highlighted;
                }

                _selection = selection;
            }
            
        }
    }
}
