using System.Collections;
using System. Collections. Generic;
using UnityEngine;

public class MaterialIDBehaviour : IDContainerBehaviour //look at this later
{
    public MaterialIDDatalist materialIDDataListObj;
    private Renderer rendererobj;
    private void Awake()
    {
        rendererObj = GetComponent<Renderer>();
        IDObj = materialIDDataListObj.currentMaterial;
    }

    public void ChangeRendererMaterialOrder(MaterialID newMaterialID)
    {
        rendererObj.material = newMaterialID.newMaterialOrder;
    }

    public void ChangeRendererMaterialOrder(MaterialIDDatalist obj)
    {
        rendererObj.material = obj.currentMaterial.newMaterialOrder;
    }

    public void ChangeRendererMaterialTicket(MaterialID newMaterialID)
    {
        rendererObj. material = newMaterialID.newMaterialTicket;
    }

    public void ChangeRendererMaterialTicket (MaterialIDDatalist obj)
    {
        rendererobj.material = obj.currentMaterial.newMaterialTicket;
    }
}