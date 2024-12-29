using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAnimal : MonoBehaviour
{
    public Button buttonKiri; // Tombol untuk berpindah ke kiri
    public Button buttonKanan; // Tombol untuk berpindah ke kanan
    public Button buttonSound; // Tombol untuk memainkan suara hewan
    public GameObject[] objects;
    public int indexObject;

    // Array untuk gambar UI hewan
    public Sprite[] animalImages;

    // Reference ke komponen UI Image
    public Image animalImageUI;

    // Panel informasi hewan
    public GameObject panelAnimalInfo;

    // Array untuk suara hewan
    public AudioClip[] animalSounds;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Assign button click listener
        buttonSound.onClick.AddListener(PlayAnimalSound);
        buttonKiri.onClick.AddListener(() => StopAnimalSound());
        buttonKanan.onClick.AddListener(() => StopAnimalSound());

        UpdateAnimalInfo();
        panelAnimalInfo.SetActive(false); // Sembunyikan panel pada awalnya

        // Pastikan suara tidak aktif saat game dimulai
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void Update()
    {
        RotateObject(); // Panggil rotasi setiap frame
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

        // Update informasi hewan
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

        // Update informasi hewan
        UpdateAnimalInfo();
    }

    // Method untuk mengupdate gambar dan suara hewan
    private void UpdateAnimalInfo()
    {
        if (indexObject >= 0 && indexObject < animalImages.Length)
        {
            // Update gambar UI
            animalImageUI.sprite = animalImages[indexObject];
        }
        else
        {
            Debug.LogWarning("Index out of range untuk gambar hewan.");
        }
    }

    public void OnTargetAnimal()
    {
        // Tampilkan panel dan aktifkan tombol saat marker terdeteksi
        panelAnimalInfo.SetActive(true);
        buttonKiri.interactable = true;
        buttonKanan.interactable = true;
        buttonSound.interactable = true;
    }

    public void OnTargetLoss()
    {
        // Sembunyikan panel dan nonaktifkan tombol saat marker hilang
        panelAnimalInfo.SetActive(false);
        buttonKiri.interactable = false;
        buttonKanan.interactable = false;
        buttonSound.interactable = false;

        // Hentikan suara saat marker hilang
        StopAnimalSound();

        // Hapus gambar dari UI
        animalImageUI.sprite = null;
    }

    // Method untuk memainkan suara hewan saat tombol diklik
    private void PlayAnimalSound()
    {
        if (indexObject >= 0 && indexObject < animalSounds.Length && animalSounds[indexObject] != null)
        {
            audioSource.clip = animalSounds[indexObject];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Tidak ada suara untuk hewan saat ini.");
        }
    }

    // Method untuk menghentikan suara hewan
    private void StopAnimalSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Method untuk merotasi objek di sepanjang sumbu Z
    private void RotateObject()
    {
        if (objects[indexObject] != null)
        {
            objects[indexObject].transform.Rotate(Vector3.down * 15 * Time.deltaTime);
        }
    }
}
