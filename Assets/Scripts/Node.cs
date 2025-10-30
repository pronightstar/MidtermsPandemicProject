using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class Node : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private List<Node> adjacentNodes;
    [SerializeField] private GameObject diseaseCubePrefab;
    [SerializeField] private Transform diseaseCubeContainer;

    private List<GameObject> diseaseCubes = new List<GameObject>();

    private bool playerLoc = false;
    private int diseaseCount = 0;

    void Start()
    {
        AddPhysics2DRaycaster();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Board board = FindObjectOfType<Board>();
            board.SetCurrentNode(this);
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    public bool GetPlayerLoc()
    {
        return playerLoc;
    }

    public void SetPlayerLoc(bool value)
    {
        playerLoc = value;
    }

    public int GetDiseaseCount()
    {
        return diseaseCount;
    }

    public void SetDiseaseCount(int count)
    {
        if (count > 3)
        {
            diseaseCount = 3;
        } else
        {
            diseaseCount = count;
        }
        UpdateDiseaseVisuals();
    }

    public void AddDiseaseCount()
    {
        if (diseaseCount < 3)
        {
            diseaseCount++;
            UpdateDiseaseVisuals();
        }
        else if (diseaseCount == 3)
        {
            Outbreak();
        }
    }

    public void RemoveDiseaseCount()
    {
        diseaseCount = 0;
        UpdateDiseaseVisuals();
    }

    public void Outbreak()
    {
        foreach (Node adjacentNode in adjacentNodes)
        {
            if (adjacentNode.diseaseCount < 3)
            {
                adjacentNode.AddDiseaseCount();
            }
        }
    }

    private void UpdateDiseaseVisuals()
    {
        foreach (GameObject cube in diseaseCubes)
        {
                Destroy(cube);
        }
        diseaseCubes.Clear();

        for (int i = 0; i < diseaseCount; i++)
        {
                GameObject cube = Instantiate(diseaseCubePrefab, diseaseCubeContainer);
                float offset = i * 0.65f;
                cube.transform.localPosition = new Vector2(offset + 0.5f, 0);
                diseaseCubes.Add(cube);
        }
    }

    void Update()
    {

    }
    public Vector2 GetPosition()
    {
        return transform.position;
    }
    public List<Node> GetAdjacentNodes()
    {
        return adjacentNodes;
    }
}