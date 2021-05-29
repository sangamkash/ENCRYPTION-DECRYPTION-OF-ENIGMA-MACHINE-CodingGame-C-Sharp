using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string operation = Console.ReadLine();
        int pseudoRandomNumber = int.Parse(Console.ReadLine());
        string[] rotors = new string[3];
        for (int i = 0; i < 3; i++)
        {
            string rotor = Console.ReadLine();
            rotors[i] = rotor;
        }
        string message = Console.ReadLine();
        var dic= new Dictionary<char,int>();
        var abc="ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
         for (int i = 0; i < abc.Length; i++)
         {
             dic.Add(abc[i],i);
         }
         var result="";
        if (operation == "ENCODE")
        {
            result=Encode(message, pseudoRandomNumber, rotors,dic,abc);
        }
        else
        {
            result=Decode(message, pseudoRandomNumber, rotors,dic,abc);
        }
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(result);
    }
    public static string Encode(string message, int p, string[] rotors,Dictionary<char,int> dic,char[] abc)
    {
        char[] arr = message.ToCharArray();
        for (var i = 0; i < arr.Length; i++)
        {
            var t = dic[arr[i]];
            var idx= (t+p+i)%26;
            arr[i]=abc[idx];
        }

        for (var j = 0; j < rotors.Length; j++)
        {
            var rrr=rotors[j].ToCharArray();
            for (var i = 0; i < arr.Length; i++)
            {
                var msg = arr[i];
                var idx = dic[msg];
                arr[i] =rrr[idx];
            }
        }
        return new string(arr);
    }
    
    public static string Decode(string message, int p, string[] rotors,Dictionary<char,int> dic,char[] abc)
    {
        char[] arr = message.ToCharArray();

       
        for (var i = 0; i < arr.Length; i++)
        {
            for (var j =  rotors.Length-1; j >=0; j--)
            {
                var rrr=rotors[j].ToCharArray();
                for (var k = 0; k < rrr.Length; k++)
                {
                    if(arr[i] == rrr[k])
                    {
                        arr[i]=abc[k];
                        //Console.Error.WriteLine($" ||= {i} ==={rrr[k]}=={abc[k]}");
                        break;
                    }
                }
            }
        }
        Console.Error.WriteLine($" ||= {new string(arr)}");

        for (var i = 0; i < arr.Length; i++)
        {
            var t = dic[arr[i]];
            var tt=(t-p-i)%26;
            var idx= tt>=0?tt:26+tt;
             Console.Error.WriteLine($" {tt}|| {idx}");
            arr[i]=abc[idx];
        }

         Console.Error.WriteLine($"---- { new string(arr)}----");
        return new string(arr);
    }
}
