using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballpositions;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private GameObject ballprefads;

    [SerializeField]
    private float xInput = 0f;

    [SerializeField]
    private GameObject BallLine;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private TMP_Text notitext;


    public static GameManager instance;

    private void Start()
    {
        camBehindCuaBall();

        SetBall(Ballcolor.Red, 1);
        SetBall(Ballcolor.Yellow, 2);
        SetBall(Ballcolor.Green, 3);
        SetBall(Ballcolor.Brown, 4);
        SetBall(Ballcolor.Blue, 5);
        SetBall(Ballcolor.Pink, 6);
        SetBall(Ballcolor.Black, 7);
    }

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        RotateBall();
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Shootball();


        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0.1f;
        else
            xInput = 0f;

        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();
    }

    private void SetBall(Ballcolor col, int i)
    {
        GameObject obj = Instantiate(ballprefads,
                    ballpositions[i].transform.position,
                    Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetcolorAndPoint(col);
    }

    private void Shootball()
    {
        Rigidbody rd=cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);

        BallLine.SetActive(false);
        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f ,30f ,-42f);
        cam.transform.eulerAngles = new Vector3(45f, 0f, 0f);
    }

    private void RotateBall()
    {
        if(cueBall != null)
            cueBall.transform.Rotate(new Vector3(0f, xInput, 0f));
    }

    private void StopBall()
    {
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = Vector3.zero;

        BallLine.SetActive(true);
        camBehindCuaBall();
    }

    private void camBehindCuaBall()
    {
        cam.transform.parent = cueBall.transform;
        cam.transform.position = cueBall.transform.position + new Vector3(0f, 7f, -15f);
        cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }

    public void ShowScoreText(int n)
    {
        playerScore += n;
        notitext.text = $"Ball Point: {n}\nTotal Score: {playerScore}";

    }

    public void ShowString(string s)
    {
        notitext.text = s;
    }
}
