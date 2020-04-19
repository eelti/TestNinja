using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTest
    {
        [Test] 
        public void Push_WhenCallWithNullObject_ThrowArgumentNullException()
        {
            var stack = new TestNinja.Fundamentals.Stack<object>();
            
            Assert.That(()=> stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_WhenCall_StackCountIncreaseByOne()
        {
            var stack = new Fundamentals.Stack<int>();

            stack.Push(1);
            var result = stack.Count;
            
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenCalledOnEmptyList_ThrowInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<int>();
            
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenCalled_RemoveAndReturnLastElements()
        {
            var stack = new Fundamentals.Stack<int>();
            
            stack.Push(1);
            var result = stack.Pop();

            Assert.That( result, Is.EqualTo(1));
            Assert.That( stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Peek_WhenCalledOnEmptyList_ThrowInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<int>();
            
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCalled_ReturnLastElements()
        {
            var stack = new Fundamentals.Stack<int>();
            
            stack.Push(1);
            var result = stack.Peek();
            
            Assert.That(result, Is.EqualTo(1));
        }
    }
}