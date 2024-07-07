using NumberToWors_WordToNumber;
using System;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void Test1()
        {

            converter converter = new converter();
            Input input = new Input(1);
            InputWN inputwn = new InputWN("one dollars");
            Output output = converter.Result(input);
            Output outputwn = converter.ResultWN(inputwn);


            Assert.AreEqual("one dollars", output.GetResult());
            Assert.AreEqual(1, outputwn.GetResult());

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {

            converter converter = new converter();
            Input input = new Input(100);
            InputWN inputwn = new InputWN("one hundred dollars");
            Output output = converter.Result(input);
            Output outputwn = converter.ResultWN(inputwn);


            Assert.AreEqual("one hundred dollars", output.GetResult());
            Assert.AreEqual(100, outputwn.GetResult());

            Assert.Pass();
        }

        [Test]
        public void Test3()
        {

            converter converter = new converter();
            Input input = new Input(1999999999);
            InputWN inputwn = new InputWN("forty sdfefwdwq dollars");
            Output output = converter.Result(input);
            Output outputwn = converter.ResultWN(inputwn);


            Assert.AreEqual("Invalid input", output.GetResult());
            Assert.AreEqual("Invalid input", outputwn.GetResult());

            Assert.Pass();
        }
    }
}