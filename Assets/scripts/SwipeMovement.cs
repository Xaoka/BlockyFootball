using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
	// If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
	public const float MAX_SWIPE_TIME = 0.5f;

	// Factor of the screen width that we consider a swipe
	// 0.17 works well for portrait mode 16:9 phone
	public const float MIN_SWIPE_DISTANCE = 0.17f;

	private bool swipedRight = false;
	private bool swipedLeft = false;
	private int lane = 2;
	private bool debugWithArrowKeys = true;
	private bool isTransitioning = false;

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	// Swipe code based on https://gist.github.com/Fonserbc/ca6bf80b69914740b12da41c14023574
	public void Update()
	{
		swipedRight = false;
		swipedLeft = false;

		if (Input.GetMouseButtonDown(0))
		{
			//save began touch 2d point
			firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}
		if (Input.GetMouseButtonUp(0))
		{
			//save ended touch 2d point
			secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

			//create vector from the two points
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			//normalize the 2d vector
			currentSwipe.Normalize();
			//swipe left
			if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				swipedLeft = true;
			}
			//swipe right
			if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				swipedRight = true;
			}
		}

		if (debugWithArrowKeys)
		{
			swipedRight = swipedRight || Input.GetKeyDown(KeyCode.RightArrow);
			swipedLeft = swipedLeft || Input.GetKeyDown(KeyCode.LeftArrow);
		}

		if (swipedLeft && lane > 0 && !isTransitioning)
		{
			lane -= 1;
			StartCoroutine(transition(this.gameObject.transform.localPosition - this.gameObject.transform.right * 1.5f));
		}
		if (swipedRight && lane < 4 && !isTransitioning)
		{
			lane += 1;
			StartCoroutine(transition(this.gameObject.transform.localPosition + this.gameObject.transform.right * 1.5f));
		}
	}

	IEnumerator transition(Vector3 targetPosition)
	{
		isTransitioning = true;
		var startPos = this.gameObject.transform.localPosition;
		var dTime = 0f;
		while (Vector3.Magnitude(this.gameObject.transform.localPosition - targetPosition) > float.Epsilon)
		{
			dTime += Time.deltaTime * 5;
			this.gameObject.transform.localPosition = Vector3.Lerp(startPos, targetPosition, dTime);
			yield return new WaitForFixedUpdate();
		}
		isTransitioning = false;
	}
}
