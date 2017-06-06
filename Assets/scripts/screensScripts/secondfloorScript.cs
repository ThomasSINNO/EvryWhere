using UnityEngine;
using UnityEngine.SceneManagement;

public class secondfloorScript : MonoBehaviour {

    // Use this for initialization
    private void OnMouseDown()
    {
        SceneManager.LoadScene("couloir2");
    }
}
