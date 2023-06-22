using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
	public Vector2Int position;
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("Drop");
		if(eventData.pointerDrag != null)
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
			if (eventData.pointerDrag.GetComponent<ChessFigure>().TryMove(position)) eventData.pointerDrag.GetComponent<ChessFigure>().Move(position);
		}
	}
}
