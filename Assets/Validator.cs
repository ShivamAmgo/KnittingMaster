using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Validator : MonoBehaviour
{
    [SerializeField] List<knitRow> m_KnitRows;
    knitRow TopKnitRow=null;
    knitRow ActiveKnitRow;
    List<knitRow> m_ActiveKnitRows = new List<knitRow>();
    [SerializeField] int NumberOfRowsToBake=4;
    void Start()
    {
        if (m_KnitRows.Count > 0)
        { 
            TopKnitRow = m_KnitRows[3]; 
            //ActiveKnitRow = m_ActiveKnitRows[m_ActiveKnitRows.Count-1];
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddKnitRowAtStart(knitRow KR,Data knitdata)
    {
        if (m_ActiveKnitRows.Contains(KR))
            return;
        m_ActiveKnitRows.Add(KR);
        ActiveKnitRow = KR;
        //Debug.Log("active knit " + ActiveKnitRow + " at " + m_KnitRows[m_KnitRows.IndexOf(ActiveKnitRow)]);
       
    }
    public void Validate(knitRow knitrow)
    {
        if (m_ActiveKnitRows.IndexOf(ActiveKnitRow) >= 3) return;
        if (knitrow.GetKnitData().KnitColor == ActiveKnitRow.GetKnitData().KnitColor)
        {
            PlaceRowOnTop(knitrow);            
        }
            
    }
    void PlaceRowOnTop(knitRow KR)
    {
        m_KnitRows[m_KnitRows.IndexOf(ActiveKnitRow) + 1].AlignNodes(KR.GetKnitData().KnitNodes);
        ActiveKnitRow = KR;
        m_ActiveKnitRows.Add(KR);
       
    }
    void Bake(int rowcount)
    {
        if (rowcount <= 0) return;
        for (int i = 0; i < rowcount; i++)
        {
            //m_KnitRows[i].AlignNodes()
        }
    }
    public knitRow GetActiveKnitRow()
    { 
        return ActiveKnitRow;
    }
    public void RemoveKnitRow(knitRow KR)
    { 
        m_ActiveKnitRows.Remove(KR);
        //update activeknitrow after removing
        //ActiveKnitRow=
    }
}
