using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    // Dictionary untuk menyimpan panel berdasarkan nama
    private Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();

    [Header("Panel Settings")]
    public Transform panelsParent; // Parent objek yang menyimpan semua panel

    private GameObject activePanel; // Panel yang sedang aktif

    void Start()
    {
        // Inisialisasi semua panel dalam parent
        foreach (Transform child in panelsParent)
        {
            panels[child.name] = child.gameObject;
        }

        // Opsional: Nonaktifkan semua panel di awal kecuali panel pertama (index 0)
        foreach (var panel in panels.Values)
        {
            panel.SetActive(false);
        }

        if (panels.Count > 0)
        {
            activePanel = panels[panelsParent.GetChild(0).name];
            activePanel.SetActive(true);
        }
    }

    /// <summary>
    /// Pindah ke panel tertentu berdasarkan nama panel.
    /// </summary>
    /// <param name="panelName">Nama panel yang ingin diaktifkan.</param>
    public void SwitchToPanel(string panelName)
    {
        if (panels.ContainsKey(panelName))
        {
            if (activePanel != null)
            {
                activePanel.SetActive(false); // Nonaktifkan panel aktif saat ini
            }

            activePanel = panels[panelName];
            activePanel.SetActive(true); // Aktifkan panel baru
        }
        else
        {
            Debug.LogWarning($"Panel dengan nama {panelName} tidak ditemukan!");
        }
    }
}
