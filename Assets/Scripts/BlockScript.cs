using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public float _numberHits;
    public float _numbersToHit;
    //public GameObject _ball;
    public GameObject _leftBot, _rightTop;
    //private Collider _collBall, _collBlock;
    private Transform _leftPos, _rightPos;
    //public Vector2 _scale = new Vector2(.55f, .2f);
    void Start()
    {
        _leftPos = _leftBot.GetComponent<Transform>();
        _rightPos = _rightTop.GetComponent<Transform>();
        // _leftBot = GetComponent<GameObject>();
        // _rightTop = GetComponent<GameObject>();
        //_numberHits = 0;
    }

    void FixedUpdate()
    {
        // if (PlayerPrefs.HasKey("Hits"))
        // {
        //     _numberHits = PlayerPrefs.GetInt("Hits");
        //     if (_numberHits == _numbersToHit)
        //     {
        //         Debug.Log("Has to be destroyed");
        //         _numberHits = 0;
        //         PlayerPrefs.DeleteKey("Hits");
        //         Destroy(gameObject);
        //         PlayerPrefs.SetInt("Hits", _numberHits);
        //     }
        // }
        // LayerMask _maskBall = LayerMask.GetMask("Ball");
        // RaycastHit2D hitBallRight = Physics2D.Raycast(transform.position, transform.right, transform.localScale.x / 2 - .05f, _maskBall);
        // RaycastHit2D hitBallLeft = Physics2D.Raycast(transform.position, -transform.right, transform.localScale.x / 2 - .05f, _maskBall);
        // RaycastHit2D hitBallUp = Physics2D.Raycast(transform.position, transform.up, transform.localScale.y / 2 - .05f, _maskBall);
        // RaycastHit2D hitBallBot = Physics2D.Raycast(transform.position, -transform.up, transform.localScale.y / 2 - .05f, _maskBall);
        // if (hitBallBot || hitBallLeft || hitBallRight || hitBallUp)
        // {
        //     Debug.Log("HI THERE!");
        //     _numberHits++;
        //     if (_numberHits == _numbersToHit)
        //     {
        //         gameObject.SetActive(false);
        //     }
        // }

        // LayerMask _maskBall = LayerMask.GetMask("Ball");
        // Collider2D[] _hitBall = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f, _maskBall);
        // Debug.Log("hui " + _hitBall);
        
        // if (_hitBall != null)
        // {
        //     Debug.Log("_hitball != null");
        //     gameObject.SetActive(false);
        // }
        // LayerMask _maskBall = LayerMask.GetMask("Ball");
        // Collider2D _hitBall = Physics2D.OverlapBox(transform.position, new Vector3(transform.localScale.x - 1f, transform.localScale.y - .2f, 0), 0, _maskBall);
        // if (_hitBall)
        // {
        //     gameObject.SetActive(false);
        // }
        // var boundsBall = _collBall.bounds;
        // // var boundsBlock = _collBlock.bounds;
        // Debug.Log("boundsBall" + boundsBall);
        // Debug.Log("boundsBall" + boundsBlock);
        //Vector2 _posOfChildren = gameObject.GetComponentInChildren<Transform>().position;
        LayerMask _maskBall = LayerMask.GetMask("Ball");
        Check(_maskBall);
        // foreach (Collider2D col in Physics2D.OverlapAreaAll(_leftPos.position, _rightPos.position, _maskBall))
        // {
        //     // _numberHits += (int)Time.deltaTime;
        //     // Debug.Log("_numberHits: " + _numberHits + "Time" + Time.deltaTime);
        //     // //_numberHits += 1;
        //     if (_numberHits == _numbersToHit)
        //     {
        //         gameObject.SetActive(false);
        //         Debug.Log("Crashed block");
        //         _numberHits = 0;
        //     }
        //     else
        //     {
        //         _numberHits++;
        //         Debug.Log("numberHit = " + _numberHits);
        //     }
        // }
    }

    void Check(LayerMask _mask)
    {
        foreach (Collider2D col in Physics2D.OverlapAreaAll(_leftPos.position, _rightPos.position, _mask))
        {
            _numberHits += Time.deltaTime;
                Debug.Log("_numberHits = " + _numberHits);
            if (_numberHits >= _numbersToHit)
            {
                gameObject.SetActive(false);
                _numberHits = 0;
            }
            //СДЕЛАТЬ КОЛИЧЕСТВО ЖИЗНЕЙ, ОПРЕДЕЛИТЬ ПРИЧИНУ ХЕРОВОГО РИКОШЕТА. ДОДЕЛАТЬ ТРЕТИЙ УРОВЕНЬ.
            // if (_numberHits == _numbersToHit)
            // {
            //     gameObject.SetActive(false);
            //     Debug.Log("Crashed block");
            //     _numberHits = 0;
            // }
            // else
            // {
            //     _numberHits++;
            //     Debug.Log("numberHit = " + _numberHits);
            // }
        }
    }    
}
