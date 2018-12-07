
using UnityEngine;

public class CubeAnimationController : MonoBehaviour
{

	public Color TestColor;
	
	public Animator animator;

	public void Jump()
	{
		animator.SetTrigger("Jumping");
	}

	public void OnCustomPropertyAnimFinish(int param)
	{
		Debug.Log("OnCustomPropertyAnimFinish " + param);
	}

	private void Start()
	{

		var prefab = Resources.Load("Tower");
		Instantiate(prefab);
	}
}
