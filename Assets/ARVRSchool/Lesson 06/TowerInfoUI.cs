using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfoUI : MonoBehaviour
{

	public TowerPropertyView Prototype;
	public RectTransform Root;
	
	private void Start()
	{
		List<TowerProperty> properties = new List<TowerProperty>();
		properties.Add(new TowerProperty(){PropertyName = "Distance", PropertyValue = "50"});
		properties.Add(new TowerProperty(){PropertyName = "Health Points", PropertyValue = "30"});
		properties.Add(new TowerProperty(){PropertyName = "Damage Type", PropertyValue = "Mage"});
		
		
		Prototype.gameObject.SetActive(true);

		foreach (var property in properties)
		{
		var instance =	Instantiate(Prototype);
			instance.Setup(property);
			instance.GetComponent<RectTransform>().SetParent(Root, false);
		}
		
		
		Prototype.gameObject.SetActive(false);
		
	}
}
