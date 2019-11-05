using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBallScript : MonoBehaviour
{
    //находится ли шар сейчас в движении
    [SerializeField]
    private bool isActive = false;
    //игрок
    public Transform _player;
    //вектор движения шара
    private Vector3 _direction;
    //скорость шара
    public float _speed;
    Vector2 _pos;
    //лучи, выпускаемые из центра шара во все стороны
    RaycastHit2D hit, _rayDown, _rayForw, _rayLeft, _rayRight, _rayDiag1, _rayDiag2, _rayDiag3, _rayDiag4;
    LayerMask _blocksMask, _mask;
    void Start()
    {
        //записываем в переменные слои блоков и стен
        _blocksMask = LayerMask.GetMask("Blocks");
        _mask = LayerMask.GetMask("Wall");
        _player.GetComponent<Transform>();
        //изначально шарик находится на платформе
        transform.position = new Vector3(
            _player.transform.position.x, _player.transform.position.y + .6f, _player.transform.position.z);
        isActive = false;
        hit = Physics2D.Raycast(transform.position, transform.forward, 0f);
    }

    void FixedUpdate()
    {
        //при нажатии на пробел, шар начинает двигаться и isActive = true
        if (Input.GetKey(KeyCode.Space) && !isActive)
        {
            _direction = transform.up + transform.right * .5f;
            isActive = true;
            Debug.Log("Ball starts the way");
        }        
        //если было попадание в стену и шарик активен, то высчитываем рикошет и нормализуем его
        hit = Physics2D.Raycast(transform.position, _direction, .5f, _mask);
        transform.Translate(_direction * _speed * Time.deltaTime);
        //если шар не активен, то он остается на платформе
        if (!isActive)
        {
            transform.position = new Vector2(_player.position.x, _player.position.y + .45f);
        }
            
        //рикошет от стен
        if (hit && isActive)
        {
            _direction = Vector2.Reflect(_direction, hit.normal).normalized;
            Debug.Log("Hit Wall");
        }
        //лучи, направленные во все стороны для проверки столкновения с блоками
        _rayForw = Physics2D.Raycast(transform.position, transform.up, .3f, _blocksMask);
        _rayDown = Physics2D.Raycast(transform.position, -transform.up, .3f, _blocksMask);
        _rayRight = Physics2D.Raycast(transform.position, transform.right, .3f, _blocksMask);
        _rayLeft = Physics2D.Raycast(transform.position, -transform.right, .3f, _blocksMask);
        _rayDiag1 = Physics2D.Raycast(transform.position, transform.up + transform.right, .35f, _blocksMask);
        _rayDiag2 = Physics2D.Raycast(transform.position, transform.up + -transform.right, .35f, _blocksMask);
        _rayDiag3 = Physics2D.Raycast(transform.position, -transform.up + transform.right, .35f, _blocksMask);
        _rayDiag4 = Physics2D.Raycast(transform.position, -transform.up + -transform.right, .35f, _blocksMask);
        //проверка на рикошет для всех лучей
        Ricochet(_direction, _rayForw, isActive);
        Ricochet(_direction, _rayDown, isActive);
        Ricochet(_direction, _rayRight, isActive);
        Ricochet(_direction, _rayLeft, isActive);
        Ricochet(_direction, _rayDiag1, isActive);
        Ricochet(_direction, _rayDiag2, isActive);
        Ricochet(_direction, _rayDiag3, isActive);
        Ricochet(_direction, _rayDiag4, isActive);
        //проигрыш/выигрыш
        Lose(isActive, transform.position.y);
        Win();
    }
    void Ricochet(Vector3 direct, RaycastHit2D ray, bool _Active)
    {
        if (ray && _Active)
        {
            _direction = Vector2.Reflect(_direction, ray.normal).normalized;
            Debug.Log("Hit Block");
        }
    }

    void Win()
    {
        if (GameObject.FindGameObjectsWithTag("block").Length == 0)
        {
            if(SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                Application.Quit();
            }
        }
    }

    void Lose(bool _active, float _y)
    {
        if (_active && _y <= -4.7f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
