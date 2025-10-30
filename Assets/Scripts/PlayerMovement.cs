using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float gameSpeed = 5f;
    [SerializeField] private Board board;
    [SerializeField] private Player player;
    [SerializeField] private Text text;

    private Node previousNode;

    Vector2 targetPos;

    bool isMoving = false;


    void Start()
    {
        previousNode = board.GetCurrentNode();
    }

    void Update()
    {
        Node targetNode = board.GetCurrentNode();
        if (CanMoveToNode(targetNode) && !isMoving && player.GetPlayerTurn())
        {
            targetPos = board.GetCurrentNode().GetPosition();
            isMoving = true;
            text.text = "Moved to " + board.GetCurrentNode();
            previousNode = targetNode;
            player.SetPlayerTurn(false);
        } else
        {
            board.SetCurrentNode(previousNode);
        }

        if (isMoving)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        Vector2 currentPos = player.GetPosition();
        player.SetPosition(Vector2.MoveTowards(currentPos, targetPos, gameSpeed * Time.deltaTime));

        if (Vector2.Distance(player.GetPosition(), targetPos) < 0.01f)
        {
            player.SetPosition(targetPos);
            isMoving = false;
        }
    }

    bool CanMoveToNode(Node node)
    {
        foreach (Node adjascentNode in previousNode.GetAdjacentNodes())
        {
            if (adjascentNode == node)
            {
                return true;
            }
        }
        return false;
    }
}
