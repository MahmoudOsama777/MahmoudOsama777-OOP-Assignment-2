public class Solution {
    public static bool IsVowel(char c)
    {
        return (c == 'a') || (c == 'e') || (c == 'i') || (c == 'o') || (c == 'u');
    }
    
    public int MaxVowels(string s, int k) {
        int vowels = 0;

        for (int i = 0; i < k; i++)
        {
            if (IsVowel(s[i]))
                vowels++;
        }

        int maxVowels = vowels;

        for (int end = k; end < s.Length; end++)
        {
            if (IsVowel(s[end - k]))
                vowels--;

            if (IsVowel(s[end]))
                vowels++;

            if(vowels >  maxVowels)
                maxVowels = vowels;
        }
        return maxVowels;
    }
}