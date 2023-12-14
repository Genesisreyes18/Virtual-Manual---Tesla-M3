//Object Manager
using System.Collections.Generic; // Provides classes for creating generic collections like List<T>.
using UnityEngine; // Core namespace for Unity engine, providing access to common Unity classes
using TMPro;  // Namespace for TextMesh Pro, a tool for advanced text rendering in Unity.
//The ObjectManager class manages a collection of objects and their descriptions in a Unity scene.
public class ObjectManager : MonoBehaviour
{
 // A nested class representing a GameObject and its associated text description
    [System.Serializable] // This attribute makes the class visible in the Unity Editor.
    public class DescribedObject
    {
        public GameObject gameObject;  // Stores a reference to the GameObject in the scene
        public string description;  // Stores the text description of the GameObject
    }
    // List of described objects. We can add objects and their descriptions in the Unity Editor
    public List<DescribedObject> describedObjects = new List<DescribedObject>();

      // A reference to a TextMeshProUGUI component, used for displaying the descriptions on the UI (the menu clickable)
    public TextMeshProUGUI textComponent;
    void Start()
    {
        // Initialize with all objects active and no text
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

