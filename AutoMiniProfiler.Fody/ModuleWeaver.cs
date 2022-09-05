using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Fody;
using AutoMiniProfiler.Fody.Helpers;
using AutoMiniProfiler.Fody.Weavers;
using Mono.Cecil;

namespace AutoMiniProfiler.Fody
{
    public class ModuleWeaver: BaseModuleWeaver, IWeavingLogger
    {
        public override void Execute()
        {
            WeavingLog.SetLogger(this);

            var parser = FodyConfigParser.Parse(Config);

            if (parser.IsErroneous)
            {
                WriteError(parser.Error);
            }
            else
            {
                EnsureMiniProfilerRef();
                ModuleLevelWeaver.Execute(parser.Result, ModuleDefinition);
            }
        }

        private void EnsureMiniProfilerRef()
        {
            var miniProfilerSharedReference = ModuleDefinition.AssemblyReferences.FirstOrDefault(assRef => assRef.Name.Equals(AppConsts.MiniProfilerSharedName));
            if (miniProfilerSharedReference == null)
            {
                miniProfilerSharedReference = EnsureRef(AppConsts.MiniProfilerSharedName);
            }

            if (miniProfilerSharedReference == null)
            {
                var miniProfilerReference = ModuleDefinition.AssemblyReferences.FirstOrDefault(assRef => assRef.Name.Equals(AppConsts.MiniProfilerName));
                if (miniProfilerReference == null)
                {
                    miniProfilerReference = EnsureRef(AppConsts.MiniProfilerName);
                }
            }
        }

        private AssemblyNameReference EnsureRef(string assemblyName)
        {
            AssemblyNameReference assemblyNameReference = null;
            var references = References.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var reference in references)
            {
                var assemblyDefinition = AssemblyDefinition.ReadAssembly(reference);
                if (assemblyDefinition.Name.Name != assemblyName)
                {
                    continue;
                }

                assemblyNameReference = AssemblyNameReference.Parse(assemblyDefinition.FullName);
                ModuleDefinition.AssemblyReferences.Add(assemblyNameReference);
                break;
            }
            return assemblyNameReference;
        }

        public override IEnumerable<string> GetAssembliesForScanning()
        {
            yield break;
        }

        void IWeavingLogger.LogDebug(string message)
        {
            WriteDebug(message);
        }

        void IWeavingLogger.LogInfo(string message)
        {
            WriteInfo(message);
        }

        void IWeavingLogger.LogWarning(string message)
        {
            WriteWarning(message);
        }

        void IWeavingLogger.LogError(string message)
        {
            WriteError(message);
        }

        public override bool ShouldCleanReference => true;
    }
}
