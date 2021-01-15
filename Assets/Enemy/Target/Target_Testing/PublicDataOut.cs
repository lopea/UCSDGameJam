
using UnityEngine;
using UnityEngine.SceneManagement;

public class PublicDataOut : MonoBehaviour
{
    public Transform currentPos;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GlobalVariableStorage.EnemyTargetThePlayer = GetComponent<Transform>();
    }

}
