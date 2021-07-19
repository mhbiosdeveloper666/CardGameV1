using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public const int gridRows = 2;
	public const int gridCols = 4;
    public const float offsetX = 4f;
	public const float offsetY = 5f;
	private MainCard _firsRevealed;
	private MainCard _secondRevealed;
	private int _score=0;

	[SerializeField] private TextMesh scoreLabel;
	[SerializeField] private MainCard originalCard;
	[SerializeField] private Sprite[] images;

	private void Start()
	{
		Vector3 startPos = originalCard.transform.position;

		int[] numbers = {0,0,1,1,2,2,3,3};
		numbers = ShuffleArray(numbers);

		for (int i = 0; i < gridCols; i++) {
			for (int j = 0; j < gridRows; j++) {
				MainCard card;	
				if (i==0&&j==0) 
				{
					card = originalCard;
				}
				else
				{
					card = Instantiate(originalCard)as MainCard;
				}
				int index = j * gridCols +i;
				int id = numbers[index];
				card.ChangeSprite(id,images[id]);		

				float posX = (offsetX * i) + startPos.x;
				float posY = (offsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX,posY,startPos.z);
			}
		}
	}

	private int[] ShuffleArray(int[] numbers)
	{
		int[] newArray = numbers.Clone () as int[];
		for (int i = 0; i < newArray.Length; i++) 
		{
			int tmp = newArray[i];
			int r = Random.Range(i,newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}
		return newArray;
	}

	public bool canReveal
	{
		get{return _secondRevealed==null;}
	}

	public void CardRevealed(MainCard card)
	{
	if (_firsRevealed == null) 
		{
			_firsRevealed = card;
		} 
		else 
		{
			_secondRevealed = card;
			StartCoroutine(CheckMatch());
		}
	}

	private IEnumerator CheckMatch()
	{
		if (_firsRevealed.id == _secondRevealed.id) 
		{
			_score++;
			scoreLabel.text = "Score: " + _score;
		} 
		else 
		{
			yield return new WaitForSeconds(0.5f);

			_firsRevealed.Unreveal();
			_secondRevealed.Unreveal();
		}
		if (_score==4) 
		{
			Application.LoadLevel("Win");
		}
		_firsRevealed = null;
		_secondRevealed = null;
	}
}
