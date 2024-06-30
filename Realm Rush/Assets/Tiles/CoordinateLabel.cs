using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using JetBrains.Annotations;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoodinateLabler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);


    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    // Start is called before the first frame update
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying){
            DisplayCoordinates();
            UpdateObjectName();
        }

        ToggleLables();
        SetLableColor();
    }

    void ToggleLables(){
        if(Input.GetKeyDown(KeyCode.C)){
            label.enabled = !label.IsActive();
        }
    }

    void SetLableColor()
    {
        if(gridManager == null) {return;}
        Node node = gridManager.GetNode(coordinates);

        if(node == null) {return;}
        
        if(!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if(!node.isPath)
        {
            label.color = pathColor;
        }
        else if(!node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    private void DisplayCoordinates()
    {
        if(gridManager == null) { return; }
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName(){
        transform.parent.name = coordinates.ToString();
    }
}
