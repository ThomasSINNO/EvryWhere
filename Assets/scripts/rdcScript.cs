using UnityEngine;
using UnityEngine.SceneManagement;

public class rdcScript : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Menu");
    }
}
