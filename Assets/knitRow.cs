using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class knitRow : MonoBehaviour
{
    [SerializeField] bool IsColorActive = false;
    [SerializeField] GameObject _node;
    [SerializeField] List<Transform> KnitPositions;
    [SerializeField] Color KnitRowColor=Color.white;
    [SerializeField] float Delay = 0.1f;
    [SerializeField] float Duration = 0.2f;
    [SerializeField] float WobbleValue = 1.5f;
    [SerializeField] float WobbleDuration = 0.2f;
    [SerializeField] int WobbleAFterNode = 20;
    Validator m_Validator;
    List<Transform> KnitNodes;
    List<Transform> BakedNodes = new List<Transform>();
    Data KnitData = new Data();
    bool IsInteractable = false;
    void Start()
    {
        m_Validator = GetComponentInParent<Validator>();
        KnitData.KnitColor = KnitRowColor;
        if (IsColorActive)
        {
            m_Validator.AddKnitRowAtStart(this, KnitData);
            BakeNodes(); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AlignNodes(List<Transform> KnitNodes)
    {
        if (!IsInteractable) return;
        StartCoroutine(Align(Delay,KnitNodes));
        
    }
    void SendNodeToPos(Transform KnitNode, Vector3 Pos)
    {
        KnitNode.DOMove(Pos, Duration).SetEase(Ease.Linear);
    }
    IEnumerator Align(float pausetime, List<Transform> KnitNodes)
    {
        IsInteractable = false;
        int knitindex = 0;
        List<Transform> Wobblenodes = new List<Transform>();
        foreach (Transform item in KnitPositions)
        {
           
            SendNodeToPos(KnitNodes[knitindex], item.position);
            knitindex++;
            Wobblenodes.Add(KnitNodes[knitindex]);
            if (knitindex%WobbleAFterNode ==0)
            {
                Wobble(Wobblenodes);
                yield return new WaitForSeconds(pausetime);
                //Debug.Log(Wobblenodes.Count);
                Wobblenodes.Clear();
                
            }

        }
        IsInteractable = true;
        Debug.Log("Transferred");

    }
    void Wobble(List<Transform> WobbleNodes)
    {
        float scale = WobbleNodes[0].localScale.x;
        float OgScale = scale;
        foreach (Transform item in WobbleNodes)
        {
            //Debug.Log(item.name);
            DOTween.To(() => scale, value => scale = value, WobbleValue*scale, WobbleDuration).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).OnUpdate(() => 
            {
                item.localScale = new Vector3(scale,scale,scale);
            }).OnComplete(() => 
            {
                item.localScale = new Vector3(OgScale,OgScale,OgScale);
            });
        }
    }
    public Data GetKnitData()
    {
        return KnitData;
    }
    void BakeNodes()
    {
        int NodeCount = KnitPositions.Count;
        for (int i = 0; i < NodeCount; i++)
        {
            GameObject obj = Instantiate(_node);
            obj.SetActive(false);
            BakedNodes.Add(obj.transform);
        }
        KnitData.KnitNodes = BakedNodes;
        BakeNodesAtStart();
    }
    void BakeNodesAtStart()
    {
        for (int i = 0; i < KnitPositions.Count; i++)
        {
            BakedNodes[i].transform.position = KnitPositions[i].transform.position;
            BakedNodes[i].GetComponent<MeshRenderer>().material.color = KnitRowColor;
            BakedNodes[i].gameObject.SetActive(true);
        }
    }
}
