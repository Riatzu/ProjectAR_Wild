using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panel Settings")]
    public List<GameObject> panels; // Daftar panel yang bisa diaktifkan
    private GameObject activePanel; // Panel yang sedang aktif

    [Header("Scene Settings")]
    public List<string> scenes; // Daftar nama scene yang tersedia

    private void Start()
    {
        if (panels.Count > 0)
        {
            // Pastikan hanya panel pertama yang aktif saat awal
            foreach (var panel in panels)
            {
                panel.SetActive(false);
            }
            activePanel = panels[0];
            activePanel.SetActive(true);
        }
    }

    /// <summary>
    /// Pindah ke panel tertentu berdasarkan index.
    /// </summary>
    /// <param name="panelIndex">Index dari panel yang ingin diaktifkan.</param>
    public void SwitchPanel(int panelIndex)
    {
        if (panelIndex >= 0 && panelIndex < panels.Count)
        {
            activePanel.SetActive(false); // Nonaktifkan panel aktif saat ini
            activePanel = panels[panelIndex];
            activePanel.SetActive(true); // Aktifkan panel baru
        }
        else
        {
            Debug.LogWarning("Panel index out of range!");
        }
    }

    /// <summary>
    /// Pindah ke scene tertentu berdasarkan nama.
    /// </summary>
    /// <param name="sceneName">Nama scene yang ingin diaktifkan.</param>
    public void SwitchScene(string sceneName)
    {
        if (scenes.Contains(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name not found in the list!");
        }
    }
}
