using UnityEngine;

public class TrashItem : MonoBehaviour
{
    public TrashData dataSaatIni;

    private SpriteRenderer sr;
    private Vector3 startPos;
    private Vector3 direction; 
    
    public float speed = 1f;
    public float floatHeight = 0.2f;
    public float floatFreq = 1f;

    public void Konfigurasi(TrashData data, Vector3 dir)
    {
        dataSaatIni = data;
        direction = dir; 

        sr = GetComponent<SpriteRenderer>();
        if (sr != null && data.gambarSampah != null)
        {
            sr.sprite = data.gambarSampah;
        }
        float rotasiAcak = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, 0, rotasiAcak);
        
       
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        if(col != null) col.size = sr.bounds.size;
    }

    void Start()
    {
    
        startPos = transform.position;
    }

    void Update()
    {
      transform.position += direction * speed * Time.deltaTime;
        float newY = transform.position.y + (Mathf.Sin(Time.time * floatFreq) * floatHeight * Time.deltaTime);
        
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        if (transform.position.x > 30f || transform.position.x < -30f)
        {
            Destroy(gameObject);
        }
    }
}