using System;
using System.Collections;
using System.Collections.Generic;
using ResourcesColection;
using SpanwerHelpers;
using UnityEngine;

public class HelpersBuilding<T> : MonoBehaviour where T : ResourceSource
{
    [SerializeField] protected Factory<T> _spawnHelperTree;
    [SerializeField] protected List<ResourceSource> _resources;
    [SerializeField] protected UpgradePanelUI<T> _panel;
    [SerializeField] protected string KeyData = "";

    protected int LevelPanel = 0;
    public int Counter => _spawnHelperTree.InstanceCount;

    public void LevelUp(int helperInstance,int resourceExtraction)
    {
       StartCoroutine(HelperInstance(helperInstance));
       LevelUpExtraction(resourceExtraction);
    }
    
    public IEnumerator HelperInstance(int helperInstance)
    {
        while (Counter <= helperInstance - 1)
        {
            var helper = _spawnHelperTree.GetHelperInstantiate();
            helper.SetList(_resources);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
    
    private void LevelUpExtraction(int extraction)
    {
        for (int i = 0; i < _resources.Count; i++)
            _resources[i].AddResourceCount(extraction);
    }
}
