using System;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Fundamentals
{
    public static Func<float, float> sigma = (value) => {return 1/(1 - Mathf.Exp(-value));};
    public class Neuron {
        private float activation_value = 0;
        private float bias = 0;
        private int neuron_id;
        public float Bias 
        {get {return bias;} set {bias = value;}}
        public float Activation_value 
        {get {return activation_value;} set {activation_value = value;}}
        public int Neuron_id 
        {get {return neuron_id;} set {neuron_id = value;}}
        public Neuron(int id){
            neuron_id = id;
        }
    }
    public class Connection{
        private int input_node;
        private int output_node; 
        private int connection_id;
        public int Input_node 
        {get {return input_node;} set {input_node = value;}}
        public int Output_node 
        {get {return output_node;} set {output_node = value;}}
        public int Connection_id 
        {get {return connection_id;} set {connection_id = value;}}
        public Connection(int input_node, int output_node, int connection_id){
            this.input_node = input_node; 
            this.output_node = output_node;
            this.connection_id = connection_id;
        }
    }
    public class TestBasicNetwork{
        public List<Neuron> nodes = new List<Neuron>();
        public List<Connection> connections = new List<Connection>();

        public TestBasicNetwork(){
            for(int i = 0; i < 10; ++i){
                nodes.Add(new Neuron(i));
            }
            for(int i = 0; i < 10; ++i){
                connections.Add(new Connection(
                UnityEngine.Random.Range(0, nodes.Count), 
                UnityEngine.Random.Range(0, nodes.Count), i));
            }
        }
    }
}
