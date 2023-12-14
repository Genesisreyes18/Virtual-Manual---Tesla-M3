using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectManager : MonoBehaviour
{
    // Serializable class to hold both the GameObject and its description
    [System.Serializable]
    public class DescribedObject
    {
        public GameObject gameObject;
        public string description;
    }

    // List of described objects. You can add objects and their descriptions in the Unity Editor.
    public List<DescribedObject> describedObjects = new List<DescribedObject>();

    // Text Mesh Pro component to display the description
    public TextMeshProUGUI textComponent;

    void Start()
    {
        // Optional: Initialize with all objects active and no text
        ResetObjects();
    }

    // Focus on a specific object
    public void Focus(string objectName)
    {
        foreach (var describedObject in describedObjects)
        {
            // Check if the current object's name matches the provided name
            if (describedObject.gameObject.name == objectName)
            {
                // Set this object active and update the text
                describedObject.gameObject.SetActive(true);
                textComponent.text = describedObject.description;
            }
            else
            {
                // Deactivate all other objects
                describedObject.gameObject.SetActive(false);
            }
        }
    }

    // Reset to show all objects and clear the text
    public void ResetObjects()
    {
        foreach (var describedObject in describedObjects)
        {
            describedObject.gameObject.SetActive(true);
        }
        textComponent.text = "";
    }
}
