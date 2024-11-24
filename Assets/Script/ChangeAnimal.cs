using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeAnimal : MonoBehaviour
{
    public Button buttonKiri; // Tombol untuk berpindah ke kiri
    public Button buttonKanan; // Tombol untuk berpindah ke kanan
    public GameObject[] objects;
    public int indexObject;

    // Array of animal names and descriptions
    public string[] animalNames;
    public string[] animalDescriptions;

    // Reference to UI Text elements
    public Text animalNameText;
    public Text animalDescriptionText;

    // Reference to the panel that contains name and description
    public GameObject panelAnimalInfo;

    void Start()
    {
        UpdateAnimalInfo();
        panelAnimalInfo.SetActive(false); // Initially hide the panel
    }

    void Update()
    {
        // Optional update if needed
    }

    public void ButtonKiri()
    {
        Debug.Log("Kiri");

        objects[indexObject].SetActive(false);

        indexObject -= 1;

        if (indexObject < 0)
        {
            indexObject = objects.Length - 1;
        }

        objects[indexObject].SetActive(true);

        // Update the displayed animal name and description
        UpdateAnimalInfo();
    }

    public void ButtonKanan()
    {
        Debug.Log("Kanan");

        objects[indexObject].SetActive(false);

        indexObject += 1;

        if (indexObject == objects.Length)
        {
            indexObject = 0;
        }

        objects[indexObject].SetActive(true);

        // Update the displayed animal name and description
        UpdateAnimalInfo();
    }

    // Method to update the animal name and description based on the active object
    private void UpdateAnimalInfo()
    {
        if (indexObject >= 0 && indexObject < animalNames.Length)
        {
            animalNameText.text = animalNames[indexObject];
            animalDescriptionText.text = animalDescriptions[indexObject];
        }
        else
        {
            Debug.LogWarning("Index out of range for animal names or descriptions.");
        }
    }

    public void OnTargetAnimal()
    {
        // Show panel and enable buttons when the marker is detected
        panelAnimalInfo.SetActive(true); // Show the panel
        buttonKiri.interactable = true;
        buttonKanan.interactable = true;
    }

    public void OnTargetLoss()
    {
        // Hide panel and disable buttons when the marker is lost
        panelAnimalInfo.SetActive(false); // Hide the panel
        buttonKiri.interactable = false;
        buttonKanan.interactable = false;
    }
}
