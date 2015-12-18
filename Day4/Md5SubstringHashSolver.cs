using System;
using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    internal sealed class Md5SubstringHashSolver
    {
        private readonly string _secretKey;
        private readonly string _expectedStartingSubstring;

        private readonly MD5 _md5;

        public Md5SubstringHashSolver(string secretKey, string expectedStartingSubstring)
        {
            _secretKey = secretKey;
            _expectedStartingSubstring = expectedStartingSubstring;

            _md5 = MD5.Create();
        }

        public int Solve()
        {
            var solved = false;
            var answer = -1;

            while (!solved)
            {
                var hashInput = _secretKey + ++answer;

                var hashResultBytes = _md5.ComputeHash(Encoding.UTF8.GetBytes(hashInput));
                var hashResultString = BitConverter.ToString(hashResultBytes).Replace("-", string.Empty);

                solved = hashResultString.StartsWith(_expectedStartingSubstring);
            }

            return answer;
        }
    }
}