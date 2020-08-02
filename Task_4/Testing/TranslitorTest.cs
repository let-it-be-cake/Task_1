using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TranslitorTest
{
    public class TranslitorTest
    {

        [Theory]
        [InlineData("никатинамидадениндинуклеотидфосфатгидрин", "nikatinamidadenindinukleotidfosfatgidrin")]
        [InlineData("кот", "kot")]
        [InlineData("независимость продиктованая необходимостью", "nezavisimost prodiktovanaia neobhodimostyu")]
        public void Send_word_and_get_translit_rus(string message, string expected) {
            // act
            var actual = Clients.Translate.Translitor.ToRus(message);
            // assert
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData("nikatinamidadenindinukleotidfosfatgidrin", "никатинамидадениндинуклеотидфосфатгидрин")]
        [InlineData("kot", "кот")]
        [InlineData("nezavisimost prodiktovanaia neobhodimostyu", "независимост продиктованаиа необходимостиу")]
        public void Send_word_and_get_translit_eng(string message, string expected)
        {
            // act
            var actual = Clients.Translate.Translitor.ToEng(message);
            // assert
            Assert.Equal(actual, expected);
        }
    }
}
