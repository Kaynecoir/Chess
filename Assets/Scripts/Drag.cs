using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
	public bool ableDrag = true;
	[SerializeField] private Canvas canvas;
	private UGameManager GM;
	private RectTransform rectTransform;
	private CanvasGroup canvasGroup;

	private void Awake()
	{
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		GM = GameObject.Find("GameManager").GetComponent<UGameManager>();
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}	

	public void OnPointerDown(PointerEventData eventData)
	{
		GM.SelectFigur(GetComponent<ChessFigure>());
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		canvasGroup.alpha = 0.8f;
		canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.alpha = 1f;
		canvasGroup.blocksRaycasts = true;
	}


}
