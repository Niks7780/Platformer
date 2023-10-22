using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Platformer
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] [Range(1f, 3f)] private float _speed = 3f;
        [SerializeField] [Range(1f, 5f)] private int _lives = 5;
        [SerializeField] [Range(1f, 50f)] private float _jumpForce = 25f;
        private Rigidbody2D _rb;
        private SpriteRenderer _sprite;
        
        private Animator _anim;
        public GameObject _bulletRight;
        public GameObject _bulletLeft;
        private GameObject _bulletClone;
        private GameObject _swordClone;
        public GameObject _sword;
        public GameObject _gameOver;

        public GameObject _fireBallUI;
        public GameObject _gunInJumpUI;
        public GameObject _blockUI;
        public GameObject _SuperHeroUI;
        private bool _block;
        private bool _blockBool = false;
        [SerializeField] private float _time1;
        [SerializeField] private float _time2;
        private float _rebootTimeGetAtackInJump = 20;
        [SerializeField] private float _rebootTime = 10;
        private float _timeDamage = 3;
        [SerializeField] [Range(10f, 35f)] private float _timeGun = 10;
        private float _timeAnimation;
        public Text textlives;
                
        public bool _isGround;
        public float _rayDistance = 0.6f;
        private bool _doubleJump = false;
        private bool _getAtackInJump = false;
        private bool _fireBollBool = false;
        [SerializeField] AudioSource _deathSound;
        [SerializeField] AudioSource _botleSound;
        private bool _bigHero = false;
        [SerializeField] [Range(10f, 40f)] private float _timeBigHero = 10;

        // public GameObject gameOver;
        private States State
        {
            get { return (States)_anim.GetInteger("State"); }
            set { _anim.SetInteger("State", (int)value); }
        }
        void Start()
        {
        _fireBallUI.SetActive(false);
        _gunInJumpUI.SetActive(false);
        _blockUI.SetActive(false);
        _SuperHeroUI.SetActive(false);
    }
        public void GetDamage()
        {
            
            if (_lives > 0 && _timeDamage < 0 && _block == false) 
            {
                _lives--;
                _deathSound.Play();
                _timeDamage = 3;
                
            } 
            if (_lives <= 0)
            {
                _gameOver.SetActive(true);
                gameObject.SetActive(false);
                _fireBallUI.SetActive(false);
                _gunInJumpUI.SetActive(false);
                _blockUI.SetActive(false);
                _SuperHeroUI.SetActive(false);
                Time.timeScale = 0f;
            }

        }
        
        public void TextLives()
         {
             textlives.text = _lives.ToString();
         }
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _anim = GetComponent<Animator>();
        }

        private void Run()
        {
            if (_isGround) State = States.run;

            Vector3 dir = transform.right * Input.GetAxis("Horizontal");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);
            _sprite.flipX = dir.x < 0.0f;
        }
        
        

        private void DoubleJump()
        {
            if (_isGround)
            {
                _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            }
            else if (!_doubleJump && _rb.velocity.y < 0)
            {
                _doubleJump = true;
                _rb.AddForce(new Vector2(0, _jumpForce + 5), ForceMode2D.Impulse);
            }
        }

        private void CheckGround()
        {
            RaycastHit2D hit = Physics2D.Raycast(_rb.position, Vector2.down, _rayDistance, LayerMask.GetMask("Titles"));

            if (hit.collider != null)
            {
                _isGround = true;
                _doubleJump = false;
            }
            else
            {
                _isGround = false;
            }
        }
        private void Attack()
        {

            if (gameObject.GetComponentInChildren<SpriteRenderer>().flipX == false)
            {
                _swordClone = Instantiate(_sword, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 90));
                _swordClone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 10);
                Destroy(_swordClone, 1f);
            }
            if (gameObject.GetComponentInChildren<SpriteRenderer>().flipX == true)
            {
                _swordClone = Instantiate(_sword, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 90));
                _swordClone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 160);
                Destroy(_swordClone, 1f);
            }
            
        }

        private void StartBigGun()
        {
            _rebootTime = 10;
            if (gameObject.GetComponentInChildren<SpriteRenderer>().flipX == false)
            {
                _bulletClone = Instantiate(_bulletRight, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.7f, 0), Quaternion.Euler(0, 0, 0));
                _bulletClone.GetComponent<Transform>().localScale = new Vector3(2, 2, 2);
                _bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector3(10, 3, 0), ForceMode2D.Impulse);
                Destroy(_bulletClone, 0.5f);
            }
            if (gameObject.GetComponentInChildren<SpriteRenderer>().flipX == true)
            {
                _bulletClone = Instantiate(_bulletLeft, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.7f, 0), Quaternion.Euler(0, 0, 0));
                _bulletClone.GetComponent<Transform>().localScale = new Vector3(2, 2, 2);
                _bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector3(-10, 3, 0), ForceMode2D.Impulse);
                Destroy(_bulletClone, 0.5f);
            }
            
        }

        private void StartGun()
         {
            
             if (gameObject.GetComponentInChildren<SpriteRenderer>().flipX == false)
             {
                 _bulletClone = Instantiate(_bulletRight, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f, 0), Quaternion.Euler(0, 0, 0));
                 _bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector3(5, 3, 0), ForceMode2D.Impulse);
                 Destroy(_bulletClone, 0.5f);
             }
             if (gameObject.GetComponentInChildren<SpriteRenderer>().flipX == true) 
             {
                 _bulletClone = Instantiate(_bulletLeft, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f, 0), Quaternion.Euler(0, 0, 0));
                 _bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector3(-5, 3, 0), ForceMode2D.Impulse);
                 Destroy(_bulletClone, 0.5f);
             }
            
        }
        private void Resp()
        {

        }
        private void SuperHero()
        {

        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Horizontal") && _block == false)
            {
                Run();
                State = States.run;
                _timeAnimation = 0.1f;
                
            }

            if (Input.GetKeyDown(KeyCode.Space) && _block == false)
            {
                
                DoubleJump();
                State = States.jump;
                _timeAnimation = 1f;
            }

            if (Input.GetButtonDown("Fire1") && _block == false)
            {
                _time1 = Time.time;
                _timeAnimation = 1f;
                Debug.Log(_time1);
            }

            if (Input.GetButtonUp("Fire1") && _block == false)
            {
                _time2 = Time.time;
                Debug.Log(_time2);
                float _time = _time2 - _time1;
                Debug.Log(_time);
                if (_rb.velocity.y == 0 || _getAtackInJump == true)
                {
                    if (_time > 3 && _rebootTime < 0) 
                    { 
                        StartBigGun();
                        
                    }
                    else { StartGun(); }
                }
                _timeAnimation = 1f;
            }
            if(_rebootTime < 0)
            {
                _fireBallUI.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                
            }
            if (_rebootTime > 0)
            {
                _fireBallUI.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
            }

            if (Input.GetButtonDown("Fire2") && _block == false)
            {
                    Attack();
                State = States.attack;
                _timeAnimation = 1f;
            }

            if (Input.GetButtonDown("Fire3") && _blockBool == true)
            {
                _block = true;
                gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                Debug.Log("Block");
                //State = States.block;
                
            }

            if (Input.GetButtonUp("Fire3"))
            {
                _block = false;
                gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }

            else if (_timeAnimation < 0) 
            { 
                
                State = States.idle;
                
            }
            if (_getAtackInJump == true) 
            { 
                _timeGun = _timeGun - Time.deltaTime;
                _gunInJumpUI.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                _rebootTimeGetAtackInJump = 10;
            }

            if (_timeGun < 0) 
            { 
                _getAtackInJump = false;
                _gunInJumpUI.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
                _rebootTimeGetAtackInJump = _rebootTimeGetAtackInJump - Time.deltaTime;

            }
            if (_rebootTimeGetAtackInJump < 0)
            {
                _timeGun = 10;
                _getAtackInJump = true;
            }

            if (_bigHero == true)
            {
                _timeBigHero = _timeBigHero - Time.deltaTime;
                gameObject.GetComponent<Transform>().localScale = new Vector3 (2,2,2);
                _speed = 6f;
                _jumpForce = 35f;
            }


            if (_timeBigHero < 0)
            {
                _bigHero = false;
                gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                _speed = 3f;
                _jumpForce = 25f;
            }

            
            TextLives();
            _timeAnimation = _timeAnimation - Time.deltaTime;
            CheckGround();
            if (_fireBollBool == true)
            {
                _rebootTime = _rebootTime - Time.deltaTime;
            }


            _timeDamage = _timeDamage - Time.deltaTime;
            if(_timeDamage > 0)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
            }
            if (_timeDamage < 0 && _block == false)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            }


        }
        
        
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                GetDamage();
            }

            if (col.gameObject.name == "GunInJump")
            {
                Destroy(col.gameObject);
                _botleSound.Play();
                _getAtackInJump = true;
                _gunInJumpUI.SetActive(true);

            }

            if (col.gameObject.name == "SuperHero")
            {
                _SuperHeroUI.SetActive(true);
                Destroy(col.gameObject);
                _bigHero = true;
                _getAtackInJump = true;
                _botleSound.Play();

            }

            if (col.gameObject.name == "GUN")
            {

                Destroy(col.gameObject);
                _fireBallUI.SetActive(true);
                _fireBollBool = true;
                _botleSound.Play();

            }

            if (col.gameObject.name == "Block")
            {

                Destroy(col.gameObject);
                _blockUI.SetActive(true);
                _blockBool = true;
                _botleSound.Play();

            }
        }
        
    }
}

public enum States
{
    idle,
    run,
    jump,
    attack,
    block
}