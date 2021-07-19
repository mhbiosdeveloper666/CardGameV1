using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainCard : MonoBehaviour {

	[SerializeField] private SceneController controller;
	[SerializeField] public GameObject Card_Back;

	void OnMouseDown()
	{
		Debug.Log("Clicked");
		if (Card_Back.activeSelf&&controller.canReveal) 
		{
			Card_Back.SetActive (false);
			controller.CardRevealed(this);
		}
	}

	private int _id;
	public int id
	{
		get	{return _id;}
	}
	public void ChangeSprite(int id,Sprite image)
	{
		_id=id;
		GetComponent<SpriteRenderer> ().sprite = image;

	}
	public void Unreveal()
	{
		Card_Back.SetActive (true);
	}
}	