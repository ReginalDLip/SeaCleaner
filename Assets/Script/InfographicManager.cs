using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System.Collections;
using UnityEngine.SceneManagement; // Tambahkan ini untuk load scene

public class InfographicManager : MonoBehaviour
{
    public static InfographicManager Instance;

    [Header("UI References")]
    public GameObject panelInfografis;
    public GameObject panelMenang; // TAMBAHAN: Masukkan Panel Win disini
    public CanvasGroup contentCanvasGroup;
    
    [Header("Sistem Skor")]
    public TextMeshProUGUI txtScore; 
    private int jumlahSampah = 0;
    public int targetSampah = 7; // Ubah ke public biar bisa diatur di Inspector
    
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
        if(panelMenang != null) panelMenang.SetActive(false); 
    }

    void Start()
    {
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
        panelInfografis.SetActive(false);
        if (jumlahSampah >= targetSampah)
        {
            MunculkanKemenangan();
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void MunculkanKemenangan()
    {
        if(panelMenang != null)
        {
            panelMenang.SetActive(true);
        }
        else
        {
            Debug.LogError("Panel Menang belum dimasukkan di Inspector!");
        }
    }
    public void KeMainMenu()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("MainMenu"); 
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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