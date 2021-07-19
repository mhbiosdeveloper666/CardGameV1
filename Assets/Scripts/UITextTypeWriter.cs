using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class UITextTypeWriter : MonoBehaviour 
{
	
	Text txt;
	string story;
	AudioSource m_MyAudioSource;
	void Awake () 
	{
		m_MyAudioSource = GetComponent<AudioSource>();

		txt = GetComponent<Text> ();
		story = txt.text;
		txt.text = "";
		StartCoroutine ("PlayText");
	}
	
	IEnumerator PlayText()
	{
		yield return new WaitForSeconds (0.5f);

		foreach (char c in story) 
		{
			if (c=='.') {
				m_MyAudioSource.Stop();
				yield return new WaitForSeconds (1.12f);
			}
			else{
			m_MyAudioSource.Play();
			txt.text += c;
			yield return new WaitForSeconds (0.115f);
			}
		}
		m_MyAudioSource.Stop();
	}

	
}