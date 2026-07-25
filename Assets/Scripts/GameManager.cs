using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballpositions;

    [SerializeField]
    private GameObject ballprefads;

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
        
    }

    private void SetBall(Ballcolor col, int i)
    {
        GameObject obj = Instantiate(ballprefads,
                    ballpositions[i].transform.position,
                    Quaternion.identity);
        Srciptsball b = obj.GetComponent<Srciptsball>();
        b.SetcolorAndPoint(col);
    }
}
