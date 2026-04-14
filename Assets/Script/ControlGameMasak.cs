using UnityEngine;
using System.Collections.Generic;

public class ControlGameMasak : MonoBehaviour
{
    public Animator piringMakanan;

    public GameObject nasi;
    public GameObject ikan;
    public GameObject ayam;
    public GameObject tempe;
    public GameObject sayur;
    public GameObject serundeng;
    public GameObject sambal;

    // SISTEM PEMBELI

    [Header("PEMBELI")]
    public Transform parentPembeli;

    public RectTransform[] titikResponPembeli; 
    public RectTransform[] titikPembeli;       

    public GameObject[] npcPrefabs;

    public int totalPembeli = 5;
    private int jumlahSpawn = 0;

    private bool[] titikTerisi;

    private List<GameObject> npcAktif = new List<GameObject>();
    private List<int> slotNPC = new List<int>();

    public float speed = 500f;
    public float delaySpawn = 2f;
    private float timer;

    void Start()
    {
        titikTerisi = new bool[titikPembeli.Length];
    }

    void Update()
    {
        SpawnPembeli();
        MoveNPC();
    }

    // =========================
    void SpawnPembeli()
    {
        if (jumlahSpawn >= totalPembeli) return;

        timer += Time.deltaTime;
        if (timer < delaySpawn) return;

        // pilih jalur (0 atau 1)
        int jalur = Random.Range(0, titikResponPembeli.Length);

        // ❗ kalau jalur itu sudah terisi → jangan spawn
        if (titikTerisi[jalur])
            return;

        timer = 0f;

        int randomNPC = Random.Range(0, npcPrefabs.Length);

        GameObject npc = Instantiate(npcPrefabs[randomNPC], parentPembeli);

        RectTransform rect = npc.GetComponent<RectTransform>();

        // spawn sesuai jalur
        rect.anchoredPosition = titikResponPembeli[jalur].anchoredPosition;

        npcAktif.Add(npc);
        slotNPC.Add(jalur);

        titikTerisi[jalur] = true;

        jumlahSpawn++;
    }

    // =========================
    void MoveNPC()
    {
        for (int i = 0; i < npcAktif.Count; i++)
        {
            if (npcAktif[i] == null) continue;

            RectTransform npc = npcAktif[i].GetComponent<RectTransform>();
            RectTransform target = titikPembeli[slotNPC[i]];

            npc.anchoredPosition = Vector2.MoveTowards(
                npc.anchoredPosition,
                target.anchoredPosition,
                speed * Time.deltaTime
            );
        }
    }

    // KOSONGKAN SLOT (NANTI DIPAKAI)
    public void PembeliSelesai(int index)
    {
        titikTerisi[slotNPC[index]] = false;

        Destroy(npcAktif[index]);

        npcAktif.RemoveAt(index);
        slotNPC.RemoveAt(index);
    }

    public void ButtonAnimation(Animator animatorButton)
    {
        animatorButton.Play("ButtonPressed", 0, 0f);
    }

    public void TambahMakanan(GameObject makanan)
    {
        if (!makanan.activeInHierarchy)
        {
            makanan.SetActive(true);
            ButtonAnimation(piringMakanan);
        }
    }

    public void HapusSemuaMakanan()
    {
        nasi.SetActive(false);
        ikan.SetActive(false);
        ayam.SetActive(false);
        tempe.SetActive(false);
        sayur.SetActive(false);
        serundeng.SetActive(false);
        sambal.SetActive(false);

        ButtonAnimation(piringMakanan);
    }
}