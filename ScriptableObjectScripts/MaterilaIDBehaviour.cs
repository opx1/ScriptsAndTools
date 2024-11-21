using System.Collections;
using System.Collections. Generic;
using UnityEngine;

public class MaterialIDBehaviour : IDContainerBehaviour //look at this later
{
    public MaterialIDDataList materialIDDataListObj;
    private Renderer rendererObj;
    private void Awake()
    {
        rendererObj = GetComponent<Renderer>();
        IDObj = materialIDDataListObj.currentMaterial;
    }

    public void ChangeRendererMaterialOrder(MaterialID newMaterialID)
    {
        rendererObj.material = newMaterialID.newMaterialOrder;
    }

    public void ChangeRendererMaterialOrder()
    {
        rendererObj.material = materialIDDataListObj.currentMaterial.newMaterialOrder;
    }

    public void ChangeRendererMaterialTicket(MaterialID newMaterialID)
    {
        rendererObj.material = newMaterialID.newMaterialTicket;
    }

    public void ChangeRendererMaterialTicket ()
    {
        rendererObj.material = materialIDDataListObj.currentMaterial.newMaterialTicket;
    }
}