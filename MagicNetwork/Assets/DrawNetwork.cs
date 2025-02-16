using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class DrawNetwork : MonoBehaviour
{
    private Fundamentals.TestBasicNetwork network;
    private List<GameObject> nodes = new List<GameObject>();
    public Texture2D nodeTexture;
    GameObject DrawNode(){
        GameObject node = new GameObject();
        SpriteRenderer sr = node.AddComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create(nodeTexture, new Rect(0, 0, nodeTexture.width, nodeTexture.height), new Vector2(0.5f, 0.5f));
        sr.material.color = Color.green;
        node.transform.position = new Vector3(Random.Range(0, 10), Random.Range(0, 10));
        return node;
    }
    void Start()
    {
        network = new Fundamentals.TestBasicNetwork();
        foreach(var neuron in network.nodes){
            nodes.Add(DrawNode());
        }
        foreach(var conn in network.connections){
            LineRenderer lr;
            lr = nodes[conn.Input_node].GetComponent<LineRenderer>();
            if(lr == null){
                lr = nodes[conn.Input_node].AddComponent<LineRenderer>();
                lr.widthMultiplier = 1f;
                lr.startWidth = 0.1f;
                lr.endWidth = 0.1f;
                lr.material.color = Color.cyan;
                lr.materials[0].mainTexture = nodeTexture;
                lr.SetPositions(new Vector3[]{nodes[conn.Input_node].transform.position, nodes[conn.Output_node].transform.position});
                lr.positionCount = 2;
            }else{
                lr.SetPosition(lr.positionCount - 1, nodes[conn.Output_node].transform.position);
            }
        }
    }
    void Update()
    {
        
    }
}
