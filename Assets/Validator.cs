using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour
{
    [SerializeField] List<knitRow> m_KnitRows;
    knitRow TopKnitRow=null;
    knitRow ActiveKnitRow;
    List<knitRow> m_ActiveKnitRows;
    
    void Start()
    {
        if (m_KnitRows.Count > 0)
        { 
            TopKnitRow = m_KnitRows[0]; 
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
       
    }
}
