using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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


    public static GameManager instance;

    private void Start()
    {
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
    }

    private void RotateBall()
    {
        if(cueBall != null)
            cueBall.transform.Rotate(new Vector3(0f, xInput, 0f));
    }

    private void StopBall()
    {
        Rigidbody rb =cueBall.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = Vector3.zero;

        BallLine.SetActive(true);
    }

    private void 
}
