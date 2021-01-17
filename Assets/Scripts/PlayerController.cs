using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private PlayerSettings _playerSettings;             //Settings of player movement   

        private CharacterController _controller;                            //Unity Simple Assets Character controller
        private Vector3 _moveDirection;
        private Vector3 _moveRotation;
        private float _currentYRotationValue;                               //Temp rotation value from mouse input
        private bool _isJumping;
        private Animator _animator;


      //  public Transform enemy;
        // Start is called before the first frame update
        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        private void Update()
        {
            //TODO: CHANGE TO STATE MACHINE
            if (!_isJumping)
            {
                _moveDirection = new Vector3(InputManager.Instance().horizontalInputValue, 0, InputManager.Instance().verticalInputValue);
            }
            else
            {
                _moveDirection = new Vector3(0, _playerSettings.jumpForce, 0);
            }

            //_currentYRotationValue += InputManager.Instance().horizontalInputValue;              // Döner kebap ekseninde dönüş için yatay hareket datası alıyoruz
            _moveRotation = new Vector3(0, _currentYRotationValue, 0);
            _moveDirection = Quaternion.Euler(_moveRotation) * _moveDirection;  //rotasyon datası ile hareket vectorümüzü çarptık

            if (_controller.isGrounded && !_isJumping)                          //yerde değilsek ve zıplamıyorsak zıpla
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _moveDirection.y = _playerSettings.jumpForce;
                    StartCoroutine(Jump());

                }
            }

            transform.rotation = Quaternion.Euler(_moveRotation);               // rotasyonu _moveRotasyona eşitle

            /*
            Vector3 targetPostition = new Vector3(enemy.position.x,
                                       this.transform.position.y,
                                       enemy.position.z);
                    transform.LookAt(targetPostition);
            */

            if (!_isJumping)
            {
                _moveDirection.y += _moveDirection.y + Physics.gravity.y * _playerSettings.gravityScale * Time.deltaTime; //Y ekseni için gravity
            }
            _controller.Move(_moveDirection * Time.deltaTime * _playerSettings.moveSpeed);

        }

        /// <summary>
        /// Controls jump with given time
        /// </summary>
        /// <returns>The function.</returns>
        private IEnumerator Jump()
        {
            _isJumping = true;
            yield return new WaitForSeconds(_playerSettings.jumpTime);
            _isJumping = false;
        }
    }

    [System.Serializable]
    public struct PlayerSettings
    {
        public float moveSpeed;
        public float jumpForce;
        public float jumpTime;
        public float gravityScale;
    }

}

