using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPropertyView : MonoBehaviour
{

	public Text _propertyNameText;
	public Text _propertyValueText;
	
	
	
	public void Setup(TowerProperty property)
	{
		_propertyNameText.text = property.PropertyName;
		_propertyValueText.text = property.PropertyValue;
	}
}
