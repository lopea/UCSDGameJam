using UnityEngine;
using UnityEngine.SceneManagement;
public class GlobalVariableStorage : MonoBehaviour
{
    public static Transform EnemyTargetThePlayer;
    // Start is called before the first frame update
    void Start()
    {
        EnemyTargetThePlayer = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
