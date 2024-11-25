using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeAnimal : MonoBehaviour
{
    public Button buttonKiri; // Tombol untuk berpindah ke kiri
    public Button buttonKanan; // Tombol untuk berpindah ke kanan
    public Button buttonSound; // Tombol untuk memainkan suara hewan
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

    // Array for animal sounds
    public AudioClip[] animalSounds;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Assign button click listener
        buttonSound.onClick.AddListener(PlayAnimalSound);

        UpdateAnimalInfo();
        panelAnimalInfo.SetActive(false); // Initially hide the panel
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

        // Update the displayed animal name, description, and sound
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

        // Update the displayed animal name, description, and sound
        UpdateAnimalInfo();
    }

    // Method to update the animal name, description, and play sound
    private void UpdateAnimalInfo()
    {
        if (indexObject >= 0 && indexObject < animalNames.Length)
        {
            animalNameText.text = animalNames[indexObject];
            animalDescriptionText.text = animalDescriptions[indexObject];

            // Play the corresponding animal sound
            if (indexObject >= 0 && indexObject < animalSounds.Length && animalSounds[indexObject] != null)
            {
                audioSource.clip = animalSounds[indexObject];
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("Index out of range for animal names, descriptions, or sounds.");
        }
    }

    public void OnTargetAnimal()
    {
        // Show panel and enable buttons when the marker is detected
        panelAnimalInfo.SetActive(true); // Show the panel
        buttonKiri.interactable = true;
        buttonKanan.interactable = true;
        buttonSound.interactable = true;

        // Play the current animal sound when detected
        if (indexObject >= 0 && indexObject < animalSounds.Length && animalSounds[indexObject] != null)
        {
            audioSource.clip = animalSounds[indexObject];
            audioSource.Play();
        }
    }

    public void OnTargetLoss()
    {
        // Hide panel and disable buttons when the marker is lost
        panelAnimalInfo.SetActive(false); // Hide the panel
        buttonKiri.interactable = false;
        buttonKanan.interactable = false;
        buttonSound.interactable = false;

        // Stop playing the sound when marker is lost
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Clear the text fields
        animalNameText.text = "";
        animalDescriptionText.text = "";
    }

    // Method to play animal sound on button click
    private void PlayAnimalSound()
    {
        if (indexObject >= 0 && indexObject < animalSounds.Length && animalSounds[indexObject] != null)
        {
            audioSource.clip = animalSounds[indexObject];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No sound available for the current animal.");
        }
    }
}
