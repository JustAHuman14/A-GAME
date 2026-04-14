using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _playerSpeed;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            Time.timeScale = 1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_playerSpeed, _rb.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            print("Player Died");
            Time.timeScale = 0;
            SceneManager.LoadScene(0);
        }
    }
}
