using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerSign : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
		StartCoroutine(FlashAlertIcon());
    }

	IEnumerator FlashAlertIcon()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds(0.4f);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds(0.4f);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds(0.4f);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		Debug.Log(">>>ALERT<<<");
	}
}
