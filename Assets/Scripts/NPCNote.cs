using UnityEngine;
using UnityEngine.UI;

public class NPCNote : MonoBehaviour
{
    [System.Serializable]
    public class NoteData
    {
        public string npcName;
        public int requiredLevel;     // Selesaikan level ini (misal: Level 1)
        public GameObject lockImage;  // Gambar gembok
        public Button npcButton;      // Tombol NPC
    }

    public NoteData[] notes;

    void Start()
    {
        // Jalankan pengecekan saat scene gallery dibuka
        RefreshNoteGallery();
    }

    public void RefreshNoteGallery()
    {
        // Ambil progress: default 1 jika belum ada data
        int levelTerbuka = PlayerPrefs.GetInt("levelTerbuka", 1);

        foreach (NoteData note in notes)
        {
            // Logika: Jika pemain sudah membuka level 2, artinya level 1 SUDAH SELESAI.
            // Maka, isUnlocked akan bernilai true.
            bool isUnlocked = levelTerbuka > note.requiredLevel;

            // Atur Gembok: Aktif jika terkunci, Nonaktif jika terbuka
            if (note.lockImage != null)
            {
                note.lockImage.SetActive(!isUnlocked);
            }

            // Atur Tombol: Ini bagian yang kamu minta
            if (note.npcButton != null)
            {
                // Jika isUnlocked = true, maka tombol bisa diklik
                // Jika isUnlocked = false, maka tombol mati (tidak bisa diklik)
                note.npcButton.interactable = isUnlocked;
            }
        }
    }
}