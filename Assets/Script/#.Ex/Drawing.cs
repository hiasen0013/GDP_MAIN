using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Camera cam;
    public Material defaultMaterial;
    public float lineWidth = 0.01f;  // 인스펙터에서 조절 가능한 변수

    private LineRenderer curLine;
    private int positionCount = 2;
    private Vector3 prevPos = Vector3.zero;

    void Start()
    {

    }

    void Update()
    {
        DrawMouse();
        EraseLine();
    }

    void DrawMouse()
    {
        // Z축 값을 10으로 설정하여 카메라와 오브젝트의 거리를 유지합니다.
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

        // LineRenderer의 정렬 순서를 설정하여 다른 오브젝트에 가려지지 않게 합니다.
        lineRend.sortingOrder = 1;

        lineRend.startWidth = lineWidth;  // 인스펙터에서 설정된 두께 사용
        lineRend.endWidth = lineWidth;    // 인스펙터에서 설정된 두께 사용
        lineRend.numCornerVertices = 5;
        lineRend.numCapVertices = 5;
        lineRend.material = defaultMaterial;
        lineRend.useWorldSpace = true;
        lineRend.positionCount = positionCount;
        lineRend.SetPosition(0, mousePos);
        lineRend.SetPosition(1, mousePos);

        curLine = lineRend;
        prevPos = mousePos;  // 이전 위치를 현재 마우스 위치로 설정합니다.
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

            // 모든 라인을 검사하여 클릭된 위치와 가까운 라인을 삭제합니다.
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
