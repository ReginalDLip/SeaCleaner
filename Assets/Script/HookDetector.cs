using UnityEngine;

public class HookDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            TrashItem scriptSampah = other.GetComponent<TrashItem>();

            if (scriptSampah != null && scriptSampah.dataSaatIni != null)
            {
                
                InfographicManager.Instance.TampilkanInfografis(scriptSampah.dataSaatIni);
                
                
                InfographicManager.Instance.TambahSkor();
            }

            Destroy(other.gameObject);
        }
    }
}