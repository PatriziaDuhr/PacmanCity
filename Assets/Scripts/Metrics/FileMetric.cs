using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FileMetric
{
    public string Name;
    public int LoC;
    public List<ClassMetric> ClassMetrics;

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
        cube.transform.localScale = new Vector3(visualizer.Depth-visualizer.Border, visualizer.Height, LoC/100f-visualizer.Border);
        
        var label = GameObject.Instantiate(visualizer.LabelPrefab);
        label.transform.parent = root.transform;
        label.transform.localScale = Vector3.one;
        label.transform.localPosition = new Vector3((visualizer.Depth-visualizer.Border)/2f + visualizer.Border, 0, 0);
        label.GetComponentInChildren<TMP_Text>().text = Name;

        //determine positions of children 
        var startZ = -(LoC / 100f) * 0.5f;
        foreach (var classMetric in ClassMetrics)
        {
            startZ += classMetric.LoC / 100f * 0.5f;
            var filePosition = new Vector3(0, visualizer.Height/2f + visualizer.Height /2f, startZ);
            // add root object to safely scale visual gameObjects without scaling other children 
            var classRoot = new GameObject(classMetric.Name+"Root");
            classRoot.transform.parent = root.transform;
            classRoot.transform.localScale = Vector3.one;
            classRoot.transform.localPosition = filePosition;
            classRoot.transform.localRotation = Quaternion.identity;
            startZ += classMetric.LoC / 100f * 0.5f;
            classMetric.Visualize(classRoot);
        }
    }
}
