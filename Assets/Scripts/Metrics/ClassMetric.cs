using TMPro;
using UnityEngine;

public class ClassMetric
{
    public string Name;
    public int LoC;
    public int NumOfAttributes; 
    public int NumOfMethods;
    public bool DuplicateCode;
    public int NumOfPrivateAttributes;
    public int NumOfPrivateMethods;

    private GameObject _root;
    public void Visualize(GameObject root)
    {
        var visualizer = GameObject.FindObjectOfType<Visualizer>();
        
        // project cube, base of city metaphor 
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        // append cube as child of _root and reset Position and Rotation
        cube.transform.parent = root.transform; 
        cube.transform.localPosition = Vector3.zero;
        cube.transform.localRotation = Quaternion.identity;
        // set size of base 
        cube.transform.localScale = new Vector3(visualizer.Depth-2*visualizer.Border, visualizer.Height, LoC/100f-2*visualizer.Border);

        var label = GameObject.Instantiate(visualizer.LabelPrefab);
        label.transform.parent = root.transform;
        label.transform.localScale = Vector3.one;
        label.transform.localPosition = new Vector3((visualizer.Depth-2*visualizer.Border)/2f + visualizer.Border, 0, 0);
        label.GetComponentInChildren<TMP_Text>().text = Name;
        
        // Change color depending on DuplicateCode
        if (DuplicateCode)
        {
            cube.GetComponent<Renderer>().material.color = visualizer.HasDuplicateCodeColor;
        }
        else
        {
            cube.GetComponent<Renderer>().material.color = visualizer.NoDuplicateCodeColor;
        }

        // attribute cube
        var attributes = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // append cube as child of _root for attributes
        attributes.transform.parent = root.transform; 
        attributes.transform.localPosition =  new Vector3((visualizer.Depth-2*visualizer.Border)/4f, NumOfAttributes/100f +visualizer.Height/2f, 0);
        // set size of attribute cube
        attributes.transform.localScale = new Vector3(visualizer.Height, NumOfAttributes/50f, LoC/100f-2*visualizer.Border);
        attributes.transform.localRotation = Quaternion.identity;
        // change colour between red and green depending on the percentage of private attributes
        attributes.GetComponent<Renderer>().material.color =
            Color.Lerp(visualizer.BadIntimicyColor, visualizer.GoodIntimicyColor, (1f * NumOfPrivateAttributes) / NumOfAttributes);
        
        // method cylinder
        var methods = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        // append cylinder as child of _root for methods
        methods.transform.parent = root.transform; 
        methods.transform.localPosition =  new Vector3(-(visualizer.Depth-2*visualizer.Border)/4f, NumOfMethods/50f +visualizer.Height/2f, 0);
        // set size of method cylinder
        methods.transform.localScale = new Vector3(visualizer.Height, NumOfMethods/50f, LoC/100f-2*visualizer.Border);
        methods.transform.localRotation = Quaternion.identity;
        // change colour between red and green depending on the percentage of private methods
        methods.GetComponent<Renderer>().material.color =
            Color.Lerp(visualizer.BadIntimicyColor, visualizer.GoodIntimicyColor, (1f * NumOfPrivateMethods) / NumOfMethods);
    }
    
    
}

