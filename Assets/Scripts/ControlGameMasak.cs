using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelData
{
    public int level;
    public int totalPembeli;
    public Sprite gambarGagal;
}

[System.Serializable]
public class SpecialNPCData
{
    public int level;
    public Sprite sprite;
    public GameObject prefabDialog;
}

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

    private int jumlahSpawn = 0;

    public float speedPembeli = 600f;
    public float delaySpawn = 2f;
    private float timer;

    private bool[] titikTerisi;

    private List<GameObject> npcAktif = new List<GameObject>();
    private List<int> jalurNPC = new List<int>();
    private List<bool> sudahSampai = new List<bool>();
    private List<bool> sudahPergi = new List<bool>();

    private List<bool> pembeliKabur = new List<bool>();

    [Header("NPC SPECIAL")]
    public GameObject prefabNPCSpecial; 
    public List<SpecialNPCData> specialNPCDatas = new List<SpecialNPCData>();

    private bool isSpecialSpawned = false;
    private GameObject currentSpecialNPC;
    private bool isSpecialServed = false;

    
    [Header("Pesan Makanan")]
    public List<string> pesanMakanan = new List<string>();

    [Header("MEJA PLAYER")]
    public Transform makanan;

    [Header("GAME OVER")]
    public GameObject panelGameOver;
    public Image gambarGagalImage;
    private bool isGameOver = false; 
    
    [Header("DEBUG PEMBELI")]
    [SerializeField] private int countSisaPembeli;
    private int jumlahDilayani = 0;

    [Header("UI SISA PEMBELI")]
    public TextMeshProUGUI textTotalPembeli; 

    [Header("UI CLOSE")]
    public GameObject tombolClose;

    [Header("DIALOG SPECIAL UI")]
    public GameObject uiDialogSpecial;

    [Header("UI PAUSE")]
    public GameObject panelPause;

    [Header("LEVEL SYSTEM")]
    public int level = 1;

    [Header("LEVEL CONFIG")]
    public List<LevelData> levelDatas = new List<LevelData>();
    private int totalPembeli;
    private int totalTarget; 
    private int jumlahSpawnTotal;


    [Header("BUTTON MAKANAN")]
    public GameObject buttonNasi;
    public GameObject buttonIkan;
    public GameObject buttonSerundeng;
    public GameObject buttonSambal;
    public GameObject buttonTempe;
    public GameObject buttonSayur;
    public GameObject buttonAyam;

    [Header("TIMER PEMBELI")]
    public float maxTime = 10f;

    public bool[] isTimerActive = new bool[2];
    public float[] currentTime = new float[2];
    public Slider[] sliderTimer = new Slider[2];

    private GameObject[] npcSlot = new GameObject[2];

    [Header("MOVE MAKANAN")]
    public bool isStartMoveMakanan;
    public float speedMoveMakanan = 1500f;
    public RectTransform targetMoveMakanan;

    private RectTransform makananRect;
    private Vector2 posisiAwal;

    int indexMakananAktif = -1;

    void Start()
    {
        level = PlayerPrefs.GetInt("levelDipilih", 1);
        UpdateButtonByLevel();
        SetTotalPembeliByLevel();
        titikTerisi = new bool[titikStopPembeli.Length];

        makananRect = makanan.GetComponent<RectTransform>();
        posisiAwal = makananRect.anchoredPosition;

        for (int i = 0; i < 2; i++)
        {
            currentTime[i] = maxTime;
            isTimerActive[i] = false;
        }
        if (panelGameOver != null)
            panelGameOver.SetActive(false); 
    }

    void SetTotalPembeliByLevel()
{
    foreach (LevelData data in levelDatas)
    {
        if (data.level == level)
        {
            totalPembeli = data.totalPembeli;
            totalTarget = totalPembeli + 1; 
            return;
        }
    }

    totalPembeli = 3;
    totalTarget = totalPembeli + 1;
}

    void Update()
    {
        if (isGameOver) return; 

        SpawnPembeli();
        MovePembeli();
        MoveMakanan();
        UpdateTimerSlot();
        UpdateSisaPembeli();
        CheckSpawnSpecial();
    }

    void CheckLevelUp()
{

    if (jumlahDilayani >= totalPembeli && jumlahSpawn >= totalPembeli)
    {
        level++;

        Debug.Log("NAIK LEVEL: " + level);

        jumlahDilayani = 0;
        jumlahSpawn = 0;

        SetTotalPembeliByLevel();
        UpdateButtonByLevel();
    }
}

    void UpdateButtonByLevel()
{

    buttonNasi.SetActive(true);
    buttonIkan.SetActive(true);

    buttonSerundeng.SetActive(level >= 1);
    buttonSambal.SetActive(level >= 2);
    buttonTempe.SetActive(level >= 3);
    buttonSayur.SetActive(level >= 4);
    buttonAyam.SetActive(level >= 5);
}

    void UpdateUnlockMakanan()
{
    nasi.SetActive(true);
    ikan.SetActive(true);

    ayam.SetActive(false);
    tempe.SetActive(false);
    sayur.SetActive(false);
    serundeng.SetActive(false);
    sambal.SetActive(false);

    if (level >= 1)
        serundeng.SetActive(true);

    if (level >= 2)
        sambal.SetActive(true);

    if (level >= 3)
        tempe.SetActive(true);

    if (level >= 4)
        sayur.SetActive(true);

    if (level >= 5)
        ayam.SetActive(true);
}

    void TriggerGameOver() 
{
    if (isGameOver) return;

    isGameOver = true;

    if (AudioManager.instance != null)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.gameOver);
    }

    Debug.Log("GAME OVER!");

    LevelData data = levelDatas.Find(x => x.level == level);

    if (data != null && gambarGagalImage != null)
    {
        gambarGagalImage.sprite = data.gambarGagal;
    }
    else
    {
        Debug.LogWarning("Gambar gagal tidak ditemukan untuk level " + level);
    }

    if (panelGameOver != null)
        panelGameOver.SetActive(true);

    Time.timeScale = 0f;
}

    void UpdateSisaPembeli()
{
    countSisaPembeli = totalTarget - jumlahSpawnTotal;

    if (countSisaPembeli < 0)
        countSisaPembeli = 0;

    if (textTotalPembeli != null)
    {
        textTotalPembeli.text = countSisaPembeli.ToString();
    }

    if (tombolClose != null)
    {
        tombolClose.SetActive(countSisaPembeli == 0);
    }
}

    void UpdateTimerSlot()
    {

        for (int i = 0; i < 2; i++)
        {
            if (!isTimerActive[i]) continue;
            if (npcSlot[i] == null) continue;

            currentTime[i] -= Time.deltaTime;

            if (sliderTimer[i] != null)
            {
                sliderTimer[i].value = currentTime[i];

if (currentTime[i] <= maxTime * 0.5f)
{
    Image fill = sliderTimer[i].fillRect.GetComponent<Image>();
    if (fill != null)
    {
        fill.color = Color.red;
    }
}
            }

            if (currentTime[i] <= 0)
{
    Debug.Log("Slot " + i + " kabur!");

    isTimerActive[i] = false;
    currentTime[i] = 0;

    int index = npcAktif.IndexOf(npcSlot[i]);
    if (index != -1)
    {
        sudahPergi[index] = true;
        pembeliKabur[index] = true; 

        Transform menu = npcAktif[index].transform.Find("Menu");
        if (menu != null)
        {
            menu.gameObject.SetActive(false);
        }

        Animator anim = npcAktif[index].GetComponent<Animator>();
        if (anim != null)
        {
            anim.SetBool("isJalan", true);
        }
    }
}
        }
    }
   
    void MoveMakanan()
    {
        if (!isStartMoveMakanan || targetMoveMakanan == null) return;

        Vector3 worldTarget = targetMoveMakanan.position;

        Vector2 targetPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            makananRect.parent as RectTransform,
            RectTransformUtility.WorldToScreenPoint(null, worldTarget),
            null,
            out targetPos
        );

        makananRect.anchoredPosition = Vector2.MoveTowards(
            makananRect.anchoredPosition,
            targetPos,
            speedMoveMakanan * Time.deltaTime
        );

        if (Vector2.Distance(makananRect.anchoredPosition, targetPos) < 5f)
        {
            isStartMoveMakanan = false;
            makananRect.anchoredPosition = posisiAwal;
        }
    }

    IEnumerator TungguMakananSampai()
    {
        while (isStartMoveMakanan)
        {
            yield return null;
        }

        if (indexMakananAktif >= 0 && indexMakananAktif < npcAktif.Count)
        {
            Transform menu = npcAktif[indexMakananAktif].transform.Find("Menu");

if (npcAktif[indexMakananAktif] == currentSpecialNPC)
{
    // SPECIAL → JANGAN MATIKAN MENU
}
else
{
    // NPC BIASA → MATIKAN MENU
    if (menu != null)
        menu.gameObject.SetActive(false);
}

            ResetMakananKeAwal();

            yield return new WaitForSeconds(0.2f);

            jumlahDilayani++;
            
            if (npcAktif[indexMakananAktif] == currentSpecialNPC)
{
    isSpecialServed = true;

    ShowDialogSpecial();

    yield break; 
}
else
{
    sudahPergi[indexMakananAktif] = true;
}

            int slot = jalurNPC[indexMakananAktif];
            if (slot < 2)
            {
                isTimerActive[slot] = false;
            }

            Animator anim = npcAktif[indexMakananAktif].GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetBool("isJalan", true);
            }
        }

        indexMakananAktif = -1;

    }

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
        pembeliKabur.Add(false); 

        titikTerisi[jalur] = true;
        jumlahSpawn++;
        jumlahSpawnTotal++;

        if (jalur < 2)
        {
            npcSlot[jalur] = npc;
        }
    }

    void SpawnSpecialNPC(int jalur)
{
    SpecialNPCData data = specialNPCDatas.Find(x => x.level == level);

    if (data == null)
    {
        Debug.LogWarning("Special NPC tidak ada di level " + level);
        return;
    }

    GameObject npc = Instantiate(prefabNPCSpecial, parentPembeli);
    currentSpecialNPC = npc;

    RectTransform rect = npc.GetComponent<RectTransform>();
    rect.anchoredPosition = titikResponPembeli[jalur].anchoredPosition;

    Image img = npc.GetComponent<Image>();
    if (img != null && data.sprite != null)
    {
        img.sprite = data.sprite;
    }

    Animator anim = npc.GetComponent<Animator>();
    if (anim != null)
    {
        anim.SetBool("isJalan", true);
    }

    Transform menu = npc.transform.Find("Menu");
    if (menu != null)
        menu.gameObject.SetActive(false);

    npcAktif.Add(npc);
    jalurNPC.Add(jalur);
    sudahSampai.Add(false);
    sudahPergi.Add(false);
    pembeliKabur.Add(false);

    titikTerisi[jalur] = true;

    if (jalur < 2)
    {
        npcSlot[jalur] = npc;
    }

    jumlahSpawnTotal++;
    isSpecialSpawned = true;

    Debug.Log("SPECIAL NPC SPAWN DI SLOT: " + jalur);
}

    void CheckSpawnSpecial()
{
    if (isSpecialSpawned) return;

    if (jumlahSpawn >= totalPembeli)
    {
        for (int i = 0; i < titikTerisi.Length; i++)
        {
            if (!titikTerisi[i]) 
            {
                SpawnSpecialNPC(i); 
                break;
            }
        }
    }
}

    void ShowDialogSpecial()
{
    if (currentSpecialNPC == null) return;

    Animator anim = currentSpecialNPC.GetComponent<Animator>();
    if (anim != null)
    {
        anim.SetBool("isJalan", false);
        anim.enabled = false;
    }

    Transform menu = currentSpecialNPC.transform.Find("Menu");
    if (menu == null)
    {
        Debug.LogError("Menu tidak ditemukan!");
        return;
    }

    Transform makanan = menu.Find("makanan");
    if (makanan != null)
        makanan.gameObject.SetActive(false);

    Transform slider = menu.Find("Slider");
    if (slider != null)
        slider.gameObject.SetActive(false);

    menu.gameObject.SetActive(false);

    Transform dialog = currentSpecialNPC.transform.Find("Button dialog");

if (dialog != null)
{
    Button btn = dialog.GetComponent<Button>();

    if (btn != null)
    {
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(BukaDialogSpecial);
    }

    dialog.gameObject.SetActive(true);
}
}
    
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

                        string pesanan;

if (npcAktif[i] == currentSpecialNPC)
{
    pesanan = RandomMenu(menu); 
}
else
{
    pesanan = RandomMenu(menu);
}

                        if (i < pesanMakanan.Count)
                            pesanMakanan[i] = pesanan;
                        else
                            pesanMakanan.Add(pesanan);

int slot = jalurNPC[i];

                        if (slot < 2)
                        {
                            isTimerActive[slot] = true;
                            currentTime[slot] = maxTime;

                            Slider s = menu.GetComponentInChildren<Slider>();
                            sliderTimer[slot] = s;

                            if (s != null)
                            {
                                s.maxValue = maxTime;
                                s.value = maxTime;
                            }
                        }
                    }
                }
            }
            else
{

    if (npcAktif[i] == currentSpecialNPC && isSpecialServed)
    {
        continue;
    }

    RectTransform target = titikResponPembeli[jalurNPC[i]];

                npc.anchoredPosition = Vector2.MoveTowards(
                    npc.anchoredPosition,
                    target.anchoredPosition,
                    speedPembeli * Time.deltaTime
                );

                if (Vector2.Distance(npc.anchoredPosition, target.anchoredPosition) < 1f)
                {
                    if (pembeliKabur[i]) 
                    {
                        TriggerGameOver();
                    }

                    PembeliSelesai(i);
                    break;
                }
            }
        }
    }

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


    List<string> lauk = GetLaukByLevel();

    int jumlah = Random.Range(0, Mathf.Min(level + 1, lauk.Count + 1));

    for (int i = 0; i < jumlah; i++)
    {
        if (lauk.Count == 0) break;

        int r = Random.Range(0, lauk.Count);

        string item = lauk[r];

        makanan.Find(item).gameObject.SetActive(true);
        hasil.Add(item);

        lauk.RemoveAt(r); 
    }

    return string.Join(", ", hasil);
}

    List<string> GetLaukByLevel()
{
    List<string> laukAktif = new List<string>();

    if (level >= 1)
        laukAktif.Add("serundeng");

    if (level >= 2)
        laukAktif.Add("sambal");

    if (level >= 3)
        laukAktif.Add("tempe");

    if (level >= 4)
        laukAktif.Add("sayur");

    if (level >= 5)
        laukAktif.Add("ayam");

    return laukAktif;
}

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

    public void ButtonPause()
{
    if (AudioManager.instance != null)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
    }

    Time.timeScale = 0f; 

    if (panelPause != null)
    {
        panelPause.SetActive(true); 
    }
}

    public void ButtonLanjut()
{
    if (AudioManager.instance != null)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
    }

    Time.timeScale = 1f; 

    if (panelPause != null)
    {
        panelPause.SetActive(false); 
    }
}

    public void ButtonRetry()
{
    if (AudioManager.instance != null)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
    }

    Time.timeScale = 1f; 
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

    public void ButtonMainMenu()
{
    if (AudioManager.instance != null)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
    }

    Time.timeScale = 1f; 

    SceneManager.LoadScene(0); 
}

    public void BukaDialogSpecial()
{
    if (AudioManager.instance != null)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
    }

    SpecialNPCData data = specialNPCDatas.Find(x => x.level == level);

    if (data == null)
    {
        Debug.LogError("Data level tidak ditemukan!");
        return;
    }

    if (data.prefabDialog == null)
    {
        Debug.LogError("Prefab dialog belum diisi!");
        return;
    }

    // Buat objek dari prefab
    GameObject dialogBaru = Instantiate(data.prefabDialog);
    
    // Pastikan objek tersebut aktif agar muncul di layar
    dialogBaru.SetActive(true);
}

    public void ButtonSendMakanan()
    {
        for (int i = 0; i < npcAktif.Count; i++)
        {
            if (!sudahSampai[i] || sudahPergi[i]) continue;

            if (npcAktif[i] == currentSpecialNPC && isSpecialServed)
        {
            Debug.Log("Special NPC sudah masuk dialog, tidak bisa dikirim makanan lagi!");
            continue;
        }

            if (IsThereSameMakanan(i))
            {
                Debug.Log("KIRIM KE PEMBELI: " + i);

                Transform targetMenu = npcAktif[i].transform.Find("Menu/makanan");
                if (targetMenu != null)
                {
                    targetMoveMakanan = targetMenu.GetComponent<RectTransform>();
                }

                isStartMoveMakanan = true;

                int slot = jalurNPC[i];

if (slot < 2)
{
    isTimerActive[slot] = false; 
}

                indexMakananAktif = i;
                StartCoroutine(TungguMakananSampai());

                if (i < pesanMakanan.Count)
                    pesanMakanan.RemoveAt(i);

                return;
            }
        }

        Debug.Log("SALAH PESANAN");
    }

    void ResetMakananKeAwal()
    {
        HapusSemuaMakanan();
        ButtonAnimation(piringMakanan);
        Debug.Log("Makanan di-reset ke awal");
    }

    public void PembeliSelesai(int index)
    {
        if (index >= npcAktif.Count) return;

        int slot = jalurNPC[index];

        titikTerisi[slot] = false;

        Destroy(npcAktif[index]);

        npcAktif.RemoveAt(index);
        jalurNPC.RemoveAt(index);
        sudahSampai.RemoveAt(index);
        sudahPergi.RemoveAt(index);
        pembeliKabur.RemoveAt(index);

        if (slot < 2)
        {
            isTimerActive[slot] = false;
            currentTime[slot] = maxTime;
            sliderTimer[slot] = null;
            npcSlot[slot] = null;
        }

        if (index < pesanMakanan.Count)
            pesanMakanan.RemoveAt(index);
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

        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.food);
        }
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

        if (AudioManager.instance != null)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.food);
    }
    }
    
}