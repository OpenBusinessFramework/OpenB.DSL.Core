using System.Collections.Generic;
using System.IO;

namespace OpenB.DSL.Core
{
    internal class Tokenizer
    {
        private TokenDefinition[] tokenDefinitions;

        public Tokenizer(TokenDefinition[] tokenDefinitions)
        {
            this.tokenDefinitions = tokenDefinitions;
        }

        public IList<Token> Tokenize(string expression)
        {
            TextReader textReader = new StringReader(expression);
            Lexer lexer = new Lexer(textReader, tokenDefinitions);

            List<Token> tokens = new List<Token>();

            while (lexer.Next())
            {
                tokens.Add(new Token(lexer.LineNumber, lexer.Position, lexer.Token, lexer.TokenContents));
            }

            return tokens;
        }
    }
}