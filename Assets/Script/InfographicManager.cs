using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System.Collections;

public class InfographicManager : MonoBehaviour
{
    public static InfographicManager Instance;

    [Header("UI References")]
    public GameObject panelInfografis;
    public CanvasGroup contentCanvasGroup;
    
    [Header("Sistem Skor")]
    public TextMeshProUGUI txtScore; 
    private int jumlahSampah = 0;
    private int targetSampah = 7;
    [Header("Data Fields")]
    public TextMeshProUGUI txtNama;
    public Image imgIcon;
    public TextMeshProUGUI txtDeskripsi;
    public TextMeshProUGUI txtKategori;

    [Header("Animation Settings")]
    public float animDuration = 0.3f;
    public Vector3 startScale = new Vector3(0.7f, 0.7f, 1f);

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        panelInfografis.SetActive(false);
    }

    void Start()
    {
        //  BARU: Set teks awal saat game mula
        UpdateTeksSkor();
    }

    public void TampilkanInfografis(TrashData data)
    {
        Time.timeScale = 0; 

        txtNama.text = data.namaSampah;
        imgIcon.sprite = data.gambarSampah;
        imgIcon.preserveAspect = true;
        txtDeskripsi.text = data.deskripsiInfografis;
        txtKategori.text = data.kategori;

        panelInfografis.SetActive(true);
        StartCoroutine(AnimatePopUp());
    }
    public void TambahSkor()
    {
        jumlahSampah++;
        
    
        if (jumlahSampah > targetSampah) jumlahSampah = targetSampah;

        UpdateTeksSkor();

        
        if (jumlahSampah >= targetSampah)
        {
            Debug.Log("SELAMAT! Misi Selesai.");
            // Nanti bisa tambah logika menang/game over disini
        }
    }

    void UpdateTeksSkor()
    {
        if (txtScore != null)
        {
            txtScore.text = jumlahSampah + "/" + targetSampah;
        }
    }
 

    public void TutupInfografis()
    {
        Time.timeScale = 1;
        panelInfografis.SetActive(false);
    }

    IEnumerator AnimatePopUp()
    {
        contentCanvasGroup.alpha = 0;
        contentCanvasGroup.transform.localScale = startScale;

        float timer = 0;
        while(timer < animDuration)
        {
            timer += Time.unscaledDeltaTime; 
            float progress = timer / animDuration;

            contentCanvasGroup.alpha = Mathf.Lerp(0, 1, progress);
            contentCanvasGroup.transform.localScale = Vector3.Lerp(startScale, Vector3.one, progress);
            
            yield return null;
        }
        contentCanvasGroup.alpha = 1;
        contentCanvasGroup.transform.localScale = Vector3.one;
    }
}