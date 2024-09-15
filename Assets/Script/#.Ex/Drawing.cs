using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Camera cam;
    public Material defaultMaterial;
    public float lineWidth = 0.01f;  // �ν����Ϳ��� ���� ������ ����

    private LineRenderer curLine;
    private int positionCount = 2;
    private Vector3 prevPos = Vector3.zero;

    void Start()
    {
        // 추후에 필요 시 스타트 함수에 스크립트 작성
    }

    void Update()
    {
        DrawMouse();
        EraseLine();
    }

    void DrawMouse()
    {
        // Z�� ���� 10���� �����Ͽ� ī�޶�� ������Ʈ�� �Ÿ��� �����մϴ�.
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane + 0.01f));

        if (Input.GetMouseButtonDown(0))
        {
            CreateLine(mousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            ConnectLine(mousePos);
        }
    }

    void CreateLine(Vector3 mousePos)
    {
        positionCount = 2;
        GameObject line = new GameObject("Line");
        LineRenderer lineRend = line.AddComponent<LineRenderer>();

        // LineRenderer�� ���� ������ �����Ͽ� �ٸ� ������Ʈ�� �������� �ʰ� �մϴ�.
        lineRend.sortingOrder = 1;

        lineRend.startWidth = lineWidth;  // �ν����Ϳ��� ������ �β� ���
        lineRend.endWidth = lineWidth;    // �ν����Ϳ��� ������ �β� ���
        lineRend.numCornerVertices = 5;
        lineRend.numCapVertices = 5;
        lineRend.material = defaultMaterial;
        lineRend.useWorldSpace = true;
        lineRend.positionCount = positionCount;
        lineRend.SetPosition(0, mousePos);
        lineRend.SetPosition(1, mousePos);

        curLine = lineRend;
        prevPos = mousePos;  // ���� ��ġ�� ���� ���콺 ��ġ�� �����մϴ�.
    }

    void ConnectLine(Vector3 mousePos)
    {
        if (Mathf.Abs(Vector3.Distance(prevPos, mousePos)) >= 0.001f)
        {
            prevPos = mousePos;
            positionCount++;
            curLine.positionCount = positionCount;
            curLine.SetPosition(positionCount - 1, mousePos);
        }
    }

    void EraseLine()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane + 0.01f));

            // ��� ������ �˻��Ͽ� Ŭ���� ��ġ�� ����� ������ �����մϴ�.
            LineRenderer[] allLines = FindObjectsOfType<LineRenderer>();
            foreach (LineRenderer line in allLines)
            {
                for (int i = 0; i < line.positionCount; i++)
                {
                    if (Vector3.Distance(line.GetPosition(i), mousePos) < lineWidth * 2)
                    {
                        Destroy(line.gameObject);
                        break;
                    }
                }
            }
        }
    }
}