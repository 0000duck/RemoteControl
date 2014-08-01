using System;
using Machine.Specifications;
using RemoteControl.Operations;

namespace RemoteControl.Tests
{
    class Model
    {
        public String Name { get; set; }
    }

    [Tags("Operations")]
    public abstract class OperationSpecs
    {
        Establish context =
            () =>
            {
                var client = new OperationsClient();

                client.On<String, Model>("HelloWorld", model => "Hello " + model.Name);
            };
    }

    [Subject(typeof(IOperation<Object, Object>))]
    public class When_Executing_HelloWorld_Operation_The_Promisse : OperationSpecs
    {
        Establish context = () => operation = new Operation<String, Model>("HelloWorld");

        Because of = () =>
                     {
                         promisse = operation.Execute(new Model {Name = "AlienEngineer"});
                         hasValue = promisse.Wait(Promisse.INFINITE);
                     };

        It should_not_be_null = () => promisse.ShouldNotBeNull();
        It should_have_a_successfull_wait_result = () => hasValue.ShouldBeTrue();
        It should_hold_the_value_Hello_AlienEngineer = () => promisse.Value.ShouldEqual("Hello AlienEnginner");
        It should_be_complete = () => promisse.IsCompleted.ShouldBeTrue();

        private static Operation<string, Model> operation;
        private static IPromisse<string> promisse;
        private static bool hasValue;
    }
}