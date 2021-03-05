using System;
using System.Collections;
using System.Collections.Generic;

namespace Slice.Exercise
{
    public class Slice
    {
        private void ValidateInput(string word) {
            if (String.IsNullOrWhiteSpace(word)) {
                throw new ArgumentException("Word and target cannot be empty or null.");
            }
        }

        public string SliceTo(string word, string target)
        {
            ValidateInput(word); 
            ValidateInput(target);
            
            var index = word.IndexOf(target);
            if (index == -1) {
                return word;
            }
            return word.Substring(0, index + 1);
            
        }

        public string SliceUntil(string word, string target)
        {
            ValidateInput(word); 
            ValidateInput(target);

            var index = word.IndexOf(target);
            if (index == -1) {
                return word;
            } 
            return word.Substring(0, index);
            
        }

        public string SliceAfter(string word, string target)
        {
            ValidateInput(word); 
            ValidateInput(target);

            var index = word.IndexOf(target);
            if (index == -1) {
                return word;
            } 
            return word.Substring(index);
            
        }

        public string SliceBetween(string word, string start, string end)
        {
            ValidateInput(word); 
            ValidateInput(start);
            ValidateInput(end); 
            
            var startIndex = word.IndexOf(start);
            var endIndex = word.IndexOf(end);
            if (startIndex == -1 || endIndex == -1) {
                return word;
            } 
            return word.Substring(startIndex, endIndex);
            
        }

        public string[] AllSlicesBetween(string word, string start, string end)
        {
            ArrayList slicedWords = new ArrayList();

            ValidateInput(word); 
            ValidateInput(start);
            ValidateInput(end); 

            var foundAll = false;
            while (!foundAll) {
                var startIndex = word.IndexOf(start);
                var endIndex = word.IndexOf(end);
                var length = endIndex - startIndex + 1;

                if (startIndex == -1 || endIndex == -1) {
                    break;
                }

                slicedWords.Add(word.Substring(startIndex, length));
                word = word.Remove(startIndex, length);
                
            }

            return (String[])slicedWords.ToArray(typeof(string));
            
        }
    }
}