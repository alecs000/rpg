using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //when object exit the trigger, put it to the assigned layer and sorting layers
    //used in the stair objects for player to travel between layers
    public class LayerTrigger : MonoBehaviour
    {
        public static GameObject item;
        [SerializeField] private int layerID;
        [SerializeField] private string layerName;
        private void OnTriggerExit2D(Collider2D other)
        {
            other.gameObject.layer = layerID;
            SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
            if(spriteRenderer == null)
                return;
            spriteRenderer.sortingLayerID = SortingLayer.NameToID(layerName); 
            item.layer = layerID;
            foreach (Transform sr in item.transform)
            {
                var srArr = sr.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sr1 in srArr)
                {
                    sr1.sortingLayerID = SortingLayer.NameToID(layerName);
                }
            }
        }

    }
}
