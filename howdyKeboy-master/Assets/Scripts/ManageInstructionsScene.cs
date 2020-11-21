using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageInstructionsScene : MonoBehaviour
{
    public Button returnButtom;
    // Start is called before the first frame update

    void Start()
    {
        returnButtom.onClick.AddListener(ReturnButton);
    }
    public void ReturnButton(){
        Debug.Log("asdsad");
        SceneManager.LoadScene("StartScreenScene");

    }

}
