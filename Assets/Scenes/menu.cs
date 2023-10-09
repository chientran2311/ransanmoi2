using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
   public void Choimoi()
    {
        SceneManager.LoadScene(1);
    }
   public void Thoat()
    {
        Application.Quit();
    }
}
