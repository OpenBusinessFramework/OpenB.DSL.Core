using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace OpenB.DSL.Core.Test
{
    [TestFixture]
    public class TokenizerTest
    {
        [Test]
        public void XPath_Expresssion_Tokenize_NumberOfTokens_Equals_9()
        {
            TokenDefinition[] tokenDefinitions = {
                new TokenDefinition(@"/{1,2}", "LevelSelector"),
                new TokenDefinition(@"\*", "NodeSelector"),
                new TokenDefinition(@"[0-9]*", "Number"),
                new TokenDefinition(@"'([A-Z]|[a-z]|[0-9]|_|-|\.)*'", "Literal"),                
                new TokenDefinition(@"([A-Z]|[a-z]|[0-9]|_|-|\.)*", "Node"),
                new TokenDefinition(@"@([A-Z]|[a-z]|[0-9]|_|-|\.)*", "Attribute"),
                
                new TokenDefinition(@"\s(and|or)\s", "LogicalOperator"),
                new TokenDefinition(@"\[","ConditionStart"),
                new TokenDefinition(@"\]","ConditionEnd"),
                new TokenDefinition(@"\s{0,}\=\s{0,}", "EqualityComparer")
            };

            Tokenizer tokenizer = new Tokenizer(tokenDefinitions);
            var tokens = tokenizer.Tokenize("/Persons[id = 5]/Person[name='henk' and @key = 4]");

            Assert.That(tokens.Count, Is.EqualTo(9));
        }
    }
}
