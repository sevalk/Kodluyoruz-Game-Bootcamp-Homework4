using UnityEngine;

namespace CheckPointSystem
{
    public class CheckPointController : MonoBehaviour
    {

        public CheckPointManager checkPointManager;

        [SerializeField] private CheckPointData _checkPointData;

        

        private ExampleSceneLoader _exampleSceneLoader ;

        public bool isMyTurn;

        private void Start()
        {
            _exampleSceneLoader = FindObjectOfType<ExampleSceneLoader>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (isMyTurn)
                {
                    isMyTurn = false;
                    _checkPointData.isPassed = true;
                    LoadCheckPointUI();
                   
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (_checkPointData.isPassed)
                {
                    checkPointManager.SetLastPassedCheckPoint(_checkPointData.checkPointID);
                    _exampleSceneLoader.UnLoadScene(_checkPointData.checkPointID +2);
                }
            }
        }

        public void ResetCheckPoint()
        {
            _checkPointData.isPassed = false;
            LoadCheckPointUI();
        }

        private void LoadCheckPointUI()
        {
            
            _exampleSceneLoader.LoadScene(_checkPointData.checkPointID +2);
            
            
        }
    }

    [System.Serializable]
    public class CheckPointData
    {
        public int checkPointID;
        public bool isPassed;
        public Renderer checkPointRenderer;
    }
}





