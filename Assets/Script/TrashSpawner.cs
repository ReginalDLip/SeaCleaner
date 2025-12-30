using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [Header("Settingan")]
    public GameObject prefabWadah; 
    public TrashData[] databaseSampah; 
    public float intervalSpawn = 3f;
    
    [Header("Area Spawn")]
    public Transform areaKiriAtas;  
    public Transform areaKananBawah; 

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= intervalSpawn)
        {
            SpawnSampahBaru();
            timer = 0;
        }
    }

    void SpawnSampahBaru()
    {
        if (databaseSampah.Length == 0) return;
        TrashData data = databaseSampah[Random.Range(0, databaseSampah.Length)];
        bool spawnDariKiri = Random.value > 0.5f;

        Vector3 posisiSpawn;
        Vector3 arahGerak;

        float randomY = Random.Range(areaKananBawah.position.y, areaKiriAtas.position.y);

        if (spawnDariKiri)
        {
            posisiSpawn = new Vector3(areaKiriAtas.position.x, randomY, 0);
            arahGerak = Vector3.right; // (1, 0, 0)
        }
        else
        {
            posisiSpawn = new Vector3(areaKananBawah.position.x, randomY, 0);
            arahGerak = Vector3.left; // (-1, 0, 0)
        }

        GameObject sampah = Instantiate(prefabWadah, posisiSpawn, Quaternion.identity);
        
        sampah.GetComponent<TrashItem>().Konfigurasi(data, arahGerak);
    }
}