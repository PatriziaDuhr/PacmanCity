using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectMetric
{
    public string Name;
    public int LoC;
    public List<FileMetric> FileMetrics;

    public void Visualize(GameObject root)
    {
        // Get singleton VisualizerComponent
        var visualizer = GameObject.FindObjectOfType<Visualizer>();

        // project cube, base of city metaphor 
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        // append cube as child of _root and reset Position and Rotation
        cube.transform.parent = root.transform; 
        cube.transform.localPosition = Vector3.zero;
        cube.transform.localRotation = Quaternion.identity;
        // set size 
        cube.transform.localScale = new Vector3(visualizer.Depth, visualizer.Height, LoC/100f);

        var label = GameObject.Instantiate(visualizer.LabelPrefab);
        label.transform.parent = root.transform;
        label.transform.localScale = Vector3.one;
        label.transform.localPosition = new Vector3(visualizer.Depth/2f + visualizer.Border, 0, 0);
        label.GetComponentInChildren<TMP_Text>().text = Name;

        //determine positions of children 
        var startZ = -(LoC / 100f) * 0.5f;
        foreach (var fileMetric in FileMetrics)
        {
            startZ += fileMetric.LoC / 100f * 0.5f;
            var filePosition = new Vector3(0, visualizer.Height/2f + visualizer.Height/2f, startZ);
            // add root object to safely scale visual gameObjects without scaling other children 
            var fileRoot = new GameObject(fileMetric.Name);
            fileRoot.transform.parent = root.transform;
            fileRoot.transform.localScale = Vector3.one;
            fileRoot.transform.localPosition = filePosition;
            fileRoot.transform.localRotation = Quaternion.identity;
            startZ += fileMetric.LoC / 100f * 0.5f;
            fileMetric.Visualize(fileRoot);
        }
    }
}
