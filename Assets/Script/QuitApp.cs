using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    /// <summary>
    /// Fungsi untuk keluar dari aplikasi.
    /// </summary>
    public void QuitApplication()
    {
        #if UNITY_EDITOR
        // Jika dalam mode editor, hentikan play mode
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Jika dalam build, keluar dari aplikasi
        Application.Quit();
        #endif
    }
}
