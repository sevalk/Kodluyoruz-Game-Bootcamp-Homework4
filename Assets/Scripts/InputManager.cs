using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    [HideInInspector]
    public float horizontalInputValue;
    [HideInInspector]
    public float verticalInputValue;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public static InputManager Instance()
    {
        return _instance;
    }


    private bool isSwipe;
    private float _touchVerticalStartPos;
    private float _touchHorizontalStartPos;
    private float touchSoothingValue = 0.1f;
    private float _swipeCheckStartPosX;
    private float _swipeCheckStartPosY;

    private float _swipeDistace = (float)Screen.width/4;
    private float _swipeMaxTime = 0.5f;
    private float _swipeTime = 0f;

    //Horizontal
    //Vertical
    //Jump

    void Update()
    {
//#if UNITY_EDITOR
        horizontalInputValue = Input.GetAxis("Horizontal");
        verticalInputValue = Input.GetAxis("Vertical");
//#else

        if (Input.touchCount > 0) {
            foreach(var touch in Input.touches)
            {
                var touchPos = touch.position;
                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        _touchVerticalStartPos = touch.position.y;
                        _touchHorizontalStartPos = touch.position.x;
                        _swipeCheckStartPosX = touch.position.x;
                        _swipeCheckStartPosY = touch.position.y;
                        break;
                    case TouchPhase.Moved:
                        CalculateInputOutput(touch.position);
                        if (!isSwipe)
                        {
                            _swipeTime += Time.deltaTime;
                            CheckForSwipe(touch.position, _swipeTime);
                        }
                       
                        break;
                    case TouchPhase.Stationary:
                        CalculateInputOutput(touch.position);
                        break;
                    case TouchPhase.Ended:
                        isSwipe = false;
                        _touchVerticalStartPos = 0;
                        _touchHorizontalStartPos =0; 
                        break;
                    case TouchPhase.Canceled:
                        isSwipe = false;
                        break;
                }
            }
        }
//#endif
    }

    private void CheckForSwipe(Vector2 touchPosition, float swipeTime)
    {
        if (swipeTime > _swipeMaxTime) return;

        if(Mathf.Abs(touchPosition.x - _swipeCheckStartPosX)> _swipeDistace &&  touchPosition.x > _swipeCheckStartPosX ) //sağa swipe
        {
            isSwipe = true;
            Debug.Log("we have horizontal swipe right");
            _swipeTime = 0;
           
            _swipeCheckStartPosX = 0;
        }
        else if(Mathf.Abs(touchPosition.x - _swipeCheckStartPosX) > _swipeDistace && touchPosition.x < _swipeCheckStartPosX) //sola swipe        {
        {
            isSwipe = true;
            Debug.Log("we have horizontal swipe left");
            _swipeTime = 0;

            _swipeCheckStartPosX = 0;
        }
        else if (Mathf.Abs( touchPosition.y - _swipeCheckStartPosY )> _swipeDistace && touchPosition.y > _swipeCheckStartPosY) //yukarı swipe
        {
            isSwipe = true;
            Debug.Log("we have vertical swipe up");
            _swipeTime = 0;
            _swipeCheckStartPosY = 0;
        }
        else if (Mathf.Abs(touchPosition.y - _swipeCheckStartPosY) > _swipeDistace && touchPosition.y < _swipeCheckStartPosY) //aşağı swipe
        {
            isSwipe = true;
            Debug.Log("we have vertical swipe down");
            _swipeTime = 0;
            _swipeCheckStartPosY = 0;
        }
    }


    private void CalculateInputOutput(Vector2 touchPosition)
    {
        verticalInputValue = Mathf.Clamp((touchPosition.y - _touchVerticalStartPos) * touchSoothingValue , -1f, 1f);
        horizontalInputValue = Mathf.Clamp((touchPosition.x - _touchHorizontalStartPos) * touchSoothingValue, -1f, 1f);
    }
}
