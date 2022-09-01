using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour {
    [System.Serializable]
    public class Row {
        public List<bool> row;
    }

    [System.Serializable]
    public class Column {
        public List<Row> column;
    }

    [SerializeField] private List<GameObject> _levelBlocks;
    [SerializeField] private Column _setBlocks;

    private void SetBlocks() {
        int k = 0;
        for(int i = 0; i < 4; i++) {
            for(int j = 0; j < 7; j++) {
                _levelBlocks[k].SetActive(_setBlocks.column[i].row[j]);
                k++;
            }
        }
    }

    private void OnEnable() {
        SetBlocks();
    }
}
