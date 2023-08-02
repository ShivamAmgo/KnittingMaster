using System.Collections;
using System.Collections.Generic;
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
            ActiveKnitRow = m_ActiveKnitRows[m_ActiveKnitRows.Count-1];
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
        ActiveKnitRow = m_ActiveKnitRows[m_ActiveKnitRows.Count - 1];
       
    }
    public void Validate(knitRow knitrow)
    {
        if (knitrow.GetKnitData().KnitColor == ActiveKnitRow.GetKnitData().KnitColor)
        {

                        
        }
            
    }
    void PlaceRowOnTop(knitRow KR)
    { 
        //if(TopKnitRow)
    }
    void Bake(int rowcount)
    {
        if (rowcount <= 0) return;
        for (int i = 0; i < rowcount; i++)
        {
            //m_KnitRows[i].AlignNodes()
        }
    }
}
