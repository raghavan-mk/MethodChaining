using System;
using System.Collections.Generic;
using System.Linq;

namespace random {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine("Stop here");
            // SinglyLinkedList llist = new SinglyLinkedList ();

            // Console.WriteLine("Enter no of nodes");            
            // var llistCount = Convert.ToInt32 (Console.ReadLine ());

            // for (int i = 0; i < llistCount; i++) {
            //     int llistItem = Convert.ToInt32 (Console.ReadLine ());
            //     llist.InsertNode (llistItem);
            // }

            // printLinkedList (llist.head);

            // int[,] arr = new int[10,10];
            // Console.WriteLine(arr.GetLength(0));

            int[] n = {3,2,1,3};
            var ints = n.ToList().OrderByDescending(n1 => n1)
                                .GroupBy(n1 => n1)
                                .Select(n1 => new {
                                    key = n1.Key,
                                    value = n1.Count()
                                }).First().value;    
            var min = n.ToList().OrderByDescending(n1=>n1).SkipLast(1).Sum();

            // Console.WriteLine(min);
                                
            // //Console.WriteLine(ints);
            //  Console.WriteLine(ints);

             int[] sort = {-9,-5,-6,-8,-10,-1};

             Console.WriteLine(sort.OrderBy(n1 => n1).ElementAt(sort.Length-1));

            //.GroupBy(n => n).Take(1).Count(k => k.Key);
        }

        private static void printLinkedList (SinglyLinkedListNode head) {
            // Console.WriteLine (head.data);
            // if (head.next == null)
            //     return;
            // printLinkedList (head = head.next);
        }
    }

    public class SinglyLinkedListNode {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode (int nodeData) {
            this.data = nodeData;
            this.next = null;
        }
    }

    public class SinglyLinkedList {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList () {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode (int nodeData) {
            SinglyLinkedListNode node = new SinglyLinkedListNode (nodeData);

            if (this.head == null) {
                this.head = node;
            } else {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

}