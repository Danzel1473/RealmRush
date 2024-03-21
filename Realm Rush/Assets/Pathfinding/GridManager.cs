using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Node node;

    void Start()
    {
        Debug.Log(node.coordinates);
        Debug.Log(node.isWalkable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
