using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using mancomb.Framework.Core;
using NUnit.Mocks;
using Microsoft.Xna.Framework;

namespace mancomb.Framework.Test
{
    // tests to find out how c# works :P
    class NativeTests
    {
        [TestFixture]
        public class BehaviourTest
        {
            [Test]
            public void testingSortedList()
            {
                SortedList<int, int> tests = new SortedList<int, int>();

                tests.Add(1, 11);
                tests.Add(5, 15);
                tests.Add(2, 12);
                tests.Add(3, 13);
                tests.Add(4, 14);

                int expectedValue = 11;
                foreach (int test in tests.Values)
                {
                    Assert.AreEqual(test, expectedValue);
                    expectedValue++;
                }    
            }

            [Test]
            public void exampleMUnitTest()
            {
                BaseEntity entity = new BaseEntity();
                IBehaviour mockBehaviour = (IBehaviour)new DynamicMock(typeof(IBehaviour));
                entity.addBehaviour(GameLoopPhase.Draw, mockBehaviour);
                entity.addBehaviour(GameLoopPhase.Draw, mockBehaviour);
                entity.addBehaviour(GameLoopPhase.Draw, mockBehaviour);
                entity.addBehaviour(GameLoopPhase.Draw, mockBehaviour);
                entity.addBehaviour(GameLoopPhase.Draw, mockBehaviour);
                // entity.runBehaviours();
                Assert.AreEqual(entity, entity);
            }
        }
    }
}
