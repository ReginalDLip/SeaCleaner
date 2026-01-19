using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Panggil fungsi ini di tombol "Play"
    public void MulaiGame()
    {
        // Pastikan nama scene gameplay Anda sesuai, misal "GameScene"
        SceneManager.LoadScene("GameScene");
    }

    // Panggil fungsi ini di tombol "Quit"
    public void KeluarGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }
}