using System.Linq;
using Mono.Cecil;

namespace AutoMiniProfiler.Fody.Weavers
{
    internal class MethodWeaverFactory
    {
        private readonly TypeReferenceProvider _typeReferenceProvider;
        private readonly MethodReferenceProvider _methodReferenceProvider;

        public MethodWeaverFactory(TypeReferenceProvider typeReferenceProvider, MethodReferenceProvider methodReferenceProvider)
        {
            _typeReferenceProvider = typeReferenceProvider;
            _methodReferenceProvider = methodReferenceProvider;
        }

        public MethodWeaverBase Create(MethodDefinition methodDefinition)
        {
            if (IsAsyncMethod(methodDefinition))
            {
                return new AsyncMethodWeaver(_typeReferenceProvider, _methodReferenceProvider, methodDefinition);
            }

            return new MethodWeaver(_typeReferenceProvider, _methodReferenceProvider, methodDefinition);
        }

        private bool IsAsyncMethod(MethodDefinition methodDefinition)
        {
            return
                methodDefinition.CustomAttributes.Any(it => it.AttributeType.FullName.Equals(_typeReferenceProvider.AsyncStateMachineAttribute.FullName));
        }
    }
}