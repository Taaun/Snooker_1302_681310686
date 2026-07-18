using UnityEngine;
using UnityEngine.EventSystems;

public enum Ballcolor
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black,
}
public class Srciptsball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int point;

    [SerializeField]
    private Ballcolor color;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        GameManager.instance.PlayerScore += point;
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
