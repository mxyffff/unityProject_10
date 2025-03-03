using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2GameManager : MonoBehaviour
{
    public static S2GameManager gm;

    public GameObject gameLabel;

    public Text gameText;

    public GameObject readyImage;
    public GameObject instructionImage;
    public GameObject gameEndImage;
    public GameObject endingImage;

    public GameObject playButton;
    public GameObject homeButton;

    GameObject base1;
    GameObject base2;
    GameObject base3;
    GameObject base4;

    GameObject loading;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public enum GameState
    {
        Ready,
        Instruction,
        Run,
        GameOver,
        Success,
        OverEnd,
        SuccessEnd,
        Loading
    }

    public GameState gState;

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();
        gameText.text = "지하철 타러 가는 중";
        gameText.color = new Color32(255, 255, 255, 255);
        gameText.fontSize = 70;

        readyImage.SetActive(true);

        StartCoroutine(ReadyToStart());
    }

    // Update is called once per frame
    void Update()
    {
        loading = GameObject.Find("Canvas").transform.GetChild(8).gameObject;

        if (gState == GameState.Instruction)
        {
            loading.SetActive(false);
            readyImage.SetActive(false);
            instructionImage.SetActive(true);

            gameText.text = "<size=50><color=#DB294D>게임설명</color></size><color=#FFBF21>\n\n별</color>에 맞춰 클릭하면 <color=#EC7786>성공</color>!\n\n시간 안에 역 이름을 완성하면 집에 갈 수 있어\n\n완성하지 못하면 <color=#EC7786>내릴 수 없다는 사실</color> 조심해!!"; // 수정
            gameText.color = new Color32(207, 225, 245, 255);
            gameText.fontSize = 40;

            playButton.SetActive(true);
        }

        if (gState == GameState.GameOver)
        {
            gameLabel.SetActive(true);
            gameEndImage.SetActive(true);
            gameText.text = "GameOver";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 70;

            homeButton.SetActive(true);
        }

        base1 = GameObject.Find("GameBar1").transform.GetChild(3).gameObject;
        base2 = GameObject.Find("GameBar2").transform.GetChild(3).gameObject;
        base3 = GameObject.Find("GameBar3").transform.GetChild(3).gameObject;
        base4 = GameObject.Find("GameBar4").transform.GetChild(3).gameObject;

        if ((base1.activeSelf == false) && (base2.activeSelf == false) && (base3.activeSelf == false)
            && (base4.activeSelf == false) && (gState == GameState.Run))
        {
            gState = GameState.Success;
        }

        if (gState == GameState.Success)
        {
            gameLabel.SetActive(true);
            gameEndImage.SetActive(true);

            gameText.text = "Success!";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 70;

            homeButton.SetActive(true);
        }

        if (gState == GameState.OverEnd)
        {
            endingImage.SetActive(true);

            gameText.text = "졸다가 내릴 역을 놓쳤다\n\n돌아가느라 더 피곤해졌다 . . . ▼";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 40;

            StartCoroutine(goLoading());
        }

        if (gState == GameState.SuccessEnd)
        {
            endingImage.SetActive(true);

            gameText.text = "드디어 내릴 역에 도착했다\n\n집으로 가자! ▼";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 40;

            StartCoroutine(goLoading());
        }

        if (gState == GameState.Loading)
        {
            loading.SetActive(true);

            gameText.text = "집으로 가는 중\n\n<color=#FFFEC0>마우스 오른쪽 버튼을 누르면\n현재 스코어 확인 가능!</color>";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 70;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gState = GameState.Instruction;
        
    }

    IEnumerator goLoading()
    {
        yield return new WaitForSeconds(3f);

        gState = GameState.Loading;
    }
}
