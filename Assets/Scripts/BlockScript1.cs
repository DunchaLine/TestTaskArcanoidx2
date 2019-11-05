using UnityEngine;

public class BlockScript1 : MonoBehaviour
{
    public float _numberHits;
    public float _numbersToHit;
    public GameObject _leftBot, _rightTop;
    private Transform _leftPos, _rightPos;
    void Start()
    {
        _leftPos = _leftBot.GetComponent<Transform>();
        _rightPos = _rightTop.GetComponent<Transform>();
        _numberHits = 0;
    }

    void FixedUpdate()
    {
        //записываем в переменную слой шара
        LayerMask _maskBall = LayerMask.GetMask("Ball");
        //проверяем, пересек ли шар блок
        foreach (Collider2D col in Physics2D.OverlapBoxAll(transform.position, new Vector2(1.1f, .47f), 0, _maskBall))
        {
            _numberHits++;
            Debug.Log("_numberHits = " + _numberHits + " _numbersToHit = " + _numbersToHit);
            //если пересек и _numberHits >= _numberToHit - уничтожаем объект
            if (_numberHits >= _numbersToHit)
            {
                gameObject.SetActive(false);
                Debug.Log("Block crashed!");
            }
        }
        
    } 
}
