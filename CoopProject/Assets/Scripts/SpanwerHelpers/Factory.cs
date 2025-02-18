using ResourcesColection;
using UnityEngine;

namespace SpanwerHelpers
{
    public abstract class Factory<T> : MonoBehaviour where T : ResourceSource
    {
        [SerializeField] private Helper _helperPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] protected T _resource;
        [SerializeField] protected TreeKeeper _treeKeeper;

        public int InstanceCount { get; private set; }

        public Helper GetHelperInstantiate()
        {
            var instantiateHelper = Instantiate(_helperPrefab, _spawnPoint.position, Quaternion.identity);
            InstanceCount++;
            return instantiateHelper;
        }
    }
}