using System;

namespace ProficiencyTest
{
	public class Node
	{
		public int Value { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
		public Node(int value, Node left, Node right)
		{
			Value = value;
			Left = left;
			Right = right;
		}
	}
	public class BinarySearchTree
	{
		public static bool IsValidBST(Node root)
		{
			//checking node left and right are not equal of null, root value should be less than equal to root left and root value should be greater than equal to root right
			//if checked condition is true then root is valid binary search tree
			if( (Node)root.Left!=null && (Node) root.Right!=null && root.Value >=((Node)root.Left).Value && root.Value <=( (Node) root.Right).Value) {
				return true;
			} else {
				return false;
			}
		}
//		public static void Main(string[] args)
//		{
//			Node n1 = new Node(1, null, null);
//			Node n3 = new Node(3, null, null);
//			Node n2 = new Node(2, n1, n3);
//			Console.WriteLine(IsValidBST(n2));
//		}
	}
}

