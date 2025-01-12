## AutoMiniProfiler.Fody
Injects [Miniprofiler](http://miniprofiler.com/) into your code use [Fody](https://github.com/Fody/Fody/).

## The nuget package  [![NuGet Status](http://img.shields.io/nuget/v/MiniProfiler.Fody.svg?style=flat)](https://www.nuget.org/packages/MiniProfiler.Fody/)

https://nuget.org/packages/MiniProfiler.Fody/

    PM> Install-Package MiniProfiler.Fody
    
### Your Code

    namespace MyNamespace
    {
        public class MyClass
        {
            public void MyMethod()
            {
                Console.WriteLine("Hello");
            }
        }
    }

### What gets compiled with MiniProfiler.Fody

    namespace MyNamespace
    {
        public class MyClass
        {
            public void MyMethod()
            {
                IDisposable disposable = MiniProfiler.Current.Step("MyNamespace.MyClass.MyMethod()");
                try
                {
                    Console.WriteLine("Hello");
                }
                finally
                {
                   if(disposable != null)
                   {
                       disposable.Dispose();
                   }
                }
            }
        }
    }


## Inject Configuration

**The idea and most of the code copy form [tracer](https://github.com/csnemes/tracer) :grin:, so configuration of control injection is similar, you can see about configuration detail [here](https://github.com/csnemes/tracer/wiki/Basics)**

### Use FodyWeaver.xml configuration

    <?xml version="1.0" encoding="utf-8"?>
    <Weavers>
        <AutoMiniProfiler profilerConstructors="false" profilerProperties="false">
            <ProfilerOn namespace="Root+*" class="public" method="public" />
            <NoProfiler namespace="Root.Generated" /> 
        </AutoMiniProfiler>
    </Weavers>

### Use Attribute

### ProfilerOnAttribute

    namespace MyNamespace
    {
        public class MyClass
        {
            [ProfilerOn]
            public void MyMethod()
            {
                Console.WriteLine("Hello");
            }
        }
    }

### NoProfilerAttribute

    namespace MyNamespace
    {
        [NoProfiler]
        public class MyClass
        {
            public void MyMethod()
            {
                Console.WriteLine("Hello");
            }
        }
    }
