using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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

    // =========================
    // PEMBELI SYSTEM
    // =========================

    [Header("PEMBELI")]
    public RectTransform[] titikResponPembeli;
    public RectTransform[] titikStopPembeli;

    public GameObject prefabPembeli;
    public Transform parentPembeli;

    public Sprite[] spritePembelis;

    public int totalPembeli = 5;
    private int jumlahSpawn = 0;

    public float speedPembeli = 600f;
    public float delaySpawn = 2f;
    private float timer;

    private bool[] titikTerisi;

    private List<GameObject> npcAktif = new List<GameObject>();
    private List<int> jalurNPC = new List<int>();
    private List<bool> sudahSampai = new List<bool>(); 

    // =========================

    void Start()
    {
        titikTerisi = new bool[titikStopPembeli.Length];
    }

    void Update()
    {
        SpawnPembeli();
        MovePembeli();
    }

    // =========================
    void SpawnPembeli()
    {
        if (jumlahSpawn >= totalPembeli) return;

        timer += Time.deltaTime;
        if (timer < delaySpawn) return;

        int jalur = Random.Range(0, titikResponPembeli.Length);

        if (titikTerisi[jalur]) return;

        timer = 0f;

        GameObject npc = Instantiate(prefabPembeli, parentPembeli);

        RectTransform rect = npc.GetComponent<RectTransform>();
        rect.anchoredPosition = titikResponPembeli[jalur].anchoredPosition;

        // RANDOM SPRITE
        Image img = npc.GetComponent<Image>();
        if (img != null && spritePembelis.Length > 0)
        {
            int randomSprite = Random.Range(0, spritePembelis.Length);
            img.sprite = spritePembelis[randomSprite];
        }

        // ANIMASI JALAN
        Animator anim = npc.GetComponent<Animator>();
        if (anim != null)
        {
            anim.SetBool("isJalan", true);
        }

        // MATIKAN MENU SAAT AWAL
        Transform menu = npc.transform.Find("Menu");
        if (menu != null)
        {
            menu.gameObject.SetActive(false);
        }

        npcAktif.Add(npc);
        jalurNPC.Add(jalur);
        sudahSampai.Add(false);

        titikTerisi[jalur] = true;

        jumlahSpawn++;
    }

    // =========================
    void MovePembeli()
    {
        for (int i = 0; i < npcAktif.Count; i++)
        {
            if (npcAktif[i] == null) continue;

            RectTransform npc = npcAktif[i].GetComponent<RectTransform>();
            RectTransform target = titikStopPembeli[jalurNPC[i]];

            npc.anchoredPosition = Vector2.MoveTowards(
                npc.anchoredPosition,
                target.anchoredPosition,
                speedPembeli * Time.deltaTime
            );

            // =========================
            // SAAT SAMPAI
            // =========================
            if (!sudahSampai[i] &&
                Vector2.Distance(npc.anchoredPosition, target.anchoredPosition) < 1f)
            {
                sudahSampai[i] = true;

                // STOP ANIMASI
                Animator anim = npcAktif[i].GetComponent<Animator>();
                if (anim != null)
                {
                    anim.SetBool("isJalan", false);
                }

                // AKTIFKAN MENU
                Transform menu = npcAktif[i].transform.Find("Menu");
                if (menu != null)
                {
                    menu.gameObject.SetActive(true);
                }
            }
        }
    }

    // =========================
    public void PembeliSelesai(int index)
    {
        titikTerisi[jalurNPC[index]] = false;

        Destroy(npcAktif[index]);

        npcAktif.RemoveAt(index);
        jalurNPC.RemoveAt(index);
        sudahSampai.RemoveAt(index);
    }

    // =========================
    // FUNGSI LAMA (TIDAK DIUBAH)
    // =========================

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