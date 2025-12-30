using UnityEngine;

[CreateAssetMenu(fileName = "DataSampahBaru", menuName = "Game/Data Sampah")]
public class TrashData : ScriptableObject
{
    [Header("Identitas Sampah")]
    public string namaSampah;
    public Sprite gambarSampah;
    
    [Header("Info Edukasi")]
    public string kategori;
    
    [TextArea(3, 10)] 
    
    public string deskripsiInfografis; 
}