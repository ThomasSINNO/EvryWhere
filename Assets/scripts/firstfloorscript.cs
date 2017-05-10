using UnityEngine;
using UnityEngine.SceneManagement;

public class firstfloorscript : MonoBehaviour
{

    // Use this for initialization
    private void OnMouseDown()
    {
        SceneManager.LoadScene("couloir");
    }
}