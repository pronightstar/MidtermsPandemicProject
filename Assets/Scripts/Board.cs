using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Board : MonoBehaviour
{
    [SerializeField] private List<Node> nodes;
    [SerializeField] private Player player;
    [SerializeField] private Text text;
    Die die = new Die();
    private Node currentNode;

    void Start()
    {
        SetCurrentNode(nodes[0]);
        nodes[1].SetDiseaseCount(2);
        text.text = "Press 'r' to read role. Click a node to move to it. Press 'space' to cure disease.";
    }
    public List<Node> GetNodes()
    {
        return nodes;
    }

    public Node GetCurrentNode()
    {
        return currentNode;
    }
    public void SetCurrentNode(Node node)
    {
        if (currentNode != null)
        {
            currentNode.SetPlayerLoc(false);
        }
        currentNode = node;
        if (currentNode != null)
        {
            currentNode.SetPlayerLoc(true);
        }
    }

    public void EndTurnInfect()
    {
        int nodeInfected = die.RollDice();
        nodes[nodeInfected].AddDiseaseCount();
        Node infec1 = nodes[nodeInfected];
        nodeInfected = die.RollDice();
        nodes[nodeInfected].AddDiseaseCount();
        Node infec2 = nodes[nodeInfected];
        player.SetPlayerTurn(true);
        player.SetPlayerAct(true); 
        text.text = infec1 + " and " + infec2 + " have been infected!";
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.GetPlayerAct())
        {
            player.SetPlayerAct(false);
            currentNode.RemoveDiseaseCount();
            EndTurnInfect();
        }
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    currentNode.AddDiseaseCount();
        //}
        if (Input.GetKeyDown(KeyCode.R))
        {
            text.text = "Role: Medic";
        }
    }

}