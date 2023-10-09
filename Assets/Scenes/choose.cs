using UnityEngine;
using UnityEngine.SceneManagement;
public class choose : MonoBehaviour
{
    public void de()
    {
        SceneManager.LoadScene(2);
    }
    public void kho()
    {
        SceneManager.LoadScene(3);
    }
    public void acmong()
    {
        SceneManager.LoadScene(4);
    }
    public void back()
    {
        SceneManager.LoadScene(0);
    }
}
