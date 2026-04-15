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
    private List<bool> sudahPergi = new List<bool>();

    [Header("Pesan Makanan")]
    public List<string> pesanMakanan = new List<string>();

    [Header("MEJA PLAYER")]
    public Transform makanan;

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

        Image img = npc.GetComponent<Image>();
        if (img != null && spritePembelis.Length > 0)
        {
            img.sprite = spritePembelis[Random.Range(0, spritePembelis.Length)];
        }

        Animator anim = npc.GetComponent<Animator>();
        if (anim != null)
        {
            anim.SetBool("isJalan", true);
        }

        Transform menu = npc.transform.Find("Menu");
        if (menu != null)
        {
            menu.gameObject.SetActive(false);
        }

        npcAktif.Add(npc);
        jalurNPC.Add(jalur);
        sudahSampai.Add(false);
        sudahPergi.Add(false);

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

            if (!sudahPergi[i])
            {
                RectTransform target = titikStopPembeli[jalurNPC[i]];

                npc.anchoredPosition = Vector2.MoveTowards(
                    npc.anchoredPosition,
                    target.anchoredPosition,
                    speedPembeli * Time.deltaTime
                );

                if (!sudahSampai[i] &&
                    Vector2.Distance(npc.anchoredPosition, target.anchoredPosition) < 1f)
                {
                    sudahSampai[i] = true;

                    npc.GetComponent<Animator>().SetBool("isJalan", false);

                    Transform menu = npc.transform.Find("Menu");
                    if (menu != null)
                    {
                        menu.gameObject.SetActive(true);

                        string pesanan = RandomMenu(menu);

                        if (i < pesanMakanan.Count)
                            pesanMakanan[i] = pesanan;
                        else
                            pesanMakanan.Add(pesanan);
                    }
                }
            }
            else
            {
                RectTransform target = titikResponPembeli[jalurNPC[i]];

                npc.anchoredPosition = Vector2.MoveTowards(
                    npc.anchoredPosition,
                    target.anchoredPosition,
                    speedPembeli * Time.deltaTime
                );

                if (Vector2.Distance(npc.anchoredPosition, target.anchoredPosition) < 1f)
                {
                    PembeliSelesai(i);
                    break;
                }
            }
        }
    }

    // =========================
    string RandomMenu(Transform menu)
    {
        List<string> hasil = new List<string>();

        Transform makanan = menu.Find("makanan");

        foreach (Transform item in makanan)
            item.gameObject.SetActive(false);

        makanan.Find("piring").gameObject.SetActive(true);
        makanan.Find("nasi").gameObject.SetActive(true);
        makanan.Find("ikan").gameObject.SetActive(true);

        hasil.Add("piring");
        hasil.Add("nasi");
        hasil.Add("ikan");

        string[] lauk = { "tempe", "ayam", "sayur", "sambal", "serundeng" };

        int jumlah = Random.Range(1, 3);

        for (int i = 0; i < jumlah; i++)
        {
            int r = Random.Range(0, lauk.Length);
            makanan.Find(lauk[r]).gameObject.SetActive(true);
            hasil.Add(lauk[r]);
        }

        return string.Join(", ", hasil);
    }

    // =========================
    bool IsThereSameMakanan(int index)
    {
        if (index >= npcAktif.Count) return false;

        Transform menuPembeli = npcAktif[index].transform.Find("Menu/makanan");

        for (int j = 0; j < makanan.childCount; j++)
        {
            bool playerActive = makanan.GetChild(j).gameObject.activeSelf;
            bool npcActive = menuPembeli.GetChild(j).gameObject.activeSelf;

            if (playerActive != npcActive)
                return false;

            if (playerActive)
            {
                Sprite s1 = makanan.GetChild(j).GetComponent<Image>().sprite;
                Sprite s2 = menuPembeli.GetChild(j).GetComponent<Image>().sprite;

                if (s1 != s2)
                    return false;
            }
        }

        return true;
    }

    // =========================
    public void ButtonSendMakanan()
    {
        for (int i = 0; i < npcAktif.Count; i++)
        {
            if (!sudahSampai[i] || sudahPergi[i]) continue;

            if (IsThereSameMakanan(i))
            {
                Debug.Log("KIRIM KE PEMBELI: " + i);

                Transform menu = npcAktif[i].transform.Find("Menu");
                if (menu != null)
                    menu.gameObject.SetActive(false);

                sudahPergi[i] = true;

                Animator anim = npcAktif[i].GetComponent<Animator>();
if (anim != null)
{
    anim.SetBool("isJalan", true);
}

                if (i < pesanMakanan.Count)
                    pesanMakanan.RemoveAt(i);

                // 🔥 TAMBAHAN RESET
                ResetMakananKeAwal();

                return;
            }
        }

        Debug.Log("SALAH PESANAN");
    }

    // =========================
    void ResetMakananKeAwal()
    {
        // reset semua makanan player
        HapusSemuaMakanan();

        // animasi biar terasa reset
        ButtonAnimation(piringMakanan);

        Debug.Log("Makanan di-reset ke awal");
    }

    // =========================
    public void PembeliSelesai(int index)
    {
        if (index >= npcAktif.Count) return;

        titikTerisi[jalurNPC[index]] = false;

        Destroy(npcAktif[index]);

        npcAktif.RemoveAt(index);
        jalurNPC.RemoveAt(index);
        sudahSampai.RemoveAt(index);
        sudahPergi.RemoveAt(index);

        if (index < pesanMakanan.Count)
            pesanMakanan.RemoveAt(index);
    }

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