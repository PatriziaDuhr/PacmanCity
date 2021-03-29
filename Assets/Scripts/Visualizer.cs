using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Visualizer : MonoBehaviour
{
    //metadata of Pacman unrefactored and Pac refactored
    public static ProjectMetric Pacman = new ProjectMetric()
    {
        Name = "Pacman",
        LoC = 892,
        FileMetrics = new List<FileMetric>()
        {
            new FileMetric()
            {
                Name = "GameSounds.java",
                LoC = 42,
                ClassMetrics = new List<ClassMetric>()
                {
                    new ClassMetric()
                    {
                        Name = "GameSounds",
                        LoC = 42,
                        NumOfMethods = 5,
                        NumOfAttributes = 4,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 0,
                        NumOfPrivateMethods = 0,
                    }
                }
            },
            new FileMetric()
            {
                Name = "Pacman.java",
                LoC = 146,
                ClassMetrics = new List<ClassMetric>()
                {
                    new ClassMetric()
                    {
                        Name = "Pacman",
                        LoC = 146,
                        NumOfMethods = 12,
                        NumOfAttributes = 4,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 0,
                        NumOfPrivateMethods = 0,
                    }
                }
            },
            new FileMetric()
            {
                Name = "Board.java",
                LoC = 704,
                ClassMetrics = new List<ClassMetric>()
                {
                    new ClassMetric()
                    {
                        Name = "Board",
                        LoC = 413,
                        NumOfMethods = 11,
                        NumOfAttributes = 41,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 0,
                        NumOfPrivateMethods = 0,
                    }, 
                    new ClassMetric()
                    {
                        Name = "Player",
                        LoC = 168,
                        NumOfMethods = 12,
                        NumOfAttributes = 4,
                        DuplicateCode = true,
                        NumOfPrivateAttributes = 0,
                        NumOfPrivateMethods = 0,
                    },
                    new ClassMetric()
                    {
                        Name = "Ghost",
                        LoC = 101,
                        NumOfMethods = 5,
                        NumOfAttributes = 9,
                        DuplicateCode = true,
                        NumOfPrivateAttributes = 0,
                        NumOfPrivateMethods = 0,
                    },
                    new ClassMetric()
                    {
                        Name = "Mover",
                        LoC = 22,
                        NumOfMethods = 3,
                        NumOfAttributes = 5,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 0,
                        NumOfPrivateMethods = 0,
                    }
                }
            }
        }
    };
    
    
    public static ProjectMetric PacmanRefactored = new ProjectMetric()
    {
        Name = "PacmanRefactored",
        LoC = 961,
        FileMetrics = new List<FileMetric>()
        {
            new FileMetric()
            {
                Name = "GameSounds.java",
                LoC = 42,
                ClassMetrics = new List<ClassMetric>()
                {
                    new ClassMetric()
                    {
                        Name = "GameSounds",
                        LoC = 42,
                        NumOfMethods = 5,
                        NumOfAttributes = 4,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 0,
                        NumOfPrivateMethods = 0,
                    }
                }
            },
            new FileMetric()
            {
                Name = "Pacman.java",
                LoC = 146,
                ClassMetrics = new List<ClassMetric>()
                {
                    new ClassMetric()
                    {
                        Name = "Pacman",
                        LoC = 146,
                        NumOfMethods = 12,
                        NumOfAttributes = 4,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 0,
                        NumOfPrivateMethods = 1,
                    }
                }
            },
            new FileMetric()
            {
                Name = "Board.java",
                LoC = 773,
                ClassMetrics = new List<ClassMetric>()
                {
                    new ClassMetric()
                    {
                        Name = "Board",
                        LoC = 378,
                        NumOfMethods = 11,
                        NumOfAttributes = 24,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 24,
                        NumOfPrivateMethods = 0,
                    }, 
                    new ClassMetric()
                    {
                        Name = "Player",
                        LoC = 185,
                        NumOfMethods = 6,
                        NumOfAttributes = 14,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 9,
                        NumOfPrivateMethods = 0,
                    },
                    new ClassMetric()
                    {
                        Name = "Ghost",
                        LoC = 74,
                        NumOfMethods = 4,
                        NumOfAttributes = 12,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 12,
                        NumOfPrivateMethods = 0,
                    },
                    new ClassMetric()
                    {
                        Name = "Mover",
                        LoC = 136,
                        NumOfMethods = 9,
                        NumOfAttributes = 12,
                        DuplicateCode = false,
                        NumOfPrivateAttributes = 12,
                        NumOfPrivateMethods = 0,
                    }
                }
            }
        }
    };

    // Total Scale of the Visualization
    public float TotalScale = 1f;
    // Depth of Visualization
    public float Depth = 5;
    // Border of each Level
    public float Border = 0.1f;
    // Height of each Level (if Height has no meaning)
    public float Height = 0.2f;

    // Color indicating bad Intimicy
    public Color BadIntimicyColor;
    // Color indicating good Intimicy
    public Color GoodIntimicyColor;
    // Color indicating no Duplicate Code
    public Color NoDuplicateCodeColor;
    // Color indicating Duplicate Code
    public Color HasDuplicateCodeColor;

    // Button for changing Visualization
    public PressableButtonHoloLens2 ChangeVisButton;
    // Button for changing Transparency
    public PressableButtonHoloLens2 ChangeTransparencyButton;

    public Image LegendBadIntimicyImage;
    public Image LegendGoodIntimicyImage;
    public Image LegendHasDuplicateCodeImage;
    public Image LegendHasNoDuplicateCodeImage;

    public GameObject LabelPrefab;
    
    void Start()
    {
        LegendBadIntimicyImage.color = BadIntimicyColor;
        LegendGoodIntimicyImage.color = GoodIntimicyColor;
        LegendHasDuplicateCodeImage.color = HasDuplicateCodeColor;
        LegendHasNoDuplicateCodeImage.color = NoDuplicateCodeColor;
        
        
        // Visualization GameObject of unrefactored Pacman for NeighbourVisualization
        var visnext = new GameObject("visRoot");
        // Position according to LOC
        visnext.transform.localPosition = new Vector3(-((Pacman.LoC/100f)*TotalScale / 2f + Border), -0.5f, 10*TotalScale);
        // Scale according to TotalScale
        visnext.transform.localScale = Vector3.one * TotalScale;
        // Rotation of 90° around y-axis to face the user
        visnext.transform.localRotation = Quaternion.AngleAxis(90,visnext.transform.up);
        
        var labelVis = GameObject.Instantiate(LabelPrefab);
        labelVis.transform.parent = visnext.transform;
        labelVis.transform.localScale = Vector3.one;
        labelVis.transform.localPosition = new Vector3(0, 10*Height, 0);
        labelVis.GetComponentInChildren<TMP_Text>().text = "unrefactored Pacman";
        labelVis.GetComponentInChildren<TMP_Text>().fontSize = 36;
        
        // Perform Project Visualization
        Pacman.Visualize(visnext);
        
        // Visualization GameObject of refactored Pacman for NeighbourVisualization
        var visnextRef = new GameObject("visnextRef");
        // Position according to LOC
        visnextRef.transform.localPosition = new Vector3(((Pacman.LoC/100f)*TotalScale / 2f + Border), -0.5f, 10*TotalScale);
        // Scale according to TotalScale
        visnextRef.transform.localScale = Vector3.one * TotalScale;
        // Rotation of 90° around y-axis to face the user
        visnextRef.transform.localRotation = Quaternion.AngleAxis(90,visnextRef.transform.up);
        // Perform Project Visualization
        PacmanRefactored.Visualize(visnextRef);
        
        labelVis = GameObject.Instantiate(LabelPrefab);
        labelVis.transform.parent = visnextRef.transform;
        labelVis.transform.localScale = Vector3.one;
        labelVis.transform.localPosition = new Vector3(0, 10*Height, 0);
        labelVis.GetComponentInChildren<TMP_Text>().text = "refactored Pacman";
        labelVis.GetComponentInChildren<TMP_Text>().fontSize = 36;
        
        // Visualization GameObject of unrefactored Pacman for TransparencyVisualization
        var visTrans = new GameObject("visTrans");
        // Position in front of the user
        visTrans.transform.localPosition = new Vector3(0, -0.5f, 10*TotalScale);
        // Scale according to TotalScale
        visTrans.transform.localScale = Vector3.one * TotalScale;
        // Rotation of 90° around y-axis to face the user
        visTrans.transform.localRotation = Quaternion.AngleAxis(90,visTrans.transform.up);
        // Perform Project Visualization
        Pacman.Visualize(visTrans);
        
        labelVis = GameObject.Instantiate(LabelPrefab);
        labelVis.transform.parent = visTrans.transform;
        labelVis.transform.localScale = Vector3.one;
        labelVis.transform.localPosition = new Vector3(0, 10*Height, 0);
        labelVis.GetComponentInChildren<TMP_Text>().text = "unrefactored Pacman";
        labelVis.GetComponentInChildren<TMP_Text>().fontSize = 36;
        
        // Initially making unrefactored Pacman Visualization Transparent
        foreach (var child in visTrans.GetComponentsInChildren<Renderer>())
        {
            // For each Renderer-Component in all children make Material 50% transparent
            var material = child.material;
            SetMaterialTransparent(material);
            material.color =
                new Color(child.material.color.r, material.color.g, material.color.b, 0.5f);
        }
        foreach (var child in visTrans.GetComponentsInChildren<TMP_Text>())
        {
            child.enabled = false;
        }
        
        // Initally disable Visualiation
        visTrans.gameObject.SetActive(false);
        
        // Visualization GameObject of refactored Pacman for TransparencyVisualization
        var visTransRef = new GameObject("visTransRef");
        // Position in front of the user
        visTransRef.transform.localPosition = new Vector3(0, -0.5f, 10*TotalScale);
        // Scale according to TotalScale
        visTransRef.transform.localScale = Vector3.one * TotalScale;
        // Rotation of 90° around y-axis to face the user
        visTransRef.transform.localRotation = Quaternion.AngleAxis(90,visTransRef.transform.up);
        // Perform Project Visualization
        PacmanRefactored.Visualize(visTransRef);
        
        labelVis = GameObject.Instantiate(LabelPrefab);
        labelVis.transform.parent = visTransRef.transform;
        labelVis.transform.localScale = Vector3.one;
        labelVis.transform.localPosition = new Vector3(0, 10*Height, 0);
        labelVis.GetComponentInChildren<TMP_Text>().text = "refactored Pacman";
        labelVis.GetComponentInChildren<TMP_Text>().fontSize = 36;
        
        // Initally disable Visualiation
        visTransRef.gameObject.SetActive(false);
        // Initally disable ChangeTransparencyButton, as NeighbourVisualization is enabled
        ChangeTransparencyButton.gameObject.SetActive(false);
        
        // Add Listener to ButtonPressed-Event for ChangeVisButton.
        ChangeVisButton.ButtonPressed.AddListener(() =>
        {
            // If NeighbourVisualization is enabled, disable it and enable TransparencyVisualization
            if (visnext.activeSelf)
            {
                visnext.SetActive(false);
                visnextRef.SetActive(false);
                visTrans.SetActive(true);
                visTransRef.SetActive(true);
                ChangeTransparencyButton.gameObject.SetActive(true);
            }
            // otherwise, the other way around
            else
            {
                visnext.SetActive(true);
                visnextRef.SetActive(true);
                visTrans.SetActive(false);
                visTransRef.SetActive(false);
                ChangeTransparencyButton.gameObject.SetActive(false);
            }
        });
        
        // Add Listener to ButtonPressed-Event for ChangeTransButton.
        ChangeTransparencyButton.ButtonPressed.AddListener(() =>
        {
            // If unrefactored Pacman is transparent, switch transparency.
            if (visTrans.GetComponentInChildren<Renderer>().material.renderQueue ==
                (int) UnityEngine.Rendering.RenderQueue.Transparent)
            {
                foreach (var child in visTrans.GetComponentsInChildren<Renderer>())
                {
                    var material = child.material;
                    SetMaterialOpaque(material);
                    material.color =
                        new Color(child.material.color.r, material.color.g, material.color.b, 1f);
                }
                foreach (var child in visTrans.GetComponentsInChildren<TMP_Text>())
                {
                    child.enabled = true;
                }
                foreach (var child in visTransRef.GetComponentsInChildren<Renderer>())
                {
                    var material = child.material;
                    SetMaterialTransparent(material);
                    material.color =
                        new Color(child.material.color.r, material.color.g, material.color.b, 0.5f);
                }
                foreach (var child in visTransRef.GetComponentsInChildren<TMP_Text>())
                {
                    child.enabled = false;
                }
            }
            // otherwise, the other way around
            else
            {
                foreach (var child in visTransRef.GetComponentsInChildren<Renderer>())
                {
                    var material = child.material;
                    SetMaterialOpaque(material);
                    material.color =
                        new Color(child.material.color.r, material.color.g, material.color.b, 1f);
                }
                foreach (var child in visTransRef.GetComponentsInChildren<TMP_Text>())
                {
                    child.enabled = true;
                }
                foreach (var child in visTrans.GetComponentsInChildren<Renderer>())
                {
                    var material = child.material;
                    SetMaterialTransparent(material);
                    material.color =
                        new Color(child.material.color.r, material.color.g, material.color.b, 0.5f);
                }
                foreach (var child in visTrans.GetComponentsInChildren<TMP_Text>())
                {
                    child.enabled = false;
                }
            }
        });
    }

    // Help method to change material to opaque
    private void SetMaterialOpaque(Material material)
    {
        material.SetOverrideTag("RenderType", "");
        material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.Zero);
        material.SetInt("_ZWrite", 1);
        material.DisableKeyword("_ALPHATEST_ON");
        material.DisableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = -1;
    }

    // Helpermethod to change material to transparent
    private void SetMaterialTransparent(Material material)
    {
        material.SetOverrideTag("RenderType", "Transparent");
        material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
    }
    
}
