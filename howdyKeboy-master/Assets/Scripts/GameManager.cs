using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject target;
    
    // Start is called before the first frame update
    public Button restartButton,instructionsButton;
    float timeLeft;
    float spawnX;
    float spawnY;

    public void EndGame(){
        SceneManager.LoadScene("GameOverScene");
    }
    public void Restart(){
        SceneManager.LoadScene("GameScene");
    }
    public void Instructions(){
        SceneManager.LoadScene("InstructionScene");
    }
    public void createTargets(bool create){
        spawnX = Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x+1, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x-1);
        spawnY =Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y+1, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y-1);
        if(create){
            Instantiate(target,new Vector3(spawnX,spawnY,0),Quaternion.identity);

        }

    }

    void Start(){
        restartButton.onClick.AddListener(Restart);
        instructionsButton.onClick.AddListener(Instructions);
        timeLeft = Random.Range(0,5);
    }

    void Update(){
        timeLeft-=Time.deltaTime;
        if (timeLeft<0){
            createTargets(true);
            timeLeft = Random.Range(0,5);
        }
    }

}
