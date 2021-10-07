using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIneterview
{
    public class BinarySearch
    {
        public int Search(int []array, int findNumber) {

            var min = 0;
            var max = array.Length;
            
            while (max>0) {

                var mid = (min + max) / 2;     //tomo el indice de en medio del array

                if (array[mid] == findNumber)  //verifico que si se encuentra en la posicion calculada
                    return mid;
                if (array[mid] < findNumber)   //verifico que si el valor esta a la izquierda o derecha
                    min = mid + 1;
                else
                    max = mid - 1;
            }
            return -1;                        //En caso de no encontrar el valor se retorna -1
        }
    }
}
