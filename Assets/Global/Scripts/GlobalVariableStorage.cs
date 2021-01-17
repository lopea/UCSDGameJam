using UnityEngine;
using UnityEngine.SceneManagement;
public class GlobalVariableStorage : MonoBehaviour
{
    public static Transform EnemyTargetThePlayer;
    [SerializeField] Vector3 ShotgunOffset;
    public static Vector3 EnemyShotgunOffset;

    // Start is called before the first frame update
    void Start()
    {
        ShotgunOffset.x = 0;
        ShotgunOffset.y = 0;
        ShotgunOffset.z = 0;
        EnemyTargetThePlayer = transform;
        EnemyShotgunOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyShotgunOffset = ShotgunOffset;
    }
}
