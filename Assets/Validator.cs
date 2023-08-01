using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour
{
    [SerializeField] List<knitRow> m_KnitRows;
    knitRow TopKnitRow=null;
    knitRow ActiveKnitRow;
    List<knitRow> m_ActiveKnitRows = new List<knitRow>();
    
    void Start()
    {
        if (m_KnitRows.Count > 0)
        { 
            TopKnitRow = m_KnitRows[0]; 
            ActiveKnitRow = m_ActiveKnitRows[m_ActiveKnitRows.Count-1];
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddKnitRow(knitRow KR,Data knitdata)
    {
        if (m_ActiveKnitRows.Contains(KR))
            return;
        m_ActiveKnitRows.Add(KR);
        ActiveKnitRow = m_ActiveKnitRows[m_ActiveKnitRows.Count - 1];
       
    }
    public void Validate(knitRow Topknitrow)
    {
        if (ActiveKnitRow.GetKnitData().KnitColor == ActiveKnitRow.GetKnitData().KnitColor)
        {
            //knit here
            return;
            
        }
            
    }
}
