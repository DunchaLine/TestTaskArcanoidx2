using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed;
    private Vector3 _movement;
    public float _limit;
    void Start()
    {
        _movement = transform.position;
    }


    void Update()
    {
        _movement.x += Input.GetAxis("Horizontal") * _speed;
            
        transform.position = Vector3.MoveTowards(transform.position, _movement, Time.deltaTime * _speed);
        //ограничение на передвижение по оси x
        if (_movement.x < -_limit) 
        {
            _movement = new Vector2 (-_limit, _movement.y);
        } 
        if (_movement.x > _limit) 
        {
            _movement = new Vector2(_limit, _movement.y);     
        }
        transform.position = _movement;            
    }
}
