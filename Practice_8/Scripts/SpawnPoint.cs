using UnityEngine;

namespace Practice_8
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Orc _orcPrefab;
        [SerializeField] private Human _humanPrefab;

        public Orc Orc => _orcPrefab;
        public Human Human => _humanPrefab;
    }
}

