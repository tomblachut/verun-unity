using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizeSeat : MonoBehaviour {

	public Material Selected;
	public Material Inactive;
	public Material Highlighted;
	public Material Normal;

	private Renderer Renderer;

	void Start() {
		Renderer = gameObject.GetComponent<Renderer>();
//		Renderer.enabled = true;
	}

    public void SetSelected()
    {
        SetMaterial(Selected);
    }

    public void SetNormal()
    {
        SetMaterial(Normal);
    }

    public void SetHighlighted()
    {
        SetMaterial(Highlighted);
    }

    public void SetInactive()
    {
        SetMaterial(Inactive);
    }

    private void SetMaterial(Material material)
    {
        Material[] mats = Renderer.materials;
        mats[0] = material;
        GetComponent<Renderer>().materials = mats;
    }
}
