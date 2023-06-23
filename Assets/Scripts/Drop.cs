using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
	public Canvas canvas;
	public Vector2Int position;
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("Drop");
		Debug.Log(position);
		if(eventData.pointerDrag != null)
		{
			if (eventData.pointerDrag.GetComponent<ChessFigure>().TryMove(position))
			{
				Debug.Log("Can Move");
				eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
				eventData.pointerDrag.GetComponent<ChessFigure>().Move(position);
			}
			else
			{
				Debug.Log("Can't Move");
				Vector2 v = new Vector2((eventData.pointerDrag.GetComponent<ChessFigure>().position.x - 3.5f) * 108, (eventData.pointerDrag.GetComponent<ChessFigure>().position.y - 3.5f) * 108);
				Debug.Log(eventData.pointerDrag.GetComponent<ChessFigure>().position);
				eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = v;
			}
		}
	}
}
